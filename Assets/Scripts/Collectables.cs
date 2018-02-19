using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Clicked " + name);
    }
}
