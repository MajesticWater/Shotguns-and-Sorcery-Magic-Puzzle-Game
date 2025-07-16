using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using VRC.SDK3.Components;

public class ItemDetector : MonoBehaviour
{
    [SerializeField] float itemOffset = 1;
    private bool containsItem = false;
    private bool containsMagicItem = false;
    private LogicManager logicManager;

    private void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("logic manager").GetComponent<LogicManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<VRCPickup>() == null) return;
        if (!other.GetComponent<VRCPickup>().IsHeld)
        {
            if (!containsItem)
            {
                GlowingItemScript gls = other.GetComponent<GlowingItemScript>();
                ButterflyScript bfs = other.GetComponent<ButterflyScript>();
                if (other.tag == "magic item" && (gls == null || gls.isGlowing()) && (bfs == null || bfs.isCorrectColor()))
                {
                    increaseMagicCount();
                }
                else
                {
                    Debug.Log("item was not required");
                }
                containsItem = true;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = new Vector3(transform.position.x, transform.position.y + itemOffset, transform.position.z);
            } else
            {
                GlowingItemScript gls = other.GetComponent<GlowingItemScript>();
                if (gls != null)
                {
                    if (gls.isGlowing())
                    {
                        increaseMagicCount();
                    } else
                    {
                        decreaseMagicCount();
                    }
                    
                }

            }
            

        }

        if (other.GetComponent<VRCPickup>().IsHeld && other.GetComponent<Rigidbody>().isKinematic)
        {
            //Debug.Log("changed kinematic");
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
            ButterflyScript bfs = other.GetComponent<ButterflyScript>();
            if (other.tag == "magic item" && (gls == null || gls.isGlowing()) && (bfs == null || bfs.isCorrectColor()))
            {
                decreaseMagicCount();
            }
        }
        if (other.GetComponent<VRCPickup>().IsHeld)
        {
            //Debug.Log("changed kinematic");
            other.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void increaseMagicCount()
    {
        if (!containsMagicItem)
        {
            containsMagicItem = true;
            logicManager.itemsFound++;
            Debug.Log("itemsFound is now: " + logicManager.itemsFound);
        }
    }

    private void decreaseMagicCount()
    {
        if (containsMagicItem)
        {
            containsMagicItem = false;
            logicManager.itemsFound--;
            Debug.Log("itemsFound is now: " + logicManager.itemsFound);
        }
    }
}
