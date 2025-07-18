
using UdonSharp;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using VRC.SDKBase;
using VRC.Udon;

public class SFXScript : UdonSharpBehaviour
{

    public override void Interact()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
