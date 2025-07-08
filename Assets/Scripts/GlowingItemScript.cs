using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingItemScript : MonoBehaviour
{
    private bool glowing = true;
    private bool inDarkZone = true;
    [SerializeField] Material glowingMat;
    [SerializeField] Material dullMat;
    [SerializeField] GameObject lightSource;

    private void Update()
    {
        if (!inDarkZone)
        {
            if (lightSource.activeInHierarchy && glowing)
            {
                SetDull();
            } else if (!lightSource.activeInHierarchy && !glowing)
            {
                SetGlowing();
            }
        }
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "dark zone")
        {
            if (!glowing)
            {
                SetGlowing();
            }
            inDarkZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "dark zone")
        {
            if (lightSource.activeInHierarchy && glowing)
            {
                SetDull();
            }
            inDarkZone = false;
        }
    }

    public bool isGlowing()
    {
        return glowing;
    }
}
