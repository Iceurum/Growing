using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public void PlayGame() {
        SceneManager.LoadScene("Farm");
    }

    public void ExitGame() {
        Application.Quit();
    }
}