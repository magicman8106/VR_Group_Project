using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader1 : MonoBehaviour
{
    // Method to load the "Login" scene
    public void LoadLogin()
    {
        // Load the "Login" scene
        SceneManager.LoadScene("Login");
    }
}


