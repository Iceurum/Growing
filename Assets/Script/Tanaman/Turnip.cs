using UnityEngine;

public class Turnip : Crop, IWaterable {

    [Header("Sprites")]
    public Sprite[] growthSprites; // 0=baru tanam, 1=hour1, 2=hour2, 3=siap panen

    private SpriteRenderer sr;

    private void Start() {
        cropName    = "Turnip";
        hoursToGrow = 3;

        sr = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    public override void Grow() {
        base.Grow();
        Debug.Log("Grow dipanggil! currentHour: " + currentHour);
        UpdateSprite();
    }

    private void UpdateSprite() {
        int index = Mathf.Clamp(currentHour, 0, growthSprites.Length - 1);
        Debug.Log("UpdateSprite index: " + index + " sprite: " + growthSprites[index]);
        sr.sprite = growthSprites[index];
    }

    public void Water() {
        Debug.Log(cropName + " disiram!");
    }

    public override void Harvest() {
        Debug.Log("Panen " + cropName + "!");
    }
}
