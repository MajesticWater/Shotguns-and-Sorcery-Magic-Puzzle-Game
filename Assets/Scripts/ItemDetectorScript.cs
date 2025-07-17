
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class ItemDetectorScript : UdonSharpBehaviour
{
    [SerializeField] float itemOffset = 1;
    private bool containsItem = false;
    private bool containsMagicItem = false;
    [SerializeField] LogicManagerScript logicManager;

    private void Start()
    {
        logicManager = gameObject.transform.parent.GetComponent<LogicManagerScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<VRCPickup>() == null) return;
        if (!other.GetComponent<VRCPickup>().IsHeld)
        {
            if (!containsItem)
            {
                GlowingItemScript gls = other.GetComponent<GlowingItemScript>();
                ButterflyBowlScript bfs = other.GetComponent<ButterflyBowlScript>();
                MagicItemScript mis = other.GetComponent<MagicItemScript>();
                if (mis != null && (gls == null || gls.isGlowing()) && (bfs == null || bfs.isCorrectColor()))
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
            }
            else
            {
                GlowingItemScript gls = other.GetComponent<GlowingItemScript>();
                ButterflyBowlScript bfs = other.GetComponent<ButterflyBowlScript>();
                if (gls != null)
                {
                    if (gls.isGlowing())
                    {
                        increaseMagicCount();
                    }
                    else
                    {
                        decreaseMagicCount();
                    }

                }
                if (bfs != null)
                {
                    if (bfs.isCorrectColor())
                    {
                        increaseMagicCount();
                    }
                    else
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
        Debug.Log("exited");
        if (other.GetComponent<VRCPickup>() == null) return;
        if (containsItem)
        {
            containsItem = false;
            GlowingItemScript gls = other.GetComponent<GlowingItemScript>();
            ButterflyBowlScript bfs = other.GetComponent<ButterflyBowlScript>();
            MagicItemScript mis = other.GetComponent<MagicItemScript>();
            if (mis != null && (gls == null || gls.isGlowing()) && (bfs == null || bfs.isCorrectColor()))
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
