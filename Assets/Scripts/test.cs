
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class test : UdonSharpBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("staying");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exited");
    }
}
