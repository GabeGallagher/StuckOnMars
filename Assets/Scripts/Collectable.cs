/* Author Gabriel B. Gallagher February 19th 2018
 * 
 * Controls the logic for the in scene collectables. Allows player to click on items in game and 
 * performs logic, such as calling the animation and storing them in the inventory
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Animator anim;

    public bool isCollected = false;
    public bool isPlaced = false;

    private void OnMouseDown()
    {
        if (!isCollected)
        {
            transform.position = Vector2.zero;
            anim.SetBool("isCollected", true);
            isCollected = true;
        }

        if (isCollected && isPlaced)
        {
            Debug.Log("Do action");
        }
    }
}
