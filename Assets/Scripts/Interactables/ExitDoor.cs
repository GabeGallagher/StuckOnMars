using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : Interactable
{
    public bool hasCard;

    public override void OnMouseDown()
    {
        if(!hasPower && !hasCard)
        {
            StartCoroutine(base.ShowElement(base.text[0]));
        }
        else if (hasPower && !hasCard)
        {
            StartCoroutine(base.ShowElement(base.text[1]));
        }
    }
}
