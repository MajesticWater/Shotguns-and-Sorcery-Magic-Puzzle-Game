using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyBowlScript : MonoBehaviour
{
    [SerializeField] GameObject[] butterflies;

    public bool isCorrectColor()
    {
        return butterflies[0].GetComponent<ButterflyScript>().isCorrectColor();
    }

    public void setColor(Material mat)
    {
        Debug.Log("setting color in bowl");
        foreach (GameObject butterfly in butterflies)
        {
            butterfly.GetComponent<ButterflyScript>().setColor(mat);
        }
    }
}
