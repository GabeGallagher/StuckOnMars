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
    public Collectable charger, brokenCell;

    public GameObject brokenCellChargedPrefab;

    public bool hasCharger = false;

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
            hasCharger = true;
        }
        else if (brokenCell.isSelected && hasCharger)
        {
            Transform collectablesParent = null;
            for (int i = 0; i < transform.parent.childCount; ++i)
            {
                if (transform.parent.GetChild(i).tag == "CollectablesManager")
                {
                    collectablesParent = transform.parent.GetChild(i);
                }
            }
            GameObject brokenCellCharged = Instantiate(brokenCellChargedPrefab, collectablesParent) as
                GameObject;
            brokenCellCharged.GetComponent<Collectable>().inventory = 
                brokenCell.GetComponent<Collectable>().inventory;
            brokenCell.inventory.Deselect();
            Destroy(brokenCell.gameObject);

            for (int i = 0; i < brokenCellCharged.transform.childCount; ++i)
            {
                if (brokenCellCharged.transform.GetChild(i).GetComponent<Animator>())
                {
                    brokenCellCharged.transform.GetChild(i).GetComponent<Animator>().SetBool(
                        "isCollected", true);
                }
            }
            brokenCellCharged.GetComponent<Collectable>().isCollected = true;

            //assign brokenCellCharged to the power source object so that it can be placed later
            GameObject powerSource = GameObject.Find("PowerSource");
            powerSource.GetComponent<PowerSource>().brokenCellCharged = brokenCellCharged;
        }
        else if (!hasCharger)
        {
            base.OnMouseDown(); 
        }
    }
}
