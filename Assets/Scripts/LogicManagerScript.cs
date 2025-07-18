
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using static UnityEditor.Progress;

public class LogicManagerScript : UdonSharpBehaviour
{
    public int itemsFound = 0;
    [SerializeField] int itemsToWin = 5;
    [SerializeField] GameObject explosion;
    [SerializeField] float expX, expY, expZ;
    [SerializeField] float expRate;
    private float exp = 0;

    void Update()
    {
        if (itemsFound == itemsToWin)
        {
            exp += Time.deltaTime;
            if (expRate == 0 || exp > 1 / expRate)
            {
                exp = 0;
                Instantiate(explosion, new Vector3(expX, expY, expZ), Quaternion.Euler(Vector3.zero));
            }
        }
    }
}
