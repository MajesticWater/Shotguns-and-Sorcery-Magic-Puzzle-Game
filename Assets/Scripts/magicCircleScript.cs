
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class magicCircleScript : UdonSharpBehaviour
{
    public float magicTime;
    private float mTime = 0;

    private void Update()
    {
        mTime += Time.deltaTime;
        if (mTime > magicTime)
        {
            Destroy(gameObject);
        }
    }
}
