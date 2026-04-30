using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour {

    [Header("Seed")]
    public Image seedIcon;
    public TMP_Text seedName;
    public Sprite[] seedSprites;

    [Header("Fertilizer")]
    public Image fertilizerIcon;
    public TMP_Text fertilizerCount;

    [Header("Inventory")]
    public Image turnipIcon;
    public TMP_Text turnipCount;
    public Image potatoIcon;
    public TMP_Text potatoCount;

    [Header("References")]
    public Player player;
    public InventoryManager inventoryManager;

    private void Update() {
        UpdateSeed();
        UpdateFertilizer();
        UpdateInventory();
    }

    private void UpdateSeed() {
        if (seedSprites != null && seedSprites.Length > player.SelectedIndex) {
            seedIcon.sprite = seedSprites[player.SelectedIndex];
        }
        if (player.selectedCropPrefab != null) {
            seedName.text = player.selectedCropPrefab.name;
        }
    }

    private void UpdateFertilizer() {
        fertilizerCount.text = "x" + player.fertilizerStock;
    }

    private void UpdateInventory() {
        turnipCount.text = "x" + inventoryManager.GetAmount("Turnip");
        potatoCount.text = "x" + inventoryManager.GetAmount("Potato");
    }
}