using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHandMimicry : MonoBehaviour
{
    public Transform userHand; // Reference to the user's hand
    public GameObject scalpel; // Reference to the scalpel GameObject
    public GameObject pig; // Reference to the pig GameObject

    public float pickupDistance = 0.5f; // Maximum distance for picking up the scalpel

    private bool isScalpelPickedUp = false; // Flag to track if scalpel is picked up

    void Update()
    {
        // Check if the scalpel is picked up by the user's hand
        if (!isScalpelPickedUp && Vector3.Distance(userHand.position, scalpel.transform.position) < pickupDistance)
        {
            // If scalpel is picked up, set flag to true and trigger ghost hand actions
            isScalpelPickedUp = true;
            GhostHandActions();
        }
    }

    void GhostHandActions()
    {
        // Move ghost hand to the position and rotation of the scalpel
        transform.position = scalpel.transform.position;
        transform.rotation = scalpel.transform.rotation;

        // Simulate cutting action by moving ghost hand towards the pig
        // For demonstration, we'll simply log the action
        Debug.Log("Ghost hand picking up the scalpel.");

        // After picking up the scalpel, pretend to cut into the pig
        // For demonstration, we'll simply log the action
        Debug.Log("Ghost hand pretending to cut into the pig.");
    }
}
