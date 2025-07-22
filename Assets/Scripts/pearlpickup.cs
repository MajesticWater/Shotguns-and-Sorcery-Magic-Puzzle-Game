using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class pearlpickup : UdonSharpBehaviour
{
    private Rigidbody rb;
    private bool gravityEnabled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Start with gravity off
        if (rb != null)
        {
            rb.useGravity = false;
        }
    }

    public override void OnPickup()
    {
        if (!gravityEnabled && rb != null)
        {
            rb.useGravity = true;
            gravityEnabled = true;
        }
    }
}
