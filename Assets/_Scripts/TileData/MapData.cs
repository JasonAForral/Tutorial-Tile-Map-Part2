using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace TileData
{
    [Serializable]
    public class MapData
    {
        //public static Map instance = null;
        protected Tile [] mapTiles;

        [SerializeField]
        [Range(1, 100)]
        private int mapWidth = 10;
        [Range(1, 100)]
        [SerializeField]
        private int mapLength = 10;

        public int MapWidth { get { return mapWidth; } }
        public int MapLength  { get { return mapLength;} }

        private Vector3 mapDimensions;
        private Vector3 mapDimensionsReciprocal;

        public Vector3 MapDimensionsReciprocal { get { return mapDimensionsReciprocal; } }

        private List <Vector3> gridPositions = new List<Vector3>();

        public MapData (int sizeX, int sizeZ)
        {
            this.mapWidth = sizeX;
            this.mapLength = sizeZ;

            Vector3 mapDimensions = new Vector3(sizeX, 0f, sizeZ);

            mapDimensionsReciprocal.x = 1f / mapDimensions.x;
            mapDimensionsReciprocal.z = 1f / mapDimensions.z;

            this.mapTiles = new Tile[mapWidth * mapLength];
            InitializeList();
        }

        void InitializeList ()
        {
            gridPositions.Clear();
            for (int x = 0; x < mapWidth; x++)
            {
                for (int z = 0; z < mapLength; z++)
                {
                    gridPositions.Add(new Vector3(x, 0f, z));
                }
            }
        }


        public Tile GetTile (int x, int y)
        {
            if (0 > x || x > mapWidth)
                return null;
            return mapTiles[x + y * mapWidth];
        }

    }
}