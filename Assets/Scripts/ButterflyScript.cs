using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.Udon.Wrapper.Modules;


public class ButterflyScript : MonoBehaviour
{
    [SerializeField] GameObject[] wingPieces;
    [SerializeField] Material correctMat;

    private bool correctColor = false;

    public void setColor(Material mat)
    {
        if (mat == correctMat)
        {
            Debug.Log("changed to correct color");
            correctColor = true;
        } else
        {
            correctColor = false;
        }

        foreach (GameObject obj in wingPieces)
        {
            obj.GetComponent<Renderer>().material = mat;
        }
    }

    public bool isCorrectColor()
    {
        return correctColor;
    }
}
