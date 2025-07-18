
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class MagicItemScript : UdonSharpBehaviour
{
    public override void OnPickup()
    {
        if (gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
