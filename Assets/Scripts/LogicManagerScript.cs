
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
    private float time = 0;
    [SerializeField] GameObject magicCircle;
    [SerializeField] float magicTime = 1;
    private bool circleOn = true;
    private GameObject obj;
    [SerializeField] float circleOffset;
    void Update()
    {
        if (itemsFound == itemsToWin)
        {
            if (time == 0)
            {
                obj = Instantiate(magicCircle, new Vector3(expX, gameObject.transform.position.y + circleOffset, expZ), Quaternion.Euler(Vector3.zero));
            }
       
            if (circleOn && time > magicTime)
            {
                circleOn = false;
                time = 1 + 1 / expRate;
                Destroy(obj);
            }
            if (!circleOn && (expRate == 0 || time > 1 / expRate))
            {
                time = 0;
                Instantiate(explosion, new Vector3(expX, expY, expZ), Quaternion.Euler(Vector3.zero));
            }
            time += Time.deltaTime;
        }
    }
}
