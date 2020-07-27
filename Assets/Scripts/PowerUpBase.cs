using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : MonoBehaviour
{
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;       
    }

    //set the shader color of the power-ups, depending on the player that picks it up
    public void SetColor(Color powerColor)
    {
        material.SetVector("_Color", powerColor);
    }
}
