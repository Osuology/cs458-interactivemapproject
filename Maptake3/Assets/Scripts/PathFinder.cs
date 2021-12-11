using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathFinder
{
    private Tilemap tilemap;

    private class PathFindData
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

        // Necessary for fixing Lists using pointers to store their data
        public void ClonePath(List<Vector3Int> list)
        {
            foreach (var pos in list)
            {
                path.Add(pos);
            }
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
    private List<PathFindData> queue = new List<PathFindData>();
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
            Debug.Log($"Final target ({targetTile}) is unreachable!!");
        }
        PathFindData startPath = new PathFindData(target);
        startPath.Add(start);
        startPath.status = "Start";
        queue.Add(startPath);

        while (queue.Count > 0)
        {
            PathFindData current = queue[0];

            PathFindData right = RecurseFindQueue(current, "right");
            if (right.status == "Target")
            {
                return right.path;
            }
            else if (right.status == "Valid")
            {
                queue.Add(right);
                Debug.Log("Queueing Right Path!");
            }

            Debug.Log($"Current.Last = {current.Last()}");
            PathFindData left = RecurseFindQueue(current, "left");
            Debug.Log($"Current.Last = {current.Last()}");
            if (left.status == "Target")
            {
                return left.path;
            }
            else if (left.status == "Valid")
            {
                queue.Add(left);
                Debug.Log("Queueing Left Path!");
            }

            Debug.Log($"Current.Last = {current.Last()}");

            PathFindData up = RecurseFindQueue(current, "up");
            if (up.status == "Target")
            {
                return up.path;
            }
            else if (up.status == "Valid")
            {
                queue.Add(up);
                Debug.Log("Queueing Up Path!");
            }

            PathFindData down = RecurseFindQueue(current, "down");
            if (down.status == "Target")
            {
                return down.path;
            }
            else if (down.status == "Valid")
            {
                queue.Add(down);
                Debug.Log("Queueing Down Path!");
            }

            queue.RemoveAt(0);
        }

        Debug.Log("No valid Path Found!");
        return null;

    }

    private PathFindData RecurseFindQueue(PathFindData current, string direction)
    {
        Vector3Int lastPos = current.Last();
        Debug.Log($"NEW ADD: RecurseFindQueue lastPos: {lastPos}");
        PathFindData currentClone = new PathFindData(current.target);
        currentClone.ClonePath(current.path);
        currentClone.status = current.status;
        if (lastPos.x >= 100 || lastPos.y >= 100)
        {
            PathFindData invalidPathFindData = currentClone;
            invalidPathFindData.status = "Invalid";

            return invalidPathFindData;
        }
        else {
            switch (direction)
            {
                case "right":
                    Debug.Log("right");
                    PathFindData rightPathFindData = currentClone;
                    rightPathFindData.Add(new Vector3Int(lastPos.x+1, lastPos.y, lastPos.z));
                    rightPathFindData.status = FindLocationStatus(rightPathFindData);
                    if (rightPathFindData.status == "Valid")
                    {
                        visited.Add(rightPathFindData.Last(), true);
                    }
                    return rightPathFindData;
                case "left":
                    Debug.Log("left");
                    PathFindData leftPathFindData = currentClone;
                    Debug.Log($"NEW ADD 2: RecurseFindQueue lastPos: {current.Last()}");
                    leftPathFindData.Add(new Vector3Int(lastPos.x-1, lastPos.y, lastPos.z));
                    Debug.Log($"NEW ADD 3: RecurseFindQueue lastPos: {current.Last()}");
                    Debug.Log($"NEW ADD 5: RecurseFindQueue lastPos: {leftPathFindData.Last()}");
                    Debug.Log($"lastPos: {lastPos}  |  Last: {leftPathFindData.Last()}");
                    Debug.Log($"Path: {leftPathFindData.path}");
                    leftPathFindData.status = FindLocationStatus(leftPathFindData);
                    if (leftPathFindData.status == "Valid")
                    {
                        visited.Add(leftPathFindData.Last(), true);
                    }
                    return leftPathFindData;
                case "up":
                    Debug.Log("up");
                    PathFindData upPathFindData = currentClone;
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
                    PathFindData downPathFindData = currentClone;
                    downPathFindData.Add(new Vector3Int(lastPos.x, lastPos.y-1, lastPos.z));
                    downPathFindData.status = FindLocationStatus(downPathFindData);
                    if (downPathFindData.status == "Valid")
                    {
                        visited.Add(downPathFindData.Last(), true);
                    }
                    return downPathFindData;
            }
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
