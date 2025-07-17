
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ButterflyBowlScript : UdonSharpBehaviour
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
