using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum Category { 
    Empty,
    Wall,
    Door,
    Gem,
    Path,
    Gate

}


[CreateAssetMenu(fileName = "Buildable", menuName = "BuildingObjects/Create Buildable")]
public class TileGeneric : Tile{

    [SerializeField] Category category;
    [SerializeField] TileBase tileBase;



    public TileBase TileBase {
        get {
            return tileBase;
        }
    
    }

    public Category Category {
        get {

            return category;
        }
        set {

            category = value;
        
        }
    
    
    }
   
}
