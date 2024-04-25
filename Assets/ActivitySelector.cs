using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivitySelector : MonoBehaviour
{
    public void OnActivity1ButtonClick()
    {
        SceneManager.LoadScene("Activity 1");
    }

    public void OnActivity2ButtonClick()
    {
        SceneManager.LoadScene("Activity 2");
    }
}
