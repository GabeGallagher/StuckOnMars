using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    Inventory inventory;

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        inventory = transform.parent.GetComponent<Collectable>().inventory;
    }

    void Collect()
    {
        anim.SetBool("isCollected", false);
        //place parent game object in inventory
        inventory.Place(gameObject.transform.parent.gameObject);
    }
}
