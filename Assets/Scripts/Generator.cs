using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Interactables
{
    public override void OnMouseDown()
    {
        if (!base.hasPower)
        {
            StartCoroutine(base.ShowElement(base.text[0]));
        }
    }
}
