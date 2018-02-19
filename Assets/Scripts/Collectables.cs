/* Author Gabriel B. Gallagher February 19th 2018
 * 
 * Controls the logic for the in scene collectables. Allows player to click on items in game and 
 * performs logic, such as calling the animation and storing them in the inventory
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public Animator anim;

    bool isCollected = false;

    private void OnMouseDown()
    {
        Debug.Log("Clicked " + name);
        if (!isCollected)
        {
            transform.position = Vector2.zero;
            anim.SetBool("isCollected", true);
            isCollected = true;
        }
    }
}
