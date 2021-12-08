using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// referenced from: https://pudding-entertainment.medium.com/unity-how-to-create-2d-tilemap-programmatically-afb1f94ffce5
public static class TilesResourceLoader
{
    private static Dictionary<int, string> tiles = new Dictionary<int, string>()
    {
        { 0, "road_grass(33)" }, { 1, "block_grey(1)" }, { 2, "block_grey(2)" }, { 3, "block_grey(3)" }, { 4, "block_grey(4)" }, {5, "roof(11)"}, {6, "grass"}, {7, "road_grass(34)"}, {8, "road_grass(36)"}, {9, "Bitumen"}, {10, "road_grass(2)"}, {11, "road_grass(3)"}, {12, "road_grass(1)"}, {13, ""},
        { 15, "block_grey(15)" }, { 16, "path_tile" }
    };

    public static Dictionary<string, int> tilesFlip = tiles.ToDictionary(x => x.Value, x => x.Key);

    public static Tile GetByID(int ID)
    {
        return GetTile(tiles[ID]);
    }

    public static Tile GetByName(string name)
    {
      return GetTile(name);
    }

    public static int GetID(string tile)
    {
        return tilesFlip[tile];
    }

    private static Tile GetTile(string tile)
    {
        var tile_resource = (Tile) Resources.Load(tile, typeof(Tile));
        Console.WriteLine(tile_resource.ToString());
        return tile_resource;
    }
}
