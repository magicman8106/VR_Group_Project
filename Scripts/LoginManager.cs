using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public InputField inputField;

    public void LoadNextScene()
    {
        string input = inputField.text;

        // Check if the input is correct (for example, if it's "1111")
        if (input == "1111")
        {
            // Load the next scene
            SceneManager.LoadScene("NextSceneName");
        }
        else
        {
            Debug.Log("Incorrect input. Please try again."); // Or display an error message
        }
    }

    public void SubmitButtonClicked()
    {
        LoadNextScene();
    }
}
