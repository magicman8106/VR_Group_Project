using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivitySelectionController : MonoBehaviour
{
    public void OnActivity1ButtonClick()
    {
        SceneManager.LoadScene("Login");
    }

    public void OnActivity2ButtonClick()
    {
        SceneManager.LoadScene("Login");
    }
}