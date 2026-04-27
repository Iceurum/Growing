using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IPlant, IWater, IHarvest
{
    
    public InventoryManager inventoryManager;
    public GameObject turnipCropPrefab;
    public GameObject potatoCropPrefab;
    
    [HideInInspector] public FarmPlot currentPlot;
    private GameObject selectedCropPrefab;

    private void Start() {
        selectedCropPrefab = turnipCropPrefab;
    }

    private void Update() {
        if (Keyboard.current.qKey.wasPressedThisFrame) {
            selectedCropPrefab = selectedCropPrefab == turnipCropPrefab ? potatoCropPrefab : turnipCropPrefab;
            Debug.Log("Benih dipilih: " + selectedCropPrefab.name);
        }
    }

    public void OnInteract() {
        Debug.Log("OnInteract dipanggil! currentPlot: " + currentPlot);
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
        currentPlot.PlantCrop(cropPrefab);
        Debug.Log("Menanam " + cropPrefab.name);
    }
    public void Water() {
        currentPlot.WaterCrop();
        Debug.Log("Menyiram tanaman");
    }

    public void Harvest() {
        Crop crop = currentPlot.GetCrop();
        string cropName = crop.name; 
        crop.Harvest();
        inventoryManager.AddItem(crop.name, 1);
        Debug.Log("Memanen " + crop.name);
    }
}