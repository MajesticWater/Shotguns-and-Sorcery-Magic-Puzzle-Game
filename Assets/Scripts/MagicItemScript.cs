using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Components;

public class MagicItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponent<VRCPickup>().IsHeld && gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            Debug.Log("changed kinematic");
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
