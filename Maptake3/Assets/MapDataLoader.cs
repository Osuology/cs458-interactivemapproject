using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

// referenced from: https://pudding-entertainment.medium.com/unity-how-to-create-2d-tilemap-programmatically-afb1f94ffce5
public class MapDataLoader : MonoBehaviour
{
		private const string mapPath = "Map";

    public Dictionary<int, MapData.TileData> ReadTileData()
    {
        var jsonFile = Resources.Load(mapPath, typeof(TextAsset)) as TextAsset;
        if (jsonFile == null)
        {
            Debug.LogError($"JSON file ({mapPath}) was not found.");
        }

        var loadedData = JsonUtility.FromJson<MapData>(jsonFile.text);
        return loadedData.baseLayer.ToDictionary(tile => tile.ID);
    }
}
