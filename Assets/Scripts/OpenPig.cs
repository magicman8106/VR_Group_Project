using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPig : MonoBehaviour
{
    private Animator anime;

    public GameObject uncutPig;
    public GameObject cutPig;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Open()
    {
        if(anime == null)
        {
            anime = cutPig.GetComponent<Animator>();
        }
        anime.SetTrigger("trOpen");
    }
    /*
    public void Close()
    {
        if(anime != null)
        {
            anime.SetTrigger("trClose");
        }
    }
    */
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tools")
        {
            Switch();
        }
    }
    public void Switch()
    {
        uncutPig.SetActive(false);
        cutPig.SetActive(true);
        Open();
    }
}

