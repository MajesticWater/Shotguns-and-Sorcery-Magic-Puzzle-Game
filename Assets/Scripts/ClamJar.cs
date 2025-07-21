using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ClamJar : UdonSharpBehaviour
{
    public GameObject Jar;                      // The pickupable Jar object
    public Transform ClamObjectLocation;        // Target snap position for Jar
    public Animator Clam;                       // Animator on the Clam
    public GameObject Pearl;                    // Pearl to show after opening

    public float snapDistance = 0.2f;           // Snap trigger distance
    public float reopenDelay = 2.0f;            // Delay before clam reopens

    private bool hasSnapped = false;

    void Update()
    {
        if (hasSnapped || Jar == null || ClamObjectLocation == null)
            return;

        float dist = Vector3.Distance(Jar.transform.position, ClamObjectLocation.position);
        if (dist <= snapDistance)
        {
            SnapJar();
        }
    }

    private void SnapJar()
    {
        // Snap position & rotation
        Jar.transform.position = ClamObjectLocation.position;
        Jar.transform.rotation = ClamObjectLocation.rotation;

        // Disable pickup
        VRC_Pickup pickup = Jar.GetComponent<VRC_Pickup>();
        if (pickup != null)
        {
            pickup.pickupable = false;
        }

        // Close clam
        if (Clam != null)
        {
            Clam.SetTrigger("Close");
        }

        hasSnapped = true;

        // Schedule re-opening and showing pearl
        SendCustomEventDelayedSeconds(nameof(ReopenClam), reopenDelay);
    }

    public void ReopenClam()
    {
        if (Clam != null)
        {
            Clam.SetTrigger("Open"); // Animator will handle going to "clam open idle"
        }

        if (Pearl != null)
        {
            Pearl.SetActive(true);
        }
    }
}
