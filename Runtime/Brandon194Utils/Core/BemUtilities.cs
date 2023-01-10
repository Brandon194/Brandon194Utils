using System.Collections.Generic;
using UnityEngine;

namespace Brandon194
{
    public static class Utilities
    {
        public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPos = default(Vector3), int fontSize = 36, Color color = default(Color), TextAnchor textAnchor = TextAnchor.MiddleCenter, TextAlignment textAlignment = TextAlignment.Center, int sortingOrder = 0)
        {
            return CreateWorldText(parent, text, localPos, fontSize, color, textAnchor, textAlignment, sortingOrder);
        }
        public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPos, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
        {
            GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPos;
            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.text = text;
            textMesh.alignment = textAlignment;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;

            return textMesh;
        }

        public static T[] AddValueToArray<T>(T[] array, T newType)
        {
            List<T> list = new List<T>();

            foreach (T item in array)
            {
                list.Add(item);
            }

            list.Add(newType);

            return list.ToArray();
        }
        public static T[] AddValueToArray<T>(T[] array, T[] added)
        {
            List<T> list = new List<T>();

            foreach (T item in array)
            {
                list.Add(item);
            }

            foreach (T item in added)
            {
                list.Add(item);
            }

            return list.ToArray();
        }

        public static T GetElementFromArray2D<T>(T[] array, int x, int y, int arraySizeX, int arraySizeY)
        {
            return array[x + (y * arraySizeY)];
        }

        public static T GetElementFromArray3D<T>(T[] array, int x, int y, int z, int arraySizeX, int arraySizeY, int arraySizeZ)
        {
            return array[x + (y * arraySizeY) + (z * arraySizeY * arraySizeZ)];
        }

        public static List<T> ArrayToList<T>(T[] array) where T : class
        {
            List<T> list = new List<T>();

            foreach(T item in array)
            {
                list.Add(item);
            }

            return list;
        }
    }
}
