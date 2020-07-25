using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//each PlayerInfo will hold the necessary information for each
//player: held items, score, time, and the images on the UI for
//the held vegetables
public class PlayerInfo : MonoBehaviour
{
    int maxHeldItems = 2;
    public int score;
    public float time;
    public Queue<VegetablesScriptObj> veggieQueue = new Queue<VegetablesScriptObj>();

    //obvoiously, this will be a problem since maxHeldItems could change at any time,
    //but for now, as long as there's only 2 player, I'll keep it set like this
    public Image[] veggieImages = new Image[2];

    private void Update()
    {
        time -= Time.deltaTime;
    }

    public void UpdateQueue()
    {
        for (int i = 0; i < maxHeldItems; i++){
            //show the image of the veggie if there is one (or two)
            //Note: this enqueue-dequeue way is meant to read the veggie,
            //then return it back to the queue
            if (i < veggieQueue.Count)
            {
                VegetablesScriptObj tempVeg = veggieQueue.Dequeue();
                veggieImages[i].color = Color.white;
                veggieImages[i].sprite = tempVeg.icon;
                veggieQueue.Enqueue(tempVeg);
            }
            //if there's no veggie, clear the image in the heldItems image
            else
            {
                veggieImages[i].color = Color.clear;
                veggieImages[i].sprite = null;
            }
        }
    }
}
