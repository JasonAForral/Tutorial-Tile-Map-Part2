using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace TileData
{
    [Serializable]
    public class Tile
    {
        Vector3 _position;

        public enum Types
        {
            Ocean = 0,
            Sand,
            Grass,
            Mountain
        };

        public Tile ()
        {
        }

    }
}