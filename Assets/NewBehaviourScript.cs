using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        // Load the second main menu scene
        SceneManager.LoadScene("Second Main Menu");
    }
}
