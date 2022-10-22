using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PressableButton : MonoBehaviour
{
    public UnityEvent buttonPressedEvent;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            buttonPressedEvent?.Invoke();

        }
    }
}
