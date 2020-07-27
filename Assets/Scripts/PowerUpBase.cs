using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : MonoBehaviour
{
    public PlayersScript playerScript;
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        Destroy(gameObject, 20f);//power-up goes away after 10 secs
    }

    //set the shader color of the power-ups, depending on the player that picks it up
    public void SetColor(Color powerColor)
    {
        material.SetVector("_Color", powerColor);
    }
}
