using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour {

    [Header("Win Popup Panel")]
    public GameObject winPanel;

    public void ShowWinPanel() {
        winPanel.SetActive(true);
        Time.timeScale = 0f; // pause game
    }

    public void BackToMainMenu() {
        Time.timeScale = 1f; // reset time scale
        SceneManager.LoadScene("MainMenu");
    }
}
