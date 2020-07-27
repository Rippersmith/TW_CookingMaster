using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPowerUp : PowerUpBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if object is player & the playerScript stored here is the same as the Player's, pick it up
        //hopefully, this is how the right player will pick it up
        if (collision.CompareTag("Player") && playerScript == collision.GetComponent<PlayersScript>())
        {
            Destroy(gameObject);
        }
    }
}
