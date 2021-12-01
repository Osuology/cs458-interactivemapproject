using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// referenced from: https://pudding-entertainment.medium.com/unity-how-to-create-2d-tilemap-programmatically-afb1f94ffce5
public class TileGrid : MonoBehaviour
{
		private Dictionary<int, MapData.TileData> tileData;
		private MapDataLoader mapDataLoader;

		void Start()
		{
				mapDataLoader = GetComponent<MapDataLoader>();
				tileData = mapDataLoader.ReadTileData();
				SetupTiles();
		}

    private void SetupTiles()
    {
        var baseLayer = GetComponentsInChildren<Tilemap>()[0];
        var tiles = new List<Vector3Int>();

        foreach (var tile in tileData.Values)
        {
						var position = new Vector3Int(tile.Position[0], tile.Position[1], tile.Position[2]);
						print("Tile name: " + tile.Name + " | Pos: " + position);
            tiles.Add(position);
						baseLayer.SetTile(position, TilesResourceLoader.GetByID(tile.TileID));
        }
    }

}
