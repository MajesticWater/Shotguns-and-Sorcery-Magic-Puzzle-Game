using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using VRC.SDK3.Components;

public class ItemDetector : MonoBehaviour
{
    [SerializeField] float itemOffset = 1;
    private bool containsItem = false;
    private LogicManager logicManager;

    private void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("logic manager").GetComponent<LogicManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<VRCPickup>() == null) return;
        if (!containsItem && !other.GetComponent<VRCPickup>().IsHeld)
        {
            GlowingItemScript gls = other.GetComponent<GlowingItemScript>();
            if (other.tag == "magic item" && (gls == null || gls.isGlowing()))
            {
                logicManager.itemsFound++;
                Debug.Log("detected spell component, items found is now: " + logicManager.itemsFound);
            }
            else
            {
                Debug.Log("item was not required");
            }
            containsItem = true;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = new Vector3(transform.position.x, transform.position.y + itemOffset, transform.position.z);

        }
        if (other.GetComponent<VRCPickup>().IsHeld && other.GetComponent<Rigidbody>().isKinematic)
        {
            Debug.Log("changed kinematic");
            other.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<VRCPickup>() == null) return;
        if (containsItem)
        {
            containsItem = false;
            GlowingItemScript gls = other.GetComponent<GlowingItemScript>();
            if (other.tag == "magic item" && (gls == null || gls.isGlowing()))
            {
                logicManager.itemsFound--;
                Debug.Log("items found is now: " + logicManager.itemsFound);
            }
        }
        if (other.GetComponent<VRCPickup>().IsHeld)
        {
            Debug.Log("changed kinematic");
            other.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
