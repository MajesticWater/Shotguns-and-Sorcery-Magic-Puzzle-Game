
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ClamScript : UdonSharpBehaviour
{
    [SerializeField] GameObject clam;
    [SerializeField] GameObject pearl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "zombie")
        {
            clam.SetActive(false);
            pearl.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
