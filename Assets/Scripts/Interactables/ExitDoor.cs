using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : Interactable
{
    public bool hasCard, doorOpen;

    public GameObject backgroundDoorClosed, backgroundDoorOpen;

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
        else if (doorOpen) { Debug.Log("Win condition"); }
        else if (hasPower && hasCard)
        {
            backgroundDoorClosed.SetActive(false);
            backgroundDoorOpen.SetActive(true);
            doorOpen = true;
        }
    }
}
