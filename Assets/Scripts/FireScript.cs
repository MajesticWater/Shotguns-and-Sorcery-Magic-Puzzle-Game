
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class FireScript : UdonSharpBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;

        RegularFlowerScript rfs = obj.GetComponent<RegularFlowerScript>();
        if (rfs != null)
        {
            rfs.delete();
            return;
        }
        FireFlowerScript ffs = obj.GetComponent<FireFlowerScript>();
        if (ffs != null)
        {
            ffs.ignite();
        }
    }
}
