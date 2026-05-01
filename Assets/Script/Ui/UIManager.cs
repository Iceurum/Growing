using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

    [Header("Panels")]
    public GameObject questPanel;
    public GameObject helpPanel;

    [Header("Quest Text")]
    public TMP_Text turnipGoal;
    public TMP_Text potatoGoal;

    [Header("References")]
    public InventoryManager inventoryManager;

    private int turnipRequired = 10;
    private int potatoRequired = 5;

    private void Start() {
        questPanel.SetActive(false);
        helpPanel.SetActive(false);
    }

    public void ToggleQuest() {
        bool isOpen = questPanel.activeSelf;
        questPanel.SetActive(!isOpen);
        helpPanel.SetActive(false); // tutup help kalau quest dibuka
        if (!isOpen) UpdateQuestPanel();
    }

    public void ToggleHelp() {
        bool isOpen = helpPanel.activeSelf;
        helpPanel.SetActive(!isOpen);
        questPanel.SetActive(false); // tutup quest kalau help dibuka
    }

    public void CloseAll() {
        questPanel.SetActive(false);
        helpPanel.SetActive(false);
    }

    private void UpdateQuestPanel() {
        int turnip = inventoryManager.GetAmount("Turnip");
        int potato = inventoryManager.GetAmount("Potato");
        turnipGoal.text = "Turnip: " + turnip + "/" + turnipRequired;
        potatoGoal.text = "Potato: " + potato + "/" + potatoRequired;
    }
}
