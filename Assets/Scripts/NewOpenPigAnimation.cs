using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOpenPigAnimation : MonoBehaviour
{
    private Animator anime;
    private bool knifeTouching = false;
    private float touchDuration = 0.0f;
    public float requiredTouchTime = 1.0f; // Time in seconds

    void Start()
    {
        anime = GetComponent<Animator>();
    }

    void Update()
    {
        if (knifeTouching)
        {
            touchDuration += Time.deltaTime;
            if (touchDuration >= requiredTouchTime)
            {
                OpenPigModel(); // Call the opening function
                knifeTouching = false; // Reset for future use
                touchDuration = 0.0f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tool"))
        {
            knifeTouching = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Tool"))
        {
            knifeTouching = false;
            touchDuration = 0.0f; // Reset the timer
        }
    }

    void OpenPigModel()
    {
        if (anime != null)
        {
            anime.SetTrigger("trOpen"); 
        }
    }

}
