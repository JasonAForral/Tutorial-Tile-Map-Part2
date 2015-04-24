using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace TileData
{
    [Serializable]
    public class Tile
    {
        //Vector3 _position;
        public int tileType;

        public Tile (int type = 0)
        {
            tileType = type;
        }
        
    }
}