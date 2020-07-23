using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//rather than putting both player controls in one script, I decided that
//giving each player their own script would make things a little easier
public class PlayerScript : MonoBehaviour
{
    //I assigned the appropriate keys in the editor for each action
    //Player 1: horizAxes: A, D  vertAxes: W, S  interact: Q  chop: E
    //Player 2: horizAxes: J, L  vertAxes: I, K  interact: U  chop: O
    public string horizAxes, vertAxes, interact, chop;
    public float movementSpeed = 0f;

    //later on, this sensor will be used to sense whether the player is standing in
    //front of something important (vegetables, customer, trash)
    public GameObject sensor;

    Vector2 movement = new Vector2(0, 0);
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Input for Movement
        movement.x = Input.GetAxisRaw(horizAxes);
        movement.y = Input.GetAxisRaw(vertAxes);

        //Sensor Repositioning (make sure it's always in front of the player)
        //this if statement prevents the sensor from repositoning on top of the
        //player instead of in front of them
        if (movement != Vector2.zero)
        {
            //.15 is a modifier to make sure the sensor isn't too far from the player
            sensor.transform.localPosition = movement * .15f;
        }

        //Input for Interact
        if (Input.GetButtonDown(interact))
        {
            //TODO: implement interact script
        }

        //Input for Chop
        if (Input.GetButtonDown(chop))
        {
            //TODO: implement chop script
        }
    }

    void FixedUpdate()
    {
        //Player movement
        //TODO: Try and make player movement a little smoother; try and use something with Lerp
        rb.MovePosition(rb.position + (movement * movementSpeed * Time.fixedDeltaTime));

    }
}
