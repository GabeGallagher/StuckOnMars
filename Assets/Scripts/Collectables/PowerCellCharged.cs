using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCellCharged : Collectable
{
    public GameObject powerCellFixedPrefab;

    Collectable tape = null;

    private void Start()
    {
        tape = GameObject.Find("Tape").GetComponent<Collectable>();
    }

    public override void OnMouseDown()
    {
        if(tape != null && tape.isSelected)
        {
            Destroy(tape.gameObject);
            Transform collectablesParent = null;
            for (int i = 0; i < transform.parent.childCount; ++i)
            {
                if (transform.parent.GetChild(i).tag == "CollectablesManager")
                {
                    collectablesParent = transform.parent.GetChild(i);
                }
            }
            GameObject powerCellFixed = Instantiate(powerCellFixedPrefab, collectablesParent) as 
                GameObject;
            powerCellFixed.GetComponent<Collectable>().inventory = inventory;
            inventory.Deselect();
            powerCellFixed.GetComponent<Collectable>().anim.SetBool("isCollected", true);
            powerCellFixed.GetComponent<Collectable>().isCollected = true;

            //place fixed cell in power source
            GameObject powerSource = GameObject.Find("PowerSource");
            powerSource.GetComponent<PowerSource>().powerCellFixed = powerCellFixed;
            powerSource.GetComponent<PowerSource>().brokenCellCharged = null;
            Destroy(gameObject);
        }
        else
        {
            base.OnMouseDown(); 
        }
    }
}
