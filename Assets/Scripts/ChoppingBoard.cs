using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: for now, for the chopping board and the customers, I'm not going to
//create a functional timer just yet. First I'm going to program them just to make sure
//that their other functions work properly, then I'll add timers to them
public class ChoppingBoard : MonoBehaviour
{
    public Transform newPlayerPos;
    public SaladScriptObj newCombo;
    public bool isSaladHere = false;

    float timer = 5f;

    void Update()
    {
        timer -= Time.deltaTime;
    }

    public void StartChopping(string addToCombo)
    {
        isSaladHere = true;
        for (int i = 0; i < newCombo.veggiesIncluded.Length; i++)
        {
            if (newCombo.veggiesIncluded[i].VeggieName == addToCombo)
                newCombo.veggiesIncluded[i].IsVeggieIncluded = true;
        }
    }

    public SaladScriptObj TakeSalad()
    {
        //rather than removing the salad, we're just going to copy it and then reset it to a default state
        SaladScriptObj newSalad = newCombo;
        isSaladHere = false;

        for (int i = 0; i < newCombo.veggiesIncluded.Length; i++)
        {
                newCombo.veggiesIncluded[i].IsVeggieIncluded = false;
        }
        return newSalad;
    }
}
