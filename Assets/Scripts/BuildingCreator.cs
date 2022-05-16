using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class BuildingCreator : Singleton<BuildingCreator> {
    [SerializeField] Tilemap previewMap,
    defaultMap;
    PlayerInput playerInput;

    TileBase tileBase;
    TileGeneric selectedObj;

    Camera _camera;

    Vector2 mousePos;
    Vector3Int currentGridPosition;
    Vector3Int lastGridPosition;

    protected override void Awake () {
        base.Awake ();
        playerInput = new PlayerInput ();
        _camera = Camera.main;
    }

    private void OnEnable () {
        playerInput.Enable ();

        playerInput.Gameplay.MousePosition.performed += OnMouseMove;
        playerInput.Gameplay.MouseLeftClick.performed += OnLeftClick;
        playerInput.Gameplay.MouseRightClick.performed += OnRightClick;
    }

    private void OnDisable () {
        playerInput.Disable ();

        playerInput.Gameplay.MousePosition.performed -= OnMouseMove;
        playerInput.Gameplay.MouseLeftClick.performed -= OnLeftClick;
        playerInput.Gameplay.MouseRightClick.performed -= OnRightClick;
    }

    private TileGeneric SelectedObj {
        set {
            selectedObj = value;

            tileBase = selectedObj != null ? selectedObj.TileBase : null;

            UpdatePreview ();
        }
    }

    private void Update () {
        // if something is selected - show preview
        if (selectedObj != null) {
            Vector3 pos = _camera.ScreenToWorldPoint (mousePos);
            Vector3Int gridPos = previewMap.WorldToCell (pos);

            if (gridPos != currentGridPosition) {
                lastGridPosition = currentGridPosition;
                currentGridPosition = gridPos;

                UpdatePreview ();
            }
        }
    }

    private void OnMouseMove (InputAction.CallbackContext ctx) {
        mousePos = ctx.ReadValue<Vector2> ();
    }

    private void OnLeftClick (InputAction.CallbackContext ctx) {
        if (selectedObj != null && !EventSystem.current.IsPointerOverGameObject()) {
            Debug.Log("Clicked");
            HandleDrawing ();
        }
    }

    private void OnRightClick (InputAction.CallbackContext ctx) {
        SelectedObj = null;
    }

    public void ObjectSelected (TileGeneric obj) {
        SelectedObj = obj;
    }

    private void UpdatePreview () {

        previewMap.SetTile (lastGridPosition, null);
       
        previewMap.SetTile (currentGridPosition, tileBase);
    }

    private void HandleDrawing () {
        DrawItem ();
    }

    private void DrawItem () {
        // TODO: automatically select tilemap
        defaultMap.SetTile (currentGridPosition, tileBase);
        //defaultMap.SetTile(currentGridPosition, selectedObj);

        //Create a 2D array, the size of the tileset, and add the /tileGeneric/

    }

}