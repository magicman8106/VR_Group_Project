using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Method to load the "Second Main Menu" scene
    public void LoadSecondMainMenu()
    {
        // Load the "Second Main Menu" scene
        SceneManager.LoadScene("Second Main Menu");
    }
}
