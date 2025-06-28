using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darkZoneScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GlowingItemScript gls = other.GetComponent<GlowingItemScript>();
        if (gls != null )
        {
            gls.SetGlowing();
            Debug.Log("set to glowing");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GlowingItemScript gls = other.GetComponent<GlowingItemScript>();
        if (gls != null)
        {
            gls.SetDull();
            Debug.Log("set to dull");
        }
    }

}
