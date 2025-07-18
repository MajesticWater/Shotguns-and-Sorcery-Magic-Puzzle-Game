
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ButterflyScript : UdonSharpBehaviour
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
        }
        else
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
        //Debug.Log("butterfly correct? " +  correctColor);
        return correctColor;
    }
}
