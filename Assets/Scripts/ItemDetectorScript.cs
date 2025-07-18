
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
    private LogicManagerScript logicManager;
    [SerializeField] GameObject particles;

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
                FireFlowerScript ffs = other.GetComponent<FireFlowerScript>();
                if (mis != null || (gls != null && gls.isGlowing()) || (bfs != null && bfs.isCorrectColor()) || (ffs != null && ffs.isLit()))
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
            FireFlowerScript ffs = other.GetComponent<FireFlowerScript>();
            if (mis != null || (gls != null && gls.isGlowing()) || (bfs != null && bfs.isCorrectColor()) || (ffs != null && ffs.isLit()))
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
            Instantiate(particles, new Vector3(
                    gameObject.transform.position.x,
                    gameObject.transform.position.y,
                    gameObject.transform.position.z + itemOffset
                ),
                Quaternion.Euler(Vector3.zero)
            );
            gameObject.GetComponent<AudioSource>().Play();
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
