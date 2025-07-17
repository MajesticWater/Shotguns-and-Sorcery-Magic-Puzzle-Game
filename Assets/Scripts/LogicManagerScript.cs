
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class LogicManagerScript : UdonSharpBehaviour
{
    public int itemsFound = 0;
    [SerializeField] int itemsToWin = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (itemsFound == itemsToWin)
        {
            Debug.Log("you win!!!");
        }
    }
}
