using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Inventory inventory;

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Collect()
    {
        anim.SetBool("isCollected", false);
        //place parent game object in inventory
        inventory.Place(gameObject.transform.parent.gameObject);
    }
}
