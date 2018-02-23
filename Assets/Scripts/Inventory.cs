/* Author Gabriel B. Gallagher February 19th 2018
 * 
 * Controls the inventory UI. Currently just places items in the inventory and allows player to select
 * them.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public void Place(GameObject collectable)
    {
        Debug.Log("Placing: " + collectable.name);

        GameObject targetSlot = new GameObject();

        for (int i = 0; i < transform.childCount; ++i)
        {
            GameObject slot = transform.GetChild(i).gameObject;
            Debug.Log("At " + slot.name);
            bool hasCollectable = false;

            for (int j = 0; j < slot.transform.childCount; ++j)
            {
                Transform child = slot.transform.GetChild(j);

                Debug.Log("At " + slot.transform.GetChild(j));

                if (child.GetComponent<Collectable>())
                {
                    //if we find a collectable in this slot, exit the loop
                    Debug.Log("Found a collectable");
                    hasCollectable = true;
                    j = slot.transform.childCount;
                }
            }

            if (!hasCollectable)
            {
                i = transform.childCount;
                targetSlot = slot;
            }
        }
        //places collectable in inventory
        collectable.transform.parent = targetSlot.transform;
        collectable.transform.localPosition = Vector2.zero;
        collectable.GetComponent<Collectable>().isPlaced = true;
        collectable.GetComponent<Collectable>().inventorySlot = targetSlot;
    }

    public void Deselect()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
            if (transform.GetChild(i).childCount > 1)
            {
                for (int j = 1; j < transform.GetChild(i).childCount; ++j)
                {
                    if (transform.GetChild(i).GetChild(j).GetComponent<Collectable>())
                    {
                        transform.GetChild(i).GetChild(j).GetComponent<Collectable>().isSelected = false;
                    }
                }
            }
        }
    }

    //Changes color of inventory slot and deselects item
    public void ChangeColor(Collectable collectable)
    {
        if (collectable.isPlaced)
        {
            collectable.inventorySlot.transform.GetChild(0).GetComponent<SpriteRenderer>().color =
                Color.yellow;
        }
    }
}
