using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeScript : MonoBehaviour
{
    [SerializeField] Material butterflyMat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "butterfly DO NOT CHANGE NAME")
        {
            other.GetComponent<ButterflyScript>().setColor(butterflyMat);
        }
    }
}
