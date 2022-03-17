using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
    [SerializeField] TileGeneric item;
    Button button;

    BuildingCreator objectPlacer;

    private void Awake() {

        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClicked);
        objectPlacer = BuildingCreator.GetInstance();
    }

    private void ButtonClicked() {

        Debug.Log("Clicked" + item.name);
        objectPlacer.ObjectSelected(item);
    
    }
}
