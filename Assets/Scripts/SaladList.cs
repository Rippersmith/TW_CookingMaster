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
    [System.Serializable]
public struct CustomDict
{
    public string veggieName;
    public bool isVeggieIncluded;

    public CustomDict(string _veggieName, bool _isVeggieIncluded)
    {
        veggieName = _veggieName;
        isVeggieIncluded = _isVeggieIncluded;
    }
}
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Salads", order = 2)]
public class SaladList: VegetablesScriptObj
{
    //this array of CustomDicts will be checked against a similar list
    //of the customer's order
    public CustomDict[] veggiesIncluded = new CustomDict[6] {
        new CustomDict("Chopped Lettuce", false),
        new CustomDict("Chopped Carrots", false),
        new CustomDict("Chopped Tomatoes", false),
        new CustomDict("Chopped Onions", false),
        new CustomDict("Chopped Chicken", false),
        new CustomDict("Chopped Bacon", false),
    };

    public Dictionary<string, bool> g = new Dictionary<string, bool>();
}
