using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public List<GameObject> text;

    private void OnMouseDown()
    {
        Debug.Log("Do something with text, or something");
    }
}
