using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//rather than putting both player controls in one script, I decided that
//giving each player their own script would make things a little easier
public class PlayersScript : MonoBehaviour
{
    public PlayerInfo playerInfo;

    //I assigned the appropriate keys in the editor for each action
    //Player 1: horizAxes: A, D  vertAxes: W, S  interact: Q  chop: E
    //Player 2: horizAxes: J, L  vertAxes: I, K  interact: U  chop: O
    public string horizAxes, vertAxes, interact, chop;
    public float movementSpeed = 0f;
    //public int playerNum;

    //later on, this sensor will be used to sense whether the player is standing in
    //front of something important (vegetables, customer, trash)
    public GameObject sensor;
    SensorScript sensorInfo;
    Material playerMaterial;
    bool timeLeft = true;

    public void SetTimeLeft(bool isTimeLeft)
    {
        timeLeft = isTimeLeft;
    }


    //in hindsight, each PlayersScript is pretty much each player's GameManager,
    //so a real GameManager wasn't too necessary
    GameManager gameManager;

    Vector2 movement = new Vector2(0, 0);
    Rigidbody2D rb;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>().GetGameManager();
        rb = GetComponent<Rigidbody2D>();
        sensorInfo = sensor.GetComponent<SensorScript>();
        playerMaterial = GetComponent<SpriteRenderer>().material;
        playerMaterial.SetVector("_Color", playerInfo.playerColor);

    }

    void Update()
    {

        //stop moving if the player runs out of time
        if (playerInfo.time <= 0)
        {
            timeLeft = false;
            movement = Vector2.zero;
        }
        //Input for Movement
        if (timeLeft)
        {
            movement.x = Input.GetAxisRaw(horizAxes);
            movement.y = Input.GetAxisRaw(vertAxes);
        }

        //Sensor Repositioning (make sure it's always in front of the player)
        //this if statement prevents the sensor from repositoning on top of the
        //player instead of in front of them
        if (movement != Vector2.zero)
        {
            //.15 is a modifier to make sure the sensor isn't too far from the player
            sensor.transform.localPosition = movement * .15f;
        }

        //Input for Interact
        //depending on the "interactableObject" stored in the sensor - specifically,
        //the interactableObject's tag - 
        if (Input.GetButtonDown(interact) && sensorInfo.interactBool == true && timeLeft)
        {
            if (sensorInfo.interactableObject.tag == "VeggiePiles")
            {
                GetNewVegetable(sensorInfo.interactableObject.GetComponent<VegetablePiles>().veggie);
            }
            else if (sensorInfo.interactableObject.tag == "TrashCan" && playerInfo.veggieQueue.Count > 0)
            {
                ThrowOutItem();
            }
            if (sensorInfo.interactableObject.tag == "ChoppingBoard" && sensorInfo.interactableObject.GetComponent<ChoppingBoard>().isSaladHere == true && playerInfo.veggieQueue.Count < 2)
            {
                PickUpNewSalad(sensorInfo.interactableObject.GetComponent<ChoppingBoard>());
            }
            else if (sensorInfo.interactableObject.tag == "Customer" && playerInfo.veggieQueue.Count > 0 && playerInfo.veggieQueue.Peek().veggieName == "Salad")
            {
                CheckCustomerOrder(playerInfo.veggieQueue.Peek(), sensorInfo.interactableObject.GetComponent<CustomerScript>());
            }
        }

        //Input for Chop
        if (Input.GetButtonDown(chop) && timeLeft)
        {
            if (sensorInfo.interactableObject.tag == "ChoppingBoard" && playerInfo.veggieQueue.Count > 0)
            {
                PutVegetableOnChoppingBoard(sensorInfo.interactableObject.GetComponent<ChoppingBoard>());
            }
            //PutVegetableOnChoppingBoard();
            //TODO: implement chop script
        }
    }

    void FixedUpdate()
    {
        //Player movement
        //TODO: Try and make player movement a little smoother; try and use something with Lerp & velocity
        //as of now, the player will just move through solid objects
        rb.MovePosition(rb.position + (movement * movementSpeed * Time.fixedDeltaTime));

    }

    public Color GetMaterialColor()
    {
        return playerMaterial.GetVector("_Color");
    }

    //function to "pick up" a veggie from a vegetable pile
    void GetNewVegetable(VegetablesScriptObj newVeggie)
    {
        if (playerInfo.veggieQueue.Count < 2)
        {
            playerInfo.veggieQueue.Enqueue(NewSaladFromVeggie(newVeggie));
            playerInfo.UpdateQueue();
        }
    }

    //take a veggie out from the player's queue and put it somewhere, & update the queue
    //Ambiguous so that it can be used in almost any situation that will be available
    SaladScriptObj TakeItemFromQueue()
    {
        if (playerInfo.veggieQueue.Count > 0)
        {
            SaladScriptObj tempItem = playerInfo.veggieQueue.Dequeue();
            playerInfo.UpdateQueue();

            return tempItem;
        }
        return null;
    }

    //function to put a veggie on the chopping board, currently only checks to
    //make sure a veggie can be dequeued
    void PutVegetableOnChoppingBoard(ChoppingBoard board)
    {
        transform.position = board.newPlayerPos.position;
        board.StartChopping("Chopped " + TakeItemFromQueue().veggieName);
    }

    //Pick up a new SaladScriptObj from the cutting board and add it to the PlayerInfo veggieQueue
    void PickUpNewSalad(ChoppingBoard board)
    {
        playerInfo.veggieQueue.Enqueue(board.TakeSalad());
        playerInfo.UpdateQueue();

        //Debugging to check the values of the SaladScriptObj just picked up
        //SaladScriptObj veg = playerInfo.veggieQueue.Peek();
        //veg.DisplayVeggiesIncluded();
    }

    //function to use when player throws out a veggie or salad into the trash can
    //It dequeues the first veggie, then decreases the score
    void ThrowOutItem()
    {
        TakeItemFromQueue();
        
        //decrease score here. There's also a failsafe so that the score doesn't go below 0
        playerInfo.score -= 50;
        if (playerInfo.score < 0)
            playerInfo.score = 0;
    }

    //function that tests the customer order vs what the player has. If it's wrong,
    //the customwer will get mad, otherwise the salad is taken out of the queue and
    //the player gets 200 points
    void CheckCustomerOrder(SaladScriptObj playerSalad, CustomerScript customer)
    {
        SaladScriptObj custOrder = customer.order;

        if (playerSalad == custOrder)
        {
            TakeItemFromQueue();
            playerInfo.score += 200;
            customer.OrderDelivered(this);

        }
        else
        {
            customer.CustomerGetsAngry();
        }
    }

    //this is a conversion function to transfer the values in VegetablesScriptObj
    //into a new, instantiated SaladScriptObj
    SaladScriptObj NewSaladFromVeggie(VegetablesScriptObj veggie)
    {
        SaladScriptObj newSalad = ScriptableObject.CreateInstance<SaladScriptObj>();
        newSalad.icon = veggie.icon;
        newSalad.veggieName = "Salad";
        return newSalad;
    }

    //will temporarily double the speed of the player
    public IEnumerator TempSpeedUp()
    {
        float origSpeed = movementSpeed;
        movementSpeed *= 1.5f;
        yield return new WaitForSeconds(10f);
        movementSpeed = origSpeed;
    }
}
