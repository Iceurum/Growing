using UnityEngine;

public class FarmPlot : MonoBehaviour {

    [Header("Sprites")]
    public Sprite drySprite;
    public Sprite wetSprite;

    private SpriteRenderer sr;
    private Crop currentCrop;
    private bool isWatered;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    public bool IsEmpty() {
        return currentCrop == null;
    }

    public bool IsWatered() {
        return isWatered;
    }

    public void PlantCrop(GameObject cropPrefab) {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0f);
        GameObject obj = Instantiate(cropPrefab, spawnPos, Quaternion.identity);
        currentCrop = obj.GetComponent<Crop>();
        isWatered = false;
        UpdateSprite();
        Debug.Log("Benih ditanam!");
    }

    public void WaterCrop() {
        if (currentCrop != null) {
            isWatered = true;
            UpdateSprite();
            Debug.Log("Tanaman disiram!");
        }
    }

    public void OnTimeTick() {
        if (currentCrop != null && isWatered) {
            currentCrop.Grow();
        }
        isWatered = false;
        UpdateSprite();
    }

    public bool IsReady() {
        return currentCrop != null && currentCrop.IsReady();
    }

    public Crop GetCrop() {
        Crop harvested = currentCrop;
        Destroy(currentCrop.gameObject);
        currentCrop = null;
        isWatered = false;
        UpdateSprite();
        return harvested;
    }

    private void UpdateSprite() {
        if (sr == null) return;
        sr.sprite = isWatered ? wetSprite : drySprite;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().currentPlot = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().currentPlot = null;
        }
    }
}