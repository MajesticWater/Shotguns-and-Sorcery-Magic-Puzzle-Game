using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ClamObjectLocation : UdonSharpBehaviour
{
    [Header("Reference to the target snap location")]
    public Transform clamObjectLocation;

    [Header("Distance threshold to snap")]
    public float snapDistance = 0.3f;

    [Header("Should it match the target rotation?")]
    public bool snapRotation = true;

    private VRC_Pickup pickup;

    void Start()
    {
        pickup = (VRC_Pickup)GetComponent(typeof(VRC_Pickup));
    }

    public override void OnDrop()
    {
        if (clamObjectLocation == null) return;

        float distance = Vector3.Distance(transform.position, clamObjectLocation.position);

        if (distance <= snapDistance)
        {
            // Snap the jar's position
            transform.position = clamObjectLocation.position;

            // Optionally snap rotation
            if (snapRotation)
            {
                transform.rotation = clamObjectLocation.rotation;
            }

            // Disable pickup to prevent further grabbing if desired
            // pickup.pickupable = false;
        }
    }
}
