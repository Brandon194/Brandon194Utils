using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Brandon194
{
    [System.Serializable]
    public class Grid : MonoBehaviour
    {
        [SerializeField] int gridSizeX, gridSizeY, gridSizeZ;
        [SerializeField] Vector3 position;
        [SerializeField] Vector3 spacing;
        [SerializeField] GridTile[] array;
        [SerializeField] GameObject prefab;

        void Start()
        {
            SetupGrid(gridSizeX, gridSizeY, gridSizeZ, position, spacing, prefab);
        }

        public void SetupGrid(int _x, int _y, int _z, Vector3 _position, Vector3 _spacing, GameObject _prefab = null)
        {
            gridSizeX = _x > 0 ? _x : 1;
            gridSizeY = _y > 0 ? _y : 1;
            gridSizeZ = _z > 0 ? _z : 1;

            if (_prefab != null)
                prefab = _prefab;

            position = _position;
            transform.position = position;
            spacing = _spacing;

            array = new GridTile[_x * _y * _z];

            transform.position = position;

            for (int z = 0; z < gridSizeZ; z++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    for (int x = 0; x < gridSizeX; x++)
                    {
                        GridTile currentTile;

                        if (prefab != null)
                            currentTile = Instantiate(prefab, transform).GetComponent<GridTile>();
                        else
                            currentTile = Instantiate(new GameObject(), transform).AddComponent<GridTile>();

                        currentTile.transform.localPosition = new Vector3(
                            x - (gridSizeX / 2) + (spacing.x * x),
                            y - (gridSizeY / 2) + (spacing.y * y),
                            z - (gridSizeZ / 2) + (spacing.z * z)
                            );

                        currentTile.name = "GridTile (" + x + "," + y + "," + z + ")";

                        array[x + (gridSizeX * y) + (gridSizeX * gridSizeY * z)] = currentTile;
                    }
                }
            }
        }

        public GridTile GetTileFromArray(int _x, int _y, int _z)
        {
            return Brandon194.Utilities.GetElementFromArray3D<GridTile>(array, _x, _y, _z, gridSizeX, gridSizeY, gridSizeZ);
        }
        public GridTile GetTileFromIndex(int x)
        {
            if (array.Length < x)
                return null;
            else
                return array[x];
        }

        public int[] GetGridSizes()
        {
            return new int[] { gridSizeX, gridSizeY, gridSizeZ };
        }
        public int GetGridSize()
        {
            return array.Length;
        }

        public void RefreshGrid()
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    for (int x = 0; x < gridSizeX; x++)
                    {
                        array[x + (gridSizeX * y) + (gridSizeX * gridSizeY * z)].transform.localPosition = new Vector3(
                            x - (gridSizeX / 2) + (spacing.x * x),
                            y - (gridSizeY / 2) + (spacing.y * y),
                            z - (gridSizeZ / 2) + (spacing.z * z)
                            );
                    }
                }
            }
        }
    }

    public class GridTile : MonoBehaviour
    {

    }
}