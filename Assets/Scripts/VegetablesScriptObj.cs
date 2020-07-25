using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is how I'll store the information for each veggie: I'll create each object in the player's
//inventory when they take it from the respective source, displaying the "icon". When they start
//chopping, I'll read the "veggie" and return an appropriate "choppedVeggie". That choppedVeggie
//will be stored in a new "SaladList", and this object can be picked up and delivered to the customer
//Note: string is most likely a temporary variable for veggie, will try to think of an alternative AASAP
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Vegetables", order = 1)]
public class VegetablesScriptObj : ScriptableObject
{
    //TODO: add more variables as needed
    public Sprite icon;
    public string veggieName;
}
