using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

    [Header("References")]
    public InventoryManager inventoryManager;
    public InputActionAsset inputActions;

    [Header("Seed Prefabs")]
    // Tambah prefab biji baru cukup drag ke list ini di Inspector
    public List<GameObject> seedPrefabs = new List<GameObject>();

    [HideInInspector] public FarmPlot currentPlot;

    private int selectedIndex = 0;
    private GameObject selectedCropPrefab => 
        seedPrefabs.Count > 0 ? seedPrefabs[selectedIndex] : null;

    private InputAction switchSeedAction;

    private void Awake() {
        var playerMap   = inputActions.FindActionMap("Player", throwIfNotFound: true);
        switchSeedAction = playerMap.FindAction("SwitchSeed", throwIfNotFound: true);
    }

    private void OnEnable() {
        switchSeedAction.Enable();
        switchSeedAction.performed += HandleSwitchSeed;
    }

    private void OnDisable() {
        switchSeedAction.performed -= HandleSwitchSeed;
        switchSeedAction.Disable();
    }

    private void HandleSwitchSeed(InputAction.CallbackContext ctx) {
        if (seedPrefabs.Count == 0) return;
        selectedIndex = (selectedIndex + 1) % seedPrefabs.Count;
        Debug.Log("Benih dipilih: " + selectedCropPrefab.name);
    }

    // Dipanggil oleh PlayerInput.onInteract via UnityEvent
    public void OnInteract() {
        if (currentPlot == null) return;

        if (currentPlot.IsReady()) {
            Harvest();
        } else if (!currentPlot.IsEmpty() && !currentPlot.IsWatered()) {
            Water();
        } else if (currentPlot.IsEmpty()) {
            Plant(selectedCropPrefab);
        }
    }

    public void Plant(GameObject cropPrefab) {
        if (cropPrefab == null) {
            Debug.LogWarning("Tidak ada benih yang dipilih!");
            return;
        }
        currentPlot.PlantCrop(cropPrefab);
        Debug.Log("Menanam " + cropPrefab.name);
    }

    public void Water() {
        currentPlot.WaterCrop();
        Debug.Log("Menyiram tanaman");
    }

    public void Harvest() {
        Crop crop = currentPlot.GetCrop();
        crop.Harvest();
        inventoryManager.AddItem(crop.cropName, 1);
        Debug.Log("Memanen " + crop.cropName);
    }
}
