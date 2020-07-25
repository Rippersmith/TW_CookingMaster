using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    public bool interactBool = false;
    public bool chopBool = false;

    public GameObject interactableObject;
    //ChoppingBoard choppingBoard;

        //detect each object by its tag: since the "interact"
        //script will have several uses, this will reguire a 
        //few if statements
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("VeggiePiles"))
        {
            interactBool = true;
            interactableObject = collider.gameObject;
        }
        else if (collider.CompareTag("ChoppingBoard"))
            chopBool = true;
    }

    //this is to make sure that the player doesn't have anything to take/do
    //once he moves out of range of the object
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("VeggiePiles"))
        {
            interactBool = false;
            interactableObject = null;
        }
        else if (collider.CompareTag("ChoppingBoard"))
            chopBool = false;
    }

}
