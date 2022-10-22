using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonCol : MonoBehaviour
{
    public int buttonIndex;
    public Path pathManager;
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision detected. Object: " + other.gameObject.ToString());
        if (other.gameObject.tag == "Player")
        {
            switch (buttonIndex)
            {
                case 0:
                    pathManager.touch = 1;
                    break;
                case 1:
                    pathManager.touch = 2;
                    break;
            }

        }
    }
    public void OnTriggerExit(Collider collider)
    {
        pathManager.touch = 0;
    }


    private void Update()
    {
        switch (pathManager.touch)
        {
            case 0:

                break;
            case 1:
                //Debug.Log("Accelerating");
                speedUp();
                break;
            case 2:
                //Debug.Log("Decelerating");
                speedDown();
                break;
        }
        
        //actual spaghetti code
        if (Input.GetKeyDown(KeyCode.W))
        {
            speedUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            speedDown();
        }
        //Min Max stuff
        if (pathManager.normalizer < pathManager.MIN)
        {
            pathManager.normalizer = pathManager.MIN;
        }
        else if (pathManager.normalizer > pathManager.MAX)
        {
            pathManager.normalizer = pathManager.MAX;
        }
    }

    public void speedUp()
    {
        if (pathManager.normalizer < pathManager.MAX)
        {
            pathManager.normalizer += pathManager.deltaSpeed;
        }
    }

    public void speedDown()
    {
        if (pathManager.normalizer > pathManager.MIN)
        {
            pathManager.normalizer -= pathManager.deltaSpeed;
        }
    }
}
