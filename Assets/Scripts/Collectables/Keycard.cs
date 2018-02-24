/* Author Gabriel B. Gallagher February 24 2018
 * 
 * Inherits from Collectable.cs and simply tells the Exit Door interactable that the keycard has been
 * collected when the player collects the keycard. This allows the player to leave the level when the
 * power has been turned on.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : Collectable
{
    public ExitDoor exitDoor;

    public override void OnMouseDown()
    {
        if (!isCollected) { exitDoor.hasCard = true; }

        base.OnMouseDown();
    }
}
