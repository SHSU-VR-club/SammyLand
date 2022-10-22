using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
[RequireComponent(typeof(AudioSource))]

public class handC : MonoBehaviour
{
   

    public float dist = 2f;
    public GameObject end;
    public bool RH;
    public float vLen;
    public InputDevice controllerRef;
    public Gun gun;

    void Update() { 

        controllerRef.TryGetFeatureValue(CommonUsages.trigger, out  float val);
        if (val > 0.5)
        {
            gun.OnShoot();
            Debug.Log("Did a thing with the thing that was doing a thing");
        }
    }

}
