using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class PackageEditor
{
    [MenuItem("Tool/Copy Package")]  
    public static void CopyPackage()
    {
        var srcFolder = Application.dataPath + "/Package";
        var destFolder = Application.dataPath + "/../../";
        CopyFolder(srcFolder, destFolder);
    }

    public static int CopyFolder(string srcFolder, string destFolder)
    {
        try
        {
            Debug.Log($"copy folder from {srcFolder} to {destFolder}");
            
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            string[] files = Directory.GetFiles(srcFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest, true);
            }

            string[] folders = Directory.GetDirectories(srcFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                if (Directory.Exists(dest))
                    Directory.Delete(dest, true);
                CopyFolder(folder, dest);
            }
            return 1;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"failed to copy folder {srcFolder} > {ex.ToString()}");
            return -1;
        }
    }
}
