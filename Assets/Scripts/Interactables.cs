/* Author Gabriel B. Gallagher February 19th 2018
 * 
 * Parent class for interactable game objects. This are objects that the player can click on, but
 * do not go to their inventory. Examples include doors that need to get open, crates that need to be
 * moved, lights that need to be turned on, etc.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public List<GameObject> text;

    //how many seconds text should appear on the screen
    public int waitSeconds = 3;

    public bool hasPower;

    //shows text items when the player presses interactable
    public IEnumerator ShowElement(GameObject textItem)
    {
        textItem.SetActive(true);
        yield return new WaitForSeconds(waitSeconds);
        textItem.SetActive(false);
    }

    public virtual void OnMouseDown()
    {
        if (!hasPower)
        {
            StartCoroutine(ShowElement(text[0]));
        }
    }
}
