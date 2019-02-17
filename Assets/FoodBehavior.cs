using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    public float existingTime = 2.0f;

    public void Show()
    {
        GetComponent<Renderer>().enabled = true;
    }

    public void Hide()
    {
        GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Invoke("Hide", existingTime);
    }
}
