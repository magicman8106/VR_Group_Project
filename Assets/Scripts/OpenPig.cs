using System.Collections;
using System.Collections.Generic;
using UnityEditor.AI;
using UnityEngine;

public class OpenPig : MonoBehaviour
{
    public float animationDelay;

    private Animator anime;

    public GameObject uncutPig;
    public GameObject animePig;
    public GameObject cutPig;
    public GameObject lungPig;
    public GameObject heartPig;

    public GameObject[] openingTracer;
    public GameObject openingTracers;

    public GameObject[] lungTracer;
    public GameObject lungTracers;

    public GameObject heartTracer;

    private bool isCutOpen;
    private bool isLungOpen;
    private bool isHeartOpen;

    // Start is called before the first frame update
    void Start()
    {
        isCutOpen = false;
        isHeartOpen = false;
        isLungOpen = false;
    }

    private void Update()
    {
        if (!isCutOpen)
        {
            CheckForCut("open");
        }
        else if (!isLungOpen)
        {
            CheckForCut("lung");
        }
        else if(!isHeartOpen)
        {
            CheckForCut("heart");
        }
    }

    void CheckForCut(string type)
    {
        bool temp = true;
        switch (type)
        {
            case "open":
                for (int i = 0; i < openingTracer.Length; i++)
                {
                    if (openingTracer[i].GetComponent<MeshRenderer>().material.name == "Tracer - Uncut (Instance)")
                    {
                        temp = false;
                    }
                }
                if (temp)
                {
                    isCutOpen = true;
                    openingTracers.SetActive(false);
                    Switch();
                }
                break;
            case "lung":
                for (int i = 0; i < lungTracer.Length; i++)
                {
                    if (lungTracer[i].GetComponent<MeshRenderer>().material.name == "Tracer - Uncut (Instance)")
                    {
                        temp = false;
                    }
                }
                if (temp)
                {
                    isLungOpen = true;
                    CutLung();
                }
                break;
            case "heart":
                if(heartTracer.GetComponent<MeshRenderer>().material.name == "Tracer - Uncut (Instance)")
                {
                    temp = false;
                }
                if (temp)
                {
                    isHeartOpen = true;
                    CutHeart();
                }
                break;
        }
    }

    public void Open()
    {
        if(anime == null)
        {
            anime = animePig.GetComponent<Animator>();
        }
        anime.SetTrigger("trOpen");
        StartCoroutine(AnimationDelay());
    }

    IEnumerator AnimationDelay()
    {
        yield return new WaitForSeconds(animationDelay);
        animePig.SetActive(false);
        cutPig.SetActive(true);
        lungTracers.SetActive(true);

    }
    /*
    public void Close()
    {
        if(anime != null)
        {
            anime.SetTrigger("trClose");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tools")
        {
            Switch();
        }
    }
    */
    public void Switch()
    {
        uncutPig.SetActive(false);
        animePig.SetActive(true);
        Open();
    }

    public void CutLung()
    {
        cutPig.SetActive(false);
        lungPig.SetActive(true);
        lungTracers.SetActive(false);
        StartCoroutine(HeartDelay());
    }

    IEnumerator HeartDelay()
    {
        yield return new WaitForSeconds(1.5f);
        heartTracer.SetActive(true);
    }

    public void CutHeart()
    {
        heartTracer.SetActive(false);
        lungPig.SetActive(false);
        heartPig.SetActive(true);
    }
}

