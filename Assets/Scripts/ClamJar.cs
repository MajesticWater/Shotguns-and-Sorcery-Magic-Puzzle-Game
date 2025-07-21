using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ClamJar : UdonSharpBehaviour
{
    public GameObject Jar;                      // Reference to the Jar
    public Transform ClamObjectLocation;        // Where the Jar should snap to
    public Animator Clam;                       // Animator controller on Clam
    public GameObject Pearl;                    // The Pearl that appears after

    public float snapDistance = 0.2f;           // How close the Jar must be
    public float reopenDelay = 2.0f;            // Delay before clam reopens

    private bool hasSnapped = false;

    private void Update()
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
        // Snap position and rotation
        Jar.transform.position = ClamObjectLocation.position;
        Jar.transform.rotation = ClamObjectLocation.rotation;

        // Disable pickup (optional)
        VRC_Pickup pickup = Jar.GetComponent<VRC_Pickup>();
        if (pickup != null)
        {
            pickup.pickupable = false;
        }

        // Trigger clam to close
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
            Clam.SetTrigger("Open");
        }

        if (Pearl != null)
        {
            Pearl.SetActive(true);
        }
    }
}
