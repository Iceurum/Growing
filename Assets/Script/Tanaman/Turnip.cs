using UnityEngine;

// Turnip hanya bisa disiram, tidak perlu pupuk
public class Turnip : Crop, IWaterable {

    private void Start() {
        cropName    = "Turnip";
        hoursToGrow = 3;
    }

    public void Water() {
        Debug.Log(cropName + " disiram dengan air biasa.");
    }

    public override void Harvest() {
        Debug.Log("Panen " + cropName + "!");
    }
}
