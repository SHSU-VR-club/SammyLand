using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class manager : MonoBehaviour
{
    // Object References
    public GameObject ePos1;
    public GameObject ePos2;
    public GameObject star;

    // Data Storage
    public float radius;
    public float dist_e1_to_star;
    public float dist_e2_to_star;




    void OnDrawGizmos()
    {

        //Base
        Handles.color = Color.red;
        Handles.DrawLine(ePos1.transform.position, ePos2.transform.position);

        ePos1.transform.position = new Vector3(-radius, transform.position.y, transform.position.z);
        ePos2.transform.position = new Vector3(radius, transform.position.y, transform.position.z);

        //Dist to Star
        Handles.color = Color.blue;
        Handles.DrawLine(ePos1.transform.position, star.transform.position);
        Handles.DrawLine(ePos2.transform.position, star.transform.position);

        // Distance to star calculations...
        dist_e1_to_star = (star.transform.position - ePos1.transform.position).magnitude;
        dist_e2_to_star = (star.transform.position - ePos2.transform.position).magnitude;
        //Should be the same unless there is a change in sun's rotation

    }

    private void Update()
    {

    }
}
