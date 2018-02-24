using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSource : Interactable
{
    public GameObject brokenCellCharged, powerCellFixed, backgroundPoweredDown, backgroundDoorClosed,
        exitDoor;

    bool hasCell = false;

    public override void OnMouseDown()
    {
        if (brokenCellCharged != null && brokenCellCharged.GetComponent<Collectable>().isSelected)
        {
            StartCoroutine(ShowElement(text[1]));
        }
        else if (powerCellFixed.GetComponent<Collectable>().isSelected)
        {
            Debug.Log("Powering up");
            powerCellFixed.GetComponent<Collectable>().inventory.Deselect();
            Destroy(powerCellFixed.gameObject);
            backgroundPoweredDown.SetActive(false);
            backgroundDoorClosed.SetActive(true);
            exitDoor.GetComponent<ExitDoor>().hasPower = true;
        }
        else if (!hasCell)
        {
            base.OnMouseDown(); 
        }
    }
}
