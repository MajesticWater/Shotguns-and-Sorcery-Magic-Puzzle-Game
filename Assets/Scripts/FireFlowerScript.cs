
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class FireFlowerScript : UdonSharpBehaviour
{
    private bool lit = false;
    [SerializeField] GameObject fire;

    public void ignite()
    {
        fire.SetActive(true);
        lit = true;
    }

    public bool isLit()
    {
        return lit;
    }
}
