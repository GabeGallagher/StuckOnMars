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

    public Inventory inventory;

    public GameObject inventorySlot = null;

    public bool isPlaced = false, isSelected = false, isCollected = false;
    
    private void OnMouseDown()
    {
        inventory.Deselect();

        if (!isCollected)
        {
            transform.position = Vector2.zero;
            anim.SetBool("isCollected", true);
            isCollected = true;
        }

        if (isCollected && isPlaced)
        {
            inventory.ChangeColor(gameObject.GetComponent<Collectable>());
            isSelected = true;
        }
    }
}
