using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//my idea is that I can use this script to store the vegetables and the salad
//icon to display, and when I go to deliver it to a customer, it will check
//each "veggie" against all of the "veggiesOrdered" that will be on the
//customer script.

    //I want to make a Dictionary where I can assign variables without Start()/Awake(),
    //(no MonoBehaviour available) but Dictionary doesn't allow that. Instead, I made
    //my own customized Dictionary (shortened to CustomDict) that can be assigned automatically
//[System.Serializable]
public struct CustomDict
{
    private string veggieName;
    private bool isVeggieIncluded;

    public string VeggieName { get { return veggieName; } set { veggieName = value; } }
    public bool IsVeggieIncluded { get { return isVeggieIncluded; } set { isVeggieIncluded = value; } }

    public CustomDict(string newVeggieName, bool newIsVeggieIncluded)
    {
        veggieName = newVeggieName;
        isVeggieIncluded = newIsVeggieIncluded;
    }

    public void AddVeggieToSalad()
    {
        isVeggieIncluded = true;
        
    }

}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Salads", order = 2)]
public class SaladScriptObj: VegetablesScriptObj
{
    //this array of CustomDicts will be checked against a similar list
    //of the customer's order
    //this setup assumes that the customer doesn't want duplicates of any veggies
    //in the salad (i.e. a double-order of lettuce)

    public CustomDict[] veggiesIncluded = new CustomDict[6] {
        new CustomDict("Chopped Lettuce", false),
        new CustomDict("Chopped Carrot", false),
        new CustomDict("Chopped Tomato", false),
        new CustomDict("Chopped Onion", false),
        new CustomDict("Chopped Chicken", false),
        new CustomDict("Chopped Bacon", false),
    };

}
