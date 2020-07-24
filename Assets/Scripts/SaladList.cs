using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//my idea is that I can use this script to store the vegetables and the salad
//icon to display, and when I go to deliver it to a customer, it will check
//each "veggie" against all of the "veggiesOrdered" that will be on the
//customer script.
[System.Serializable]
public class SaladList
{
    public List<string> veggies;
    public GameObject salad;
}
