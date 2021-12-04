using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class ExportButton : MonoBehaviour
{
    Button button;
    Tilemap tilemap;

    private MapDataExporter dataExporter;

    void Start()
    {
        button = GameObject.Find("ExportButton").GetComponent<Button>();
        tilemap = GameObject.Find("Floor0").GetComponent<Tilemap>();
        dataExporter = new MapDataExporter();

        button.onClick.AddListener(() => ExportMap(tilemap));
    }

    void ExportMap(Tilemap tilemap)
    {
        if (dataExporter.ExportToJson(tilemap))
        {
            print("Map successfully exported!");
        }
        else
        {
            print("Error exporting");
        }
    }
}
