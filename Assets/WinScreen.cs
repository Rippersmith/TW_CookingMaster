using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public Text winMessage;
    public PlayerInfo player1, player2;
    bool stopUpdate = false;

    public void Update()
    {
        if (stopUpdate == false && player1.time <= 0f && player2.time <= 0f)
        {
            stopUpdate = true;
            if (player1.score > player2.score)
                winMessage.text = "PLAYER 1 WINS!!!";
            else if (player1.score < player2.score)
                winMessage.text = "PLAYER 2 WINS!!!";
            else
                winMessage.text = "TIE!";

            IEnumerator reload = ReloadGame();
            StartCoroutine(reload);

        }
    }

    IEnumerator ReloadGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

}
