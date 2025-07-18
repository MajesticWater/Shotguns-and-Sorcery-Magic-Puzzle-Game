
using UdonSharp;
using UnityEngine;
using UnityEngine.Rendering;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class DoorScript : UdonSharpBehaviour
{
    [SerializeField] GameObject end;
    [SerializeField] float offsetX, offsetY, offsetZ;
    [SerializeField] float rOffsetX, rOffsetY, rOffsetZ;

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player.isLocal)
        {
            player.TeleportTo(new Vector3(
                    end.transform.position.x + offsetX,
                    end.transform.position.y + offsetY,
                    end.transform.position.z + offsetZ
                ),
                Quaternion.Euler(
                    end.transform.rotation.x + rOffsetX,
                    end.transform.rotation.y + rOffsetY,
                    end.transform.rotation.z + rOffsetZ
                )
            );
            end.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        Debug.Log("Teleporting: " + obj.name);
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
        obj.transform.eulerAngles = new Vector3(end.transform.rotation.x + rOffsetX, end.transform.rotation.y + rOffsetY, end.transform.rotation.z + rOffsetZ);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
