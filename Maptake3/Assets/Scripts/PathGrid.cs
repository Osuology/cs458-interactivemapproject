using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathGrid : MonoBehaviour
{
    private List<MapData.TileData> tileData;
    private MapDataLoader mapDataLoader;
    private PathFinder pathFinder;

    private Vector3Int from = new Vector3Int(0, 0, 0), to = new Vector3Int(-7, -4, 0);

    private List<MapData.TileData> GetPathTileData()
    {
        List<MapData.TileData> pathData = new List<MapData.TileData>();

        pathFinder = new PathFinder();
        var path = pathFinder.PathFind(from, to);
        foreach (var pos in path)
        {
            pathData.Add(new MapData.TileData("path_tile", pathData.Count, TilesResourceLoader.GetID("path_tile"), new int[] { pos.x, pos.y, pos.z }));
        }

        return pathData;

        // Vector3Int current = from;
        //
        // pathData.Add(new MapData.TileData("path_tile", pathData.Count, TilesResourceLoader.GetID("path_tile"), new int[] { current.x, current.y, current.z }));
        // while (current.x != to.x)
        // {
        //     if (current.x < to.x)
        //     {
        //         current.x++;
        //     }
        //     else if (current.x > to.x)
        //     {
        //         current.x--;
        //     }
        //     pathData.Add(new MapData.TileData("path_tile", pathData.Count, TilesResourceLoader.GetID("path_tile"), new int[] { current.x, current.y, current.z }));
        // }
        //
        // while (current.y != to.y)
        // {
        //     if (current.y < to.y)
        //     {
        //         current.y++;
        //     }
        //     else if (current.y > to.y)
        //     {
        //         current.y--;
        //     }
        //     pathData.Add(new MapData.TileData("path_tile", pathData.Count, TilesResourceLoader.GetID("path_tile"), new int[] { current.x, current.y, current.z }));
        // }
        //
        // while (current.z != to.z)
        // {
        //     if (current.z < to.z)
        //     {
        //         current.z++;
        //     }
        //     else if (current.z > to.z)
        //     {
        //         current.z--;
        //     }
        //     pathData.Add(new MapData.TileData("path_tile", pathData.Count, TilesResourceLoader.GetID("path_tile"), new int[] { current.x, current.y, current.z }));
        // }
        //
        // return pathData;
    }

    void Start()
    {
        mapDataLoader = GetComponent<MapDataLoader>();
        tileData = GetPathTileData();
        pathFinder = new PathFinder();
        SetupPath();
    }

    private void SetupPath()
    {
        var baseLayer = GetComponentsInChildren<Tilemap>()[0];
        var tiles = new List<Vector3Int>();

        foreach (var tile in tileData)
        {
						var position = new Vector3Int(tile.Position[0], tile.Position[1], tile.Position[2]);
						print("Tile name: " + tile.Name + " | Pos: " + position);
            tiles.Add(position);
						baseLayer.SetTile(position, TilesResourceLoader.GetByID(tile.TileID));
        }
    }
}
