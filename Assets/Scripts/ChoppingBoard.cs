using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: for now, for the chopping board and the customers, I'm not going to
//create a functional timer just yet. First I'm going to program them just to make sure
//that their other functions work properly, then I'll add timers to them
public class ChoppingBoard : MonoBehaviour
{
    public Transform newPlayerPos;
    public SaladScriptObj saladToSpawn, newCombo;
    public bool isSaladHere = false;
    public SpriteRenderer saladPic;

    float timer = 5f;

    void Update()
    {
        timer -= Time.deltaTime;
    }

    //take the VegetableScriptObj, make a new newCombo salad (if there isn't one there),
    //then read the VegetableScriptObj & "add" it to the newCombo. Also make the salad
    //picture visible on the cutting board
    public void StartChopping(string addToCombo)
    {
        isSaladHere = true;
        if (newCombo == null)
            newCombo = saladToSpawn;
        for (int i = 0; i < newCombo.veggiesIncluded.Length; i++)
        {
            if (newCombo.veggiesIncluded[i].VeggieName == addToCombo)
                newCombo.veggiesIncluded[i].IsVeggieIncluded = true;
        }
        saladPic.color = Color.white;
    }

    //script so that the player can take the salad from the PlayerScript script
    public SaladScriptObj TakeSalad()
    {
        //create a temporary duplicate salad, clear off the chopping board,
        //then return the duplicate salad
        SaladScriptObj newSalad = newCombo;
        isSaladHere = false;
        newCombo = null;
        saladPic.color = Color.clear;

        return newSalad;
    }
}
