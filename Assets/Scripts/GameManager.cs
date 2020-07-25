using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameManager instance;

    public int score1, score2;

    public Queue<VegetablesScriptObj>   player1Veggies = new Queue<VegetablesScriptObj>(),
                                        player2Veggies = new Queue<VegetablesScriptObj>();

    Image   player1Veggie1, player1Veggie2,
            player2Veggie1, player2Veggie2;

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

    private void Update()
    {

    }

    void VegetableQueueUpdated(Queue<VegetablesScriptObj> veggieQueue)
    {

    }
}
