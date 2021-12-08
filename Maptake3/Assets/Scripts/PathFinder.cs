using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathFinder
{
    private Tilemap tilemap;

    private Queue<Vector3Int> queue = new Queue<Vector3Int>();

    private struct PathFindData
    {
        Queue<Vector3Int> queue;
        List<Vector3Int> path;
        string status;
    }

    public PathFinder()
    {
        tilemap = GameObject.Find("Floor0").GetComponent<Tilemap>();
    }

    public List<Vector3Int> PathFind(Vector3Int start, Vector3Int target)
    {
        List<Vector3Int> path = new List<Vector3Int>() {start};
        Queue<Vector3Int> right = RecurseFindQueue(start.x+1, start.y, start.z), left = RecurseFindQueue(start.x-1, start.y, start.z),
                              up = RecurseFindQueue(start.x, start.y+1, start.z), down = RecurseFindQueue(start.x, start.y-1, start.z);

        if (right.status == "finish")
        {
            path = right.path;
            return path;
        }
        else if (left.status == "finish")
        {
            path = left.path;
            return path;
        }
        else if (up.status == "finish")
        {
            path = up.path;
            return path;
        }
        else if (down.status == "finish")
        {
            path = down.path;
            return path;
        }
        else
        {
            if (!queue.Contains(right) && tilemap.GetSprite(right).name == "road_grass(33)" || tilemap.GetSprite(right).name == "road_grass(34)" || tilemap.GetSprite(right).name == "road_grass(36)")
            {
                queue.Enqueue(right);
            }
            if (!queue.Contains(left) && tilemap.GetSprite(left).name == "road_grass(33)" || tilemap.GetSprite(left).name == "road_grass(34)" || tilemap.GetSprite(left).name == "road_grass(36)")
            {
                queue.Enqueue(left);
            }
            if (!queue.Contains(up) && tilemap.GetSprite(up).name == "road_grass(33)" || tilemap.GetSprite(up).name == "road_grass(34)" || tilemap.GetSprite(up).name == "road_grass(36)")
            {
                queue.Enqueue(up);
            }
            if (!queue.Contains(down) && tilemap.GetSprite(down).name == "road_grass(33)" || tilemap.GetSprite(down).name == "road_grass(34)" || tilemap.GetSprite(down).name == "road_grass(36)")
            {
                queue.Enqueue(down);
            }

            return RecursePathFind(target);
        }

    }

    private PathFindData RecurseFindQueue(int x, int y, int z)
    {
        Vector3Int start = new Vector3Int(x, y, z);
    }

    private List<Vector3Int> RecursePathFind(Vector3Int target)
    {
        Vector3Int current = queue.Dequeue();
    }
}
