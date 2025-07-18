
using UdonSharp;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using VRC.SDKBase;
using VRC.Udon;

public class SFXScript : UdonSharpBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] float xOffset, yOffset, zOffset;
    public override void Interact()
    {
        Instantiate(item, new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z + zOffset), transform.rotation);
    }
}
