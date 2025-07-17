using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeScript : MonoBehaviour
{
    [SerializeField] Material butterflyMat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Butterfly Bowl")
        {
            other.GetComponent<ButterflyBowlScript>().setColor(butterflyMat);
        }
    }
}
