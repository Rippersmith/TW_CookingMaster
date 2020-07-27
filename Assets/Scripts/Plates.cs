using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plates : MonoBehaviour
{
    public SaladScriptObj item;
    public SpriteRenderer pic;

    //assign new SaladScriptObj to the plate
    public void Assign(SaladScriptObj obj)
    {
        item = obj;
        pic.color = Color.white;
        pic.sprite = obj.icon;
    }

    //take the SaladScriptObj from the plate
    public SaladScriptObj DisplayObject()
    {
        SaladScriptObj temp = item;
        item = null;
        pic.color = Color.clear;
        return temp;
    }
}
