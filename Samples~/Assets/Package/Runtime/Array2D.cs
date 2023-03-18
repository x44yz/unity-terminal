using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

namespace UnityTerminal
{
    public class Array2D<T> : IEnumerable
    {
        public int width;
        public int height;
        public List<T> elements;

#region IEnumerable
        public IEnumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }
#endregion // IEnumerable

        public Array2D(int width, int height, T value)
        {
            this.width = width;
            this.height = height;
            elements = new List<T>(width * height);
            for (int i = 0; i < elements.Capacity; ++i)
                elements.Add(value);
        }

        public T Get(int x, int y)
        {
            CheckBounds(x, y);
            return elements[y * width + x];
        }

        public void Set(int x, int y, T value)
        {
            CheckBounds(x, y);
            elements[y * width + x] = value;
        }

        public void Fill(T value)
        {
            for (int i = 0; i < elements.Count; ++i)
                elements[i] = value;
        }

        public void Fill(System.Func<T> func)
        {
            for (int i = 0; i < elements.Count; ++i)
                elements[i] = func();
        }

        private void CheckBounds(int x, int y)
        {
            if (x < 0 || x >= width)
                throw new System.Exception($"x={x} was out of range");
            if (y < 0 || y >= height) 
                throw new System.Exception($"y={y} was out of range");
        }
    }
}
