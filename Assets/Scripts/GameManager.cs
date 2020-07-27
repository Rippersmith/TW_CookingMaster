using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameManager instance;

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
