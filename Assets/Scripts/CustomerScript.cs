using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerScript : MonoBehaviour
{
    public SaladScriptObj genericSalad;
    public SaladScriptObj order;
    public GameObject[] powerUps = new GameObject[3]; //these are the powerups to spawn
    //not enough time to get pictures, will use words instead
    //public Image order1, order2;
    public Text orderText;
    float timeMultiplier = 1;
    float timerMax = 30f, fastTime, timer;
    // Start is called before the first frame update
    void Start()
    {
        order = GenerateNewOrder();
    }

    // Use this Update function for the customer's timer
    void Update()
    {
        timer -= Time.deltaTime * timeMultiplier;
    }

    //this is used for generating a customer's new/initial order
    //currently only set up for a 2-ingredient order, will work on making
    //random-numbered (1 - 3) if time is left
    public SaladScriptObj GenerateNewOrder()
    {
        SaladScriptObj newOrder = genericSalad;
        int firstOrder = 0, secondOrder = 1;

        //even though I didn't have time to generate a random # of ingredients,
        //this small bit of code was intended for that
        int numIngr = 2; // Random.Range(1, 4);
        timerMax = numIngr * 15f;
        fastTime = timerMax * .7f;
        //int[] ingredients = new int[numIngr];
        
        //this for loop is used to make sure the first & second orders aren't the same
        //loops a few times in case it happensover & over
        firstOrder = Random.Range(0, 6);
        for(int i = 0; i < 10; i++)
        {
            secondOrder = Random.Range(0, 6);
            if (secondOrder != firstOrder)
                break;
        }

        //assign the new order
        newOrder.veggiesIncluded[firstOrder].IsVeggieIncluded = true;
        newOrder.veggiesIncluded[secondOrder].IsVeggieIncluded = true;

        orderText.text = string.Format("{0}, {1}", newOrder.veggiesIncluded[firstOrder].VeggieName, newOrder.veggiesIncluded[secondOrder].VeggieName);

        //newOrder.DisplayVeggiesIncluded();

        return newOrder;
    }

    int RandomNumber(int[] checkAgainst)
    {
        int newNumber = Random.Range(0, 6);
        return newNumber;
    }

    public void OrderDelivered(PlayersScript player)
    {
        SpawnPowerup(player);
        if (timer > fastTime)
        {
            SpawnPowerup(player);
        }

        timeMultiplier = 1f;
         order = GenerateNewOrder();
            
    }

    void SpawnPowerup(PlayersScript player)
    {
        int puNum = Random.Range(0, 3);
        Vector2 spawnPoint = new Vector2(Random.Range(-15f, 15f), Random.Range(-9f, 2f));
        GameObject powerUp = Instantiate(powerUps[puNum], spawnPoint, Quaternion.identity);
        powerUp.GetComponent<PowerUpBase>().SetColor(player.GetMaterialColor());//change color of the power up based on the player color
    }

    //if a customer gets angry, call this, and the available time doesn't really "decrease",
    //it's just that the timer just empties a little quicker
    public void CustomerGetsAngry()
    {
        timeMultiplier += .2f;
    }
}
