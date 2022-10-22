using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offsetmanager : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 5);
    }
}
