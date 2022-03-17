using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
using System;
using System.Text;
using System.Runtime.InteropServices;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TileMapExporter : MonoBehaviour
{
    [SerializeField] Tilemap map;

    [DllImport("__Internal")]
    private static extern void send(String csv);



    public void export() {

        String file = saveMap(map);
        send(file);
    
    }

    public String saveMap(Tilemap map) {

        //StreamWriter writer = new StreamWriter(getPath());
        var sb = new StringBuilder();

        Vector3Int size = map.size;
        int width = size.x;

        int progress = 1;

        foreach (var pos in map.cellBounds.allPositionsWithin) {
            if (map.HasTile(pos)) {

                

                
                TileBase levelTile = map.GetTile<TileBase>(pos);

                //writer.Write(levelTile.name + ",");
                sb.Append(levelTile.name + ",");
            }
            else {
                //writer.Write("Empty" + ",");
                sb.Append("" + ",");

            }

            if (progress == width) {

                //writer.Write("\n");
                sb.Append("\n");
                progress = 1;

            }
            else {

                progress++;
            
            }

            
        
        }

        return sb.ToString();
        //writer.Flush();
        //writer.Close();
        //Debug.Log("Exported");

    }

    public void saveToFile(String map) {

        // Use the CSV generation from before
        var content = map;

        // The target file path e.g.
    #if UNITY_EDITOR
    var folder = Application.streamingAssetsPath;

    if(! Directory.Exists(folder)) Directory.CreateDirectory(folder);
    #else
        var folder = Application.persistentDataPath;
    #endif

        var filePath = Path.Combine(folder, "export.csv");

        using (var writer = new StreamWriter(filePath, false)) {
            writer.Write(content);
        }

        // Or just
        //File.WriteAllText(content);

        Debug.Log($"CSV file written to \"{filePath}\"");

    #if UNITY_EDITOR
    AssetDatabase.Refresh();
    #endif




    }

    public string getPath() {

        return Application.dataPath + "/export/" + "savedLevel.csv";
    
    
    }
}
