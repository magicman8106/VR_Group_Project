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
        //Debug.Log(other.tag);
        if(other.transform.tag == "Tools")
        {
            ghosthand.SetActive(false);
        }
    }
}
