using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSource : Interactable
{
    public GameObject brokenCellCharged;

    bool hasCell = false;

    public override void OnMouseDown()
    {
        if (brokenCellCharged.GetComponent<Collectable>().isSelected)
        {
            StartCoroutine(ShowElement(text[1]));
        }
        else if (!hasCell)
        {
            base.OnMouseDown(); 
        }
    }
}
