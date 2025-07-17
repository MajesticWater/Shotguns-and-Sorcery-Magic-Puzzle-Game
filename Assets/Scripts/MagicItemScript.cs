
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class MagicItemScript : UdonSharpBehaviour
{
    void Update()
    {
        if (GetComponent<VRCPickup>().IsHeld && GetComponent<Rigidbody>().isKinematic)
        {
            Debug.Log("changed kinematic");
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
