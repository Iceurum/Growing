using UnityEngine;

// Potato bisa disiram dan dikasih pupuk
public class Potato : Crop, IWaterable, IFertilizable {

    private void Start() {
        cropName    = "Potato";
        hoursToGrow = 5;
    }

    public void Water() {
        Debug.Log(cropName + " disiram dengan air biasa.");
    }

    // Fertilize mempercepat pertumbuhan 1 jam
    public void Fertilize() {
        if (!IsReady()) {
            currentHour++;
            Debug.Log(cropName + " dipupuk! Jam sekarang: " + currentHour + "/" + hoursToGrow);
        }
    }

    public override void Harvest() {
        Debug.Log("Panen " + cropName + "!");
    }
}
