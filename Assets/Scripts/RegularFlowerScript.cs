
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RegularFlowerScript : UdonSharpBehaviour
{
    public void delete()
    {
        Destroy(gameObject);
    }

    public override void OnPickup()
    {
        if (gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
