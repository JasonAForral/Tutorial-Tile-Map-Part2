using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace TileData
{
    public class MapData
    {
        //public static Map instance = null;
        protected Tile [,] mapTiles;

        private int mapWidth = 10;
        private int mapLength = 10;

        public int MapWidth { get { return mapWidth; } }
        public int MapLength  { get { return mapLength;} }

        private Vector3 mapDimensions;
        private Vector3 mapDimensionsReciprocal;
        private Vector3 vertexDimensionsReciprocal;
        float perlinScale;
        Vector3 perlinOrigin ;

        bool perlinInverse;
        

        public Vector3 MapDimensionsReciprocal { get { return mapDimensionsReciprocal; } }

        private List <Vector3> gridPositions = new List<Vector3>();

        public MapData (int sizeX, int sizeZ, float perlinScale)
        {
            this.mapWidth = sizeX;
            this.mapLength = sizeZ;

            Vector3 mapDimensions = new Vector3((float)sizeX, 0f, (float)sizeZ);

            mapDimensionsReciprocal.x = 1f / mapDimensions.x;
            mapDimensionsReciprocal.z = 1f / mapDimensions.z;

            vertexDimensionsReciprocal.x = 1f / (mapDimensions.x + 1);
            vertexDimensionsReciprocal.z = 1f / (mapDimensions.z + 1);


            this.mapTiles = new Tile[mapWidth,mapLength];
            this.perlinScale = perlinScale;
            perlinOrigin = new Vector3(Random.Range(100f, 1000f), Random.Range(100f, 10000f));
            perlinInverse = (0.5 < Random.Range(0f, 1f));
            
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
                    mapTiles[x, z] = new Tile(Mathf.Clamp(Mathf.FloorToInt(CustomPerlinNoise((float)x + 0.5f, (float)z + 0.5f) * 4f), 0, 3));
                }
            }
        }


        public Tile GetTileAt (int x, int z)
        {
            if (0 > x || x > mapWidth)
                return null;
            return mapTiles[x, z];
        }

        public float CustomPerlinNoise (float x, float z)
        {
           
            float output = Mathf.PerlinNoise(
                (x + perlinOrigin.x) * (vertexDimensionsReciprocal.x) * perlinScale,
                (z + perlinOrigin.z) * (vertexDimensionsReciprocal.z) * perlinScale);
            if (perlinInverse)
                output = 1 - output;
            return output;
            
        }

    }
}