using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHandInteraction : MonoBehaviour
{
    public GameObject ghosthand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Tool")
        {
            ghosthand.SetActive(false);
        }
    }
}
