/* Author Gabriel B. Gallagher February 19 2018
 * 
 * Inherits from Interactable.cs and adds an additional text bar for when the power is on, but the
 * player does not have the card. Also contains logic to allow the player to open the door when the
 * power is on and keycard is inventory, and then tap on the opened door to leave the level.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : Interactable
{
    public bool hasCard, doorOpen;

    public GameObject backgroundDoorClosed, backgroundDoorOpen; 
        
    public LevelManager levelManager;

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
        else if (doorOpen) //if the door is open and the player taps it, the game is won!
        {
            levelManager.LoadNextLevel();
        }
        //if the power is on and player has Keycard in inventory, door opens
        else if (hasPower && hasCard) 
        {
            backgroundDoorClosed.SetActive(false);
            backgroundDoorOpen.SetActive(true);
            doorOpen = true;
        }
    }
}
