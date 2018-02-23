/* Author Gabriel B. Gallagher February 22 2018
 * 
 * Controls the logic in the charger station. Inherits Interactable and modifies it to allow the player
 * to place the charger in the charger station
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerStation : Interactable
{
    public Collectable charger;

    public override void OnMouseDown()
    {
        if (charger.isSelected)
        {
            Debug.Log("placed charger in station");
            for (int i = 0; i < transform.childCount; ++i)
            {
                if (transform.GetChild(i).GetComponent<SpriteRenderer>())
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            charger.inventory.Deselect();
            Destroy(charger.gameObject);
        }
        else
        {
            base.OnMouseDown(); 
        }
    }
}
