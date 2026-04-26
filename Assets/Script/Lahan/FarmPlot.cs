using UnityEngine;

public class FarmPlot : MonoBehaviour {
    
    private Crop currentCrop;
    private bool isWatered;

    public bool IsEmpty() {
        return currentCrop == null;
    }

    public bool IsWatered() {
        return isWatered;
    }

    public void PlantCrop(Crop crop) {
        currentCrop = crop;
        isWatered = false;
        Debug.Log("Benih ditanam!");
    }

    public void WaterCrop() {
        if (currentCrop != null) {
            isWatered = true;
            Debug.Log("Tanaman disiram!");
        }
    }

    public void OnTimeTick() {
        if (currentCrop != null && isWatered) {
            currentCrop.Grow();
        }
        isWatered = false;
    }

    public bool IsReady() {
        return currentCrop != null && currentCrop.IsReady();
    }

    public Crop GetCrop() {
        Crop harvested = currentCrop;
        currentCrop = null;
        isWatered = false;
        return harvested;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().currentPlot = this;
            Debug.Log("Player mendekati lahan");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().currentPlot = null;
            Debug.Log("Player meninggalkan lahan");
        }
    }
}