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
        if (other.tag == "magic item" && !containsItem && !other.GetComponent<VRCPickup>().IsHeld)
        {
            containsItem = true;
            Debug.Log("detected magic item");
            logicManager.itemsFound++;
            other.GetComponent<Rigidbody>().isKinematic = true;
            //other.GetComponent <VRCPickup>().pickupable = false;
            other.transform.position = new Vector3(transform.position.x, transform.position.y + itemOffset, transform.position.z);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("spell item removed");
        containsItem = false;
        logicManager.itemsFound--;
    }
}
