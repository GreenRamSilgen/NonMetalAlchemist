﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EndOfDayDisplay : MonoBehaviour
{
<<<<<<< HEAD
    public Text ledger;

=======
    public Ledger ledger;
    public Text day;
>>>>>>> 2d80daf3b13e63024b0f132de7274cf5cd0b56b4

    // Use this for initialization
    void Start()
    {
<<<<<<< HEAD
    
        ledger.text = "       LEDGER:\n\nHiring Cost:  - " + calcHireCost() + "\n\n" + "Rent:            - 50\n\n" + "Potions:       + "
                        +"---------------------\nTotal:          ";
=======
        day.text = "End of Day " + Global.day;
        
                        //+"---------------------\nTotal:          ";
>>>>>>> 2d80daf3b13e63024b0f132de7274cf5cd0b56b4
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            //ledger.cost.text = "YO";
            ledger.cost.text = "Hiring Cost:  - " + calcHireCost() + "\n\n" + "Rent:            - 50\n\n" + "Potions:       + ";
        }
    }

    int calcHireCost() // calculate the hiring costs based on that day
    {
        IDictionaryEnumerator myEnum = Global.gatherers.GetEnumerator();
        int count = 0;
        while(myEnum.MoveNext())
        {
            Debug.Log(myEnum.Key.ToString());
            count += Global.gathererCost[myEnum.Key.ToString()] * System.Convert.ToInt32(myEnum.Value.ToString());
          

        }

        return count;
    }
    void printDict()//used for debugging
    {
        foreach(KeyValuePair<string, int> kv in Global.gatherers)
        {
            print("key: " + kv.Key + "   value: " + kv.Value);
            print(Global.gatherers.ContainsKey(kv.Key));
            print(Global.gathererCost.ContainsKey(kv.Key));
            print("=======================");
        }
    }
}
