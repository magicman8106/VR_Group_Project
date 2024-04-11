using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPig : MonoBehaviour
{
    private Animator anime;
    
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Open()
    {
        if(anime != null)
        {
            anime.SetTrigger("trOpen");
        }
    }

    void Close()
    {
        if (anime != null)
        {
            anime.SetTrigger("trClose");
        }
    }
}
