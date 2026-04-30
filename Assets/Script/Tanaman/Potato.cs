using UnityEngine;

// Potato bisa disiram dan dikasih pupuk
public class Potato : Crop, IWaterable, IFertilizable {

    [Header("Sprites")]
    public Sprite[] growthSprites; // 0=baru tanam, 1-4=tumbuh, 5=siap panen

    private SpriteRenderer sr;

    private void Start() {
        cropName    = "Potato";
        hoursToGrow = 5;

        sr = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    public override void Grow() {
        base.Grow();
        UpdateSprite();
    }

    private void UpdateSprite() {
        if (sr == null || growthSprites == null || growthSprites.Length == 0) return;

        int index = Mathf.Clamp(currentHour, 0, growthSprites.Length - 1);
        sr.sprite = growthSprites[index];
    }

    public void Water() {
        Debug.Log(cropName + " disiram!");
    }

    // Fertilize mempercepat pertumbuhan 1 jam
    public void Fertilize() {
        if (!IsReady()) {
            currentHour++;
            UpdateSprite();
            Debug.Log(cropName + " dipupuk! Jam sekarang: " + currentHour + "/" + hoursToGrow);
        }
    }

    public override void Harvest() {
        Debug.Log("Panen " + cropName + "!");
    }
}
