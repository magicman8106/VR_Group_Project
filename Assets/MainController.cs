using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        // Load the second main menu scene
        SceneManager.LoadScene("Second Main Menu");
    }
}

