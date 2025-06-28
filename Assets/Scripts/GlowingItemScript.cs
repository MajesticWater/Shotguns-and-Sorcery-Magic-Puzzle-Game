using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingItemScript : MonoBehaviour
{
    private bool glowing = true;
    [SerializeField] Material glowingMat;
    [SerializeField] Material dullMat;

    public void SetGlowing()
    {
        gameObject.GetComponent<Renderer>().material = glowingMat;
        glowing = true;
    }

    public void SetDull()
    {
        gameObject.GetComponent <Renderer>().material = dullMat;
        glowing = false;
    }

    public bool isGlowing()
    {
        return glowing;
    }
}
