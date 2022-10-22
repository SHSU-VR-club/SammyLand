using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PlayerController : MonoBehaviour
{
    public GameObject sun;
    public float horizontal;
    public float vertical;
    public float speedLimit;
    public Vector3 point;

    private float weird_Y_offset = 1.270955f;
    private float weird_Z_offset = 1.784013f;

    public List<UnityEngine.XR.InputDevices> devices;
    private void Start()
    {
        // devices = UnityEngine.XR.InputDevices.GetDeviceAtXRNode();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = new Vector3(-sun.GetComponent<manager>().radius, sun.transform.position.y - weird_Y_offset, sun.transform.position.z - weird_Z_offset);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(sun.GetComponent<manager>().radius, sun.transform.position.y - weird_Y_offset, sun.transform.position.z - weird_Z_offset);
        }


    
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        transform.position += Vector3.right * horizontal * speedLimit;
        transform.position += Vector3.forward * vertical * speedLimit;
        //VR CONTROLS
    }

    private void OnDrawGizmos()
    {
        //Input

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Handles.color = new Color(1, 0, 1); // purple?
            point = transform.position;
        }

        // Draw from Waypoint
        Handles.color = Color.yellow;
        Handles.DrawLine(point, transform.position);



    }
}
