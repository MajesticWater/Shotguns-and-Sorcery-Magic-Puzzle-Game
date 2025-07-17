
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ColorChangeScript : UdonSharpBehaviour
{
    [SerializeField] Material butterflyMat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Butterfly Bowl")
        {
            other.GetComponent<ButterflyBowlScript>().setColor(butterflyMat);
        }
    }
}
