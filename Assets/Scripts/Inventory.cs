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
        GameObject slot = new GameObject();

        for (int i = transform.childCount - 1; i >= 0; --i)
        {
            if (!transform.GetChild(i).gameObject.GetComponent<Collectable>())
            {
                slot = transform.GetChild(i).gameObject;
            }
        }
        //places collectable in inventory
        collectable.transform.parent = slot.transform;
        collectable.transform.localPosition = Vector2.zero;
    }
}
