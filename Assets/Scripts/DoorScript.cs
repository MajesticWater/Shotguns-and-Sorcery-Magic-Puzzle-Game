using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Components;

public class DoorScript : MonoBehaviour
{
    [SerializeField] GameObject end;
    [SerializeField] float offsetX, offsetY, offsetZ;
    [SerializeField] float rOffsetX, rOffsetY, rOffsetZ;

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.name != "PlayerController")
        {
            VRCPickup pick = obj.GetComponent<VRCPickup>();
            while (pick == null)
            {
                obj = obj.transform.parent.gameObject;
                pick = obj.GetComponent<VRCPickup>();
            }
        }

        Debug.Log("Teleporting: " + obj.name);
        obj.transform.position = new Vector3(end.transform.position.x + offsetX, end.transform.position.y + offsetY, end.transform.position.z + offsetZ);
        obj.transform.eulerAngles = new Vector3(
            obj.transform.eulerAngles.x + rOffsetX,
            obj.transform.eulerAngles.y + rOffsetY,
            obj.transform.eulerAngles.z + rOffsetZ
        );
    }
}
