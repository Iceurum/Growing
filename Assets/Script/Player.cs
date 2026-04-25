using UnityEngine;

public class Player : MonoBehaviour, IPlant, IWater, IHarvest {
    

    public Crop cropToPlant; // assign di Inspector
    public FarmPlot currentPlot;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && currentPlot != null) {
            if (currentPlot.IsReady()) {
                Harvest();
            } else if (!currentPlot.IsEmpty() && !currentPlot.IsWatered()) {
                Water();
            } else if (currentPlot.IsEmpty()) {
                Plant(cropToPlant);
            }
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
        Debug.Log("Memanen " + crop.name);
    }
}