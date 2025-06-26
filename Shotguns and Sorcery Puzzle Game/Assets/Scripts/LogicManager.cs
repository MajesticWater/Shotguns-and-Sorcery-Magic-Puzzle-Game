using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
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
