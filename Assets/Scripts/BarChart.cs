﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class BarChart : MonoBehaviour
{
    /*CUSTOMIZE BARS HERE*/
    private readonly int maxValue = 25;
    /*CUSTOMIZE BARS HERE*/

    /*
	CraftingController assist week 8 meeting
        Call BarChart.blankGraph() upon “Craft”
        Call BarChart.updateBarGraph(mat1ID,mat2ID,mat3ID) upon slot update

     */



    //Material Pulling
    private MaterialList MaterialList = new MaterialList(); //Create ItemList object
    GameObject materialsGetter; //create gameobject
    private SortedDictionary<string, int> totalAspects = new SortedDictionary<string, int>();
    private SortedDictionary<string, int> topFiveAspects = new SortedDictionary<string, int>();

    //Bar 
    public Bar barPreFab;
    public int[] inputValues;
    public string[] labels;
    public Color[] colors;
    List<Bar> bars = new List<Bar>();

    float chartHeight;
    void Start()
    {
        //Material Pulling
        materialsGetter = GameObject.FindGameObjectWithTag("Resourcer"); //Assign ResourceLoader gameobject to "resourceGetter"
        MaterialList = materialsGetter.GetComponent<MaterialLoader>().getMaterialList(); //Call getResourceList from ResourceLoader Script in ResourceHolder


        //Bar
        chartHeight = Screen.height - GetComponent<RectTransform>().sizeDelta.y;
        MakeBars(inputValues);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //Change the bar height HERERERE
            RectTransform rt = bars[1].bar.GetComponent<RectTransform>();
            float normalizedValue = (float)10/*NEWVALUE HERERER in pace of 10*/ / (float)25;
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, (chartHeight / 7) * normalizedValue);

            //Change the bar label HEREREE.
            bars[1].label.text = "NewTxt";
            //Change the bar Value
            bars[1].barValue.text = "10";

            //Change the bar Color
            //bars[1].bar.color = colors[/*materialID*/10];
            Debug.Log(bars.Count);
        }
        
    }

    public void updateBarGraph(int m1ID, int m2ID, int m3ID)
    {
        calculateAspects(m1ID, m2ID, m3ID);
        if (totalAspects.Count == 1 && totalAspects.ContainsKey("NA"))
        {
            blankGraph();
        }
        else
        {
            updateTopFive();
            updateAllBars();
        }
    }

    void calculateAspects(int m1ID, int m2ID, int m3ID) //MIGHT GET ERROR FOR MULTIPLE NA ITEM???
    {
        resetAspects();

        //Material 1
        if (m1ID == -1)
        {
            if (!totalAspects.ContainsKey("NA"))
            {
                totalAspects.Add("NA", 0);
            }
            else
            {
                totalAspects["NA"] += 0;
            }
        }
        else
        {
            safeAdd(m1ID);
        }

        //Material 2
        if (m2ID == -1)
        {
            if (!totalAspects.ContainsKey("NA"))
            {
                totalAspects.Add("NA", 0);
            }
            else
            {
                totalAspects["NA"] += 0;
            }
        }
        else
        {
            safeAdd(m2ID);
        }

        //Material 3
        if (m3ID == -1)
        {
            if (!totalAspects.ContainsKey("NA"))
            {
                totalAspects.Add("NA", 0);
            }
            else
            {
                totalAspects["NA"] += 0;
                Debug.Log(totalAspects.Count);
                Debug.Log(totalAspects.ContainsKey("NA"));
            }
        }
        else
        {
            safeAdd(m3ID);
        }
    }

    void safeAdd(int m1ID)
    {
        if (!totalAspects.ContainsKey(MaterialList.Materials[m1ID].A1Name))
        {
            totalAspects.Add(MaterialList.Materials[m1ID].A1Name, MaterialList.Materials[m1ID].A1Amt);
        }
        else
        {
            totalAspects[MaterialList.Materials[m1ID].A1Name] += MaterialList.Materials[m1ID].A1Amt;
        }
        //ASPECT 2
        if (!totalAspects.ContainsKey(MaterialList.Materials[m1ID].A2Name))
        {
            totalAspects.Add(MaterialList.Materials[m1ID].A2Name, MaterialList.Materials[m1ID].A2Amt);
        }
        else
        {
            totalAspects[MaterialList.Materials[m1ID].A2Name] += MaterialList.Materials[m1ID].A2Amt;
        }
        //ASPECT 3
        if (!totalAspects.ContainsKey(MaterialList.Materials[m1ID].A3Name))
        {
            totalAspects.Add(MaterialList.Materials[m1ID].A3Name, MaterialList.Materials[m1ID].A3Amt);
        }
        else
        {
            totalAspects[MaterialList.Materials[m1ID].A3Name] += MaterialList.Materials[m1ID].A3Amt;
        }
    }

    void updateTopFive()
    {
        resetTopFiveAspects();
        int i = 0;
        while (i < 5 && totalAspects.Count != 0)
        {
            if (!topFiveAspects.ContainsKey(totalAspects.Aggregate((x, y) => x.Value > y.Value ? x : y).Key))
            {
                topFiveAspects.Add(totalAspects.Aggregate((x, y) => x.Value > y.Value ? x : y).Key, totalAspects.Values.Max());
                totalAspects.Remove(totalAspects.Aggregate((x, y) => x.Value > y.Value ? x : y).Key);
                i++;
            }
            else
            {
                totalAspects.Remove(totalAspects.Aggregate((x, y) => x.Value > y.Value ? x : y).Key);
            }
        }
    }

    void updateAllBars()
    {
        IDictionaryEnumerator myEnumerator = topFiveAspects.GetEnumerator();
        int i = 0;
        while(myEnumerator.MoveNext())
        {
            //Change the bar height HERERERE
            RectTransform rt = bars[i].bar.GetComponent<RectTransform>();
            float normalizedValue = (float)System.Convert.ToInt32(myEnumerator.Value.ToString())/ (float)25;
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, (chartHeight / 7) * normalizedValue);

            //Change the bar label HEREREE.
            bars[i].label.text = myEnumerator.Key.ToString();
            //Change the bar Value
            bars[i].barValue.text = myEnumerator.Value.ToString();
            i++;
        }
    }

    public void blankGraph() //call this upon "CRAFT"
    {
        for(int i = 0; i < 5;i++)
        {
            RectTransform rt = bars[i].bar.GetComponent<RectTransform>();
            float normalizedValue = (float)0/ (float)25;
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, (chartHeight / 7) * normalizedValue);

            //Change the bar label HEREREE.
            bars[i].label.text = "NA";
            //Change the bar Value
            bars[i].barValue.text = "0";
        }
    }

    void MakeBars(int[] values)
    {
        //int maxValue = 25;
        //values.Max();//Maybe change max value to 25 for consistent graph all the time

        for (int i = 0; i < values.Length; i++) //instantiate bar per input value
        {
            Bar newBar = Instantiate<Bar>(barPreFab, transform);
            newBar.transform.SetParent(transform);
            //Makes height change based on value
            RectTransform rt = newBar.bar.GetComponent<RectTransform>();

            //Normalize the input values based on max.
            float normalizedValue = (float)values[i] / (float)maxValue;

            //set Height of the Bar.
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, (chartHeight/7) * normalizedValue);

            //set Color of this ONE BAR.
            //newBar.bar.color = colors[i % colors.Length];



            //set Label of created Bar (aspect name)
            if(labels.Length <= i)
            {
                newBar.label.text = "UNDEFINED";
            }
            else
            {
                newBar.label.text = labels[i];
            }

            //set Value on top of bar
            newBar.barValue.text = values[i].ToString();
            
            //if bar is too small make input value display above bar.
            /*if(rt.sizeDelta.y < 10f)
            {
                newBar.barValue.rectTransform.pivot = new Vector2(0.5f, 0f);
                newBar.barValue.rectTransform.anchoredPosition = Vector2.zero;
            }
            */
            bars.Add(newBar);
        }
    }


    void resetAspects()
    {
        totalAspects.Clear();
    }
    void resetTopFiveAspects()
    {
        topFiveAspects.Clear();
    }
}

