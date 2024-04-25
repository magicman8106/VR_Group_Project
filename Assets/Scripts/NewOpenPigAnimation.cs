using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOpenPigAnimation : MonoBehaviour
{
    public GameObject pig;
    private OpenPig op;

    void Start()
    {
        op = pig.GetComponent<OpenPig>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        
    }

    

}
