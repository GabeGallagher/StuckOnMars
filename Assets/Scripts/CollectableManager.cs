/* Author Gabriel B. Gallagher February 22 2018
 * 
 * Manages which collectables are selected from inventory and allows the player to place collectables
 * from inventory into objects they are meant to go in order to advnace the story
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public delegate void OnCollectableSelected();
    public OnCollectableSelected collectableSelectedObserver = null;

    public List<GameObject> collectablesList;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            collectablesList.Add(transform.GetChild(i).gameObject);
        }
    }
}
