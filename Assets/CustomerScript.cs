using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    public SaladScriptObj genericSalad;
    public SaladScriptObj order;
    public GameObject pu_Speed, pu_Time, pu_Points; //these are the powerups, or "PUs", to spawn
    float timeMultiplier = 1;
    float timerMax = 30f, fastTime, timer;
    // Start is called before the first frame update
    void Start()
    {
        //order = GenerateNewOrder();
        //fastTime = timerMax.
    }

    // Use this Update function for the customer's timer
    void Update()
    {
        timer -= Time.deltaTime * timeMultiplier;
    }

    //this is used for generating a customer's new/initial order
    public SaladScriptObj GenerateNewOrder()
    {
        SaladScriptObj newOrder = genericSalad;
        int firstOrder = 0, secondOrder = 1;
        int numIngr = Random.Range(1, 4);
        int[] ingredients = new int[numIngr];
        /*
        //this for loop is used to make sure the first & second orders aren't the same
        firstOrder = Random.Range(0, 6);

        for (int i = 0; i < numIngr; i++){
            if
        }
        for(int i = 0; i < 10; i++)
        {
            secondOrder = Random.Range(0, 6);
            if (secondOrder != firstOrder)
                break;
        }
        */

        //the above code will be used once I know that the customer script is working,
        //and I have the other veggies available to make for a combo. For now, I will use
        //the veggies that I have piles for and their numbers (lettuce & carrots)

        newOrder.veggiesIncluded[firstOrder].IsVeggieIncluded = true;
        newOrder.veggiesIncluded[secondOrder].IsVeggieIncluded = true;

        newOrder.DisplayVeggiesIncluded();

        return newOrder;
    }

    int RandomNumber(int[] checkAgainst)
    {
        int newNumber = Random.Range(0, 6);
        return newNumber;
    }

    //if a customer gets angry, call this, and the available time doesn't really "decrease",
    //it's just that the timer just empties a little quicker
    public void CustomerGetsAngry()
    {
        timeMultiplier += .2f;
    }
}
