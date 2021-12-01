using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// referenced from: https://pudding-entertainment.medium.com/unity-how-to-create-2d-tilemap-programmatically-afb1f94ffce5
[Serializable]
public class MapData
{
    public TileData[] baseLayer;

    [Serializable]
    public struct TileData
    {
        public string Name;
        public int ID;
        public int TileID;
        public int[] Position;

        public TileData(string name, int id, int tile_id, int[] pos)
        {
            Name = name;
            ID = id;
            TileID = tile_id;
            Position = pos;
        }
    }
}
