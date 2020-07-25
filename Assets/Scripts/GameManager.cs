using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameManager instance;

    //this method seems a bit clunky, but it is functional. Each PlayerInfo
    //stores the special things for each player - score, time, items, etc.
    //This has started to evolve like each player has it's own individual GameManager
    //public PlayerInfo[] player = new PlayerInfo[2];

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



}
