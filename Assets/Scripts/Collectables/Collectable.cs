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

    public int waitSeconds = 3;

    public bool isPlaced = false, isSelected = false, isCollected = false;

    GameObject nameTextParent;

    private void Start()
    {
        nameTextParent = GameObject.Find("CollectablesText");
    }

    //shows text items when the player presses interactable
    public IEnumerator ShowElement(GameObject textItem)
    {
        textItem.SetActive(true);
        yield return new WaitForSeconds(waitSeconds);
        textItem.SetActive(false);
    }

    //Shows the name of this collectable at top of canvas when the player clicks on it
    void ShowName()
    {
        GameObject nameText = null;

        for (int i = 0; i < nameTextParent.transform.childCount; ++i)
        {
            if (nameTextParent.transform.GetChild(i).name == name)
            {
                Debug.Log("Collectable name: " + name);
                Debug.Log("Child name: " + nameTextParent.transform.GetChild(i).name);
                nameText = nameTextParent.transform.GetChild(i).gameObject;
                Debug.Log("Text name: " + nameText.name);
            }
        }
        StartCoroutine(ShowElement(nameText));

        if (nameText != null)
        {
            nameText.SetActive(true); 
        }
        else
        {
            Debug.Log("There was an error getting the name text");
        }
    }
    
    public virtual void OnMouseDown()
    {
        inventory.Deselect();

        ShowName();

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
