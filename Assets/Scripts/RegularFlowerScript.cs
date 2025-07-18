
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class RegularFlowerScript : UdonSharpBehaviour
{
    public void delete()
    {
        Destroy(gameObject);
    }
}
