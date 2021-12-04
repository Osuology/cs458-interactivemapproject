using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDataExporter
{
    public string TilemapToJSON(Tilemap tilemap)
    {
        var bounds = tilemap.cellBounds;

        var tiles = tilemap.GetTilesBlock(bounds);

        var size = tilemap.size;
        MapData exportMap = new MapData();
        List<MapData.TileData> baseLayer = new List<MapData.TileData>();
        string str = "";
        int id = 0;
        for (int x = bounds.xMin; x < bounds.xMax; ++x)
        {
            for (int y = bounds.yMin; y < bounds.yMax; ++y)
            {
                for (int z = bounds.zMin; z < bounds.zMax; ++z)
                {
                    var pos = new Vector3Int(x, y, z);
                    var sprite = tilemap.GetSprite(pos);
                    var tile = tilemap.GetTile(pos);
                    Debug.Log($"X: {x}\nBounds: {bounds.xMin}");

                    if (tile != null && sprite != null)
                    {
                        Debug.Log(sprite.name);
                        Debug.Log($"Sprite Name: {sprite.name}");
                        Debug.Log($"Position: {pos}");
                        Debug.Log($"ID: {(x-bounds.xMin)+((y-bounds.yMin)*size.y)+((z-bounds.zMin)*size.z)}");
                        MapData.TileData tileData = new MapData.TileData("mapTile", id, TilesResourceLoader.GetID(sprite.name), new int[] { x, y, z });
                        baseLayer.Add(tileData);
                        id++;
                    }
                }
            }
        }

        exportMap.baseLayer = baseLayer.ToArray();
        var addStr = JsonUtility.ToJson(exportMap, true);
        Debug.Log(addStr);
        str += addStr;

        return str;
    }

    public bool ExportToJson(Tilemap tilemap)
    {
        string exportJson = TilemapToJSON(tilemap);
        File.WriteAllText("Map-export-" + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + ".json", exportJson);
        return true;
    }
}
