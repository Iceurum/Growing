using UnityEngine;

public class Player : MonoBehaviour, IPlant, IWater, IHarvest {
    
    public InventoryManager inventoryManager;
    public Crop turnipCrop;
    public Crop potatoCrop;
    public FarmPlot currentPlot;
    private Crop selectedCrop;

    private void Start() {
        selectedCrop = turnipCrop;
    }

    private void Update() {
        // Ganti benih
        if (Input.GetKeyDown(KeyCode.Q)) {
            selectedCrop = selectedCrop == turnipCrop ? potatoCrop : turnipCrop;
            Debug.Log("Benih dipilih: " + selectedCrop.name);
        }
    }

    public void OnInteract() {
        if (currentPlot == null) return;

        if (currentPlot.IsReady()) {
            Harvest();
        } else if (!currentPlot.IsEmpty() && !currentPlot.IsWatered()) {
            Water();
        } else if (currentPlot.IsEmpty()) {
            Plant(selectedCrop);
        }
    }

    public void Plant(Crop crop) {
        currentPlot.PlantCrop(crop);
        Debug.Log("Menanam " + crop.name);
    }

    public void Water() {
        currentPlot.WaterCrop();
        Debug.Log("Menyiram tanaman");
    }

    public void Harvest() {
        Crop crop = currentPlot.GetCrop();
        crop.Harvest();
        inventoryManager.AddItem(crop.name, 1);
        Debug.Log("Memanen " + crop.name);
    }
}