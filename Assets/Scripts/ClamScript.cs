using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClamScript : MonoBehaviour
{
    [SerializeField] GameObject clam;
    [SerializeField] GameObject pearl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "zombie")
        {
            clam.SetActive(false);
            pearl.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
