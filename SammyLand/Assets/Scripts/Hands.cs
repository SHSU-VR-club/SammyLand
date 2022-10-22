using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class Hands : MonoBehaviour
{   
    public InputDevice rController;
    List<InputDevice> devices = new List<InputDevice>();
    public GameObject rHand;

    //Interaction Managemenet
    public Gun gun;

    void Update()
    {
        InputDevices.GetDevices(devices);
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller, devices);
      

        if (devices.Count > 0)
        {
            rController = devices[0];
            Debug.Log(devices[0].name);
        }

        rController.TryGetFeatureValue(CommonUsages.trigger, out float val);
        //Semi-Auto or Auto?
        //Reload?
        //Ammo?
        rController.TryGetFeatureValue(CommonUsages.gripButton, out bool grip);
        if (grip)
        {
            gun.held = true;
        }
        else
        {
            gun.held = false;
        }
        if (gun.held)
        {
            gun.gameObject.transform.position = rHand.transform.position;
            gun.gameObject.transform.rotation = rHand.transform.rotation;
            // :)
            if (val > 0.5)
            {
                gun.OnShoot();
                Debug.Log("Did a thing with the thing that was doing a thing");
            }
        }
    }
}
