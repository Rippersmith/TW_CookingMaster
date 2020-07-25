using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameManager instance;

    //this method seems a bit clunky, but it is functional. Each PlayerInfo
    //stores the special things for each player - score, time, items, etc.
    public PlayerInfo[] player = new PlayerInfo[2];

    //scripts will call this function to call GameManager as a reference
    public GameManager GetGameManager()
    {
        if (instance != null)
            return instance;
        return null;
    }

    //implement Singleton GameManager
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    //private void Update()
    //{

    //}

        //add a new veggie to the player's queue
    public void AddVeggieToQueue(int playerNum, VegetablesScriptObj veggie)
    {
        if (player[playerNum].veggieQueue.Count < 2)
        {
            player[playerNum].veggieQueue.Enqueue(veggie);
            player[playerNum].UpdateQueue();
        }
    }

    //take a veggie out from the player's queue and put it somewhere,
    //either customer, trash, or chopping board
    public void TakeVeggieFromQueue(int playerNum)
    {
        if (player[playerNum].veggieQueue.Count > 0)
        {
            player[playerNum].veggieQueue.Dequeue();
            player[playerNum].UpdateQueue();
            //TODO: send Dequeue somewhere
        }
    }

    void VegetableQueueUpdated(Queue<VegetablesScriptObj> veggieQueue)
    {

    }
}
