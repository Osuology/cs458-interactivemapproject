using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathFinder
{
    private Tilemap tilemap;

    private struct PathFindData
    {
        public List<Vector3Int> path;
        public string status;
        public Vector3Int target;

        public PathFindData(Vector3Int _target)
        {
            path = new List<Vector3Int>();
            status = "Valid";
            target = _target;
        }

        public void Add(Vector3Int addition)
        {
            path.Add(addition);
        }

        public Vector3Int Last()
        {
            return path[path.Count-1];
        }
    }
    private Queue<PathFindData> queue = new Queue<PathFindData>();
    private Dictionary<Vector3Int, bool> visited = new Dictionary<Vector3Int, bool>();

    public PathFinder()
    {
        tilemap = GameObject.Find("Floor0").GetComponent<Tilemap>();
    }

    public List<Vector3Int> PathFind(Vector3Int start, Vector3Int target)
    {
        var startTile = tilemap.GetSprite(start).name;
        var targetTile = tilemap.GetSprite(target).name;
        Debug.Log("");
        Debug.Log($"Start: {startTile}, Target: {targetTile}");
        Debug.Log("");
        if (!targetTile.StartsWith("road_grass") && targetTile != "Bitumen")
        {
            Debug.Log("Final target is unreachable!!");
        }
        PathFindData startPath = new PathFindData(target);
        startPath.Add(start);
        startPath.status = "Start";
        queue.Enqueue(startPath);

        while (queue.Count > 0)
        {
            PathFindData current = queue.Dequeue();

            PathFindData right = RecurseFindQueue(current, "right");
            if (right.status == "Target")
            {
                return right.path;
            }
            else if (right.status == "Valid")
            {
                queue.Enqueue(right);
            }

            PathFindData left = RecurseFindQueue(current, "left");
            if (left.status == "Target")
            {
                return left.path;
            }
            else if (left.status == "Valid")
            {
                queue.Enqueue(left);
            }

            PathFindData up = RecurseFindQueue(current, "up");
            if (up.status == "Target")
            {
                return up.path;
            }
            else if (up.status == "Valid")
            {
                queue.Enqueue(up);
                Debug.Log("Queueing Up Path!");
            }

            PathFindData down = RecurseFindQueue(current, "down");
            if (down.status == "Target")
            {
                return down.path;
            }
            else if (down.status == "Valid")
            {
                queue.Enqueue(down);
            }
        }

        Debug.Log("No valid Path Found!");
        return null;

    }

    private PathFindData RecurseFindQueue(PathFindData current, string direction)
    {
        List<Vector3Int> newPath = current.path;
        Vector3Int lastPos = newPath[newPath.Count-1];
        switch (direction)
        {
            case "right":
                Debug.Log("right");
                PathFindData rightPathFindData = current;
                rightPathFindData.Add(new Vector3Int(lastPos.x+1, lastPos.y, lastPos.z));
                rightPathFindData.status = FindLocationStatus(rightPathFindData);
                if (rightPathFindData.status == "Valid")
                {
                    visited.Add(rightPathFindData.Last(), true);
                }
                return rightPathFindData;
            case "left":
                Debug.Log("left");
                PathFindData leftPathFindData = current;
                leftPathFindData.Add(new Vector3Int(lastPos.x-1, lastPos.y, lastPos.z));
                leftPathFindData.status = FindLocationStatus(leftPathFindData);
                if (leftPathFindData.status == "Valid")
                {
                    visited.Add(leftPathFindData.Last(), true);
                }
                return leftPathFindData;
            case "up":
                Debug.Log("up");
                PathFindData upPathFindData = current;
                upPathFindData.Add(new Vector3Int(lastPos.x, lastPos.y+1, lastPos.z));
                upPathFindData.status = FindLocationStatus(upPathFindData);
                if (upPathFindData.status == "Valid")
                {
                    visited.Add(upPathFindData.Last(), true);
                }
                Debug.Log(upPathFindData.status);
                return upPathFindData;
            default:
                Debug.Log("down");
                PathFindData downPathFindData = current;
                downPathFindData.Add(new Vector3Int(lastPos.x, lastPos.y-1, lastPos.z));
                downPathFindData.status = FindLocationStatus(downPathFindData);
                if (downPathFindData.status == "Valid")
                {
                    visited.Add(downPathFindData.Last(), true);
                }
                return downPathFindData;
        }
    }

    private string FindLocationStatus(PathFindData pathFind)
    {
        Vector3Int pos = pathFind.Last();
        Vector3Int target = pathFind.target;

        Debug.Log($"Current: {pos.ToString()}, Target: {target}");

        var tileName = tilemap.GetSprite(pos).name;

        if (pos == target)
        {
            return "Target";
        }
        else if (visited.ContainsKey(pos))
        {
            return "Visited";
        }
        else if (tileName.StartsWith("road_grass") || tileName == "Bitumen")
        {
            return "Valid";
        }
        else
        {
            Debug.Log($"Tile is invalid: {tilemap.GetSprite(pos).name}");
            return "Invalid";
        }
    }
}
