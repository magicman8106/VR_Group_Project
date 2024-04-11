using System.Collections;
using UnityEngine;

public class KnifeInteraction : MonoBehaviour
{
    public GameObject completePig;
    public GameObject dissectedPig;

    // Optional for smoother visual transition
    public float transitionTime = 0.5f;

    private bool isDissected = false; // Flag to track dissection state

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pig") && !isDissected)
        {
            DissectPig();
        }
    }

    private void DissectPig()
    {
        // Option 1: Instant Swap
        completePig.SetActive(false);
        dissectedPig.SetActive(true);

        // Option 2: Fade Transition (Requires CanvasRenderer on models) 
        StartCoroutine(FadeTransition());

        isDissected = true;  // Update the dissection state flag
    }

    private IEnumerator FadeTransition()
    {
        CanvasRenderer intactRenderer = completePig.GetComponent<CanvasRenderer>();
        CanvasRenderer dissectedRenderer = dissectedPig.GetComponent<CanvasRenderer>();

        // Start with dissected pig invisible
        if (dissectedRenderer != null) dissectedRenderer.SetAlpha(0f);

        float timer = 0f;
        while (timer < transitionTime)
        {
            if (intactRenderer != null) intactRenderer.SetAlpha(1f - timer / transitionTime);
            if (dissectedRenderer != null) dissectedRenderer.SetAlpha(timer / transitionTime);

            timer += Time.deltaTime;
            yield return null;
        }

        completePig.SetActive(false); // Ensure intact model is fully hidden
    }
}
