using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    //Static points?
    public List<GameObject> nodes;
    public GameObject currentNode;
    public GameObject previousNode;
    public GameObject nextNode;
    [Range(1, 9)] //Too lazy to do exception handling
    public int currentIndex;
    public GameObject player;
    public float normalizer;
    public float deltaSpeed;
    public float MAX = 2;
    public float MIN = 0;



    public int touch; //0=none 1=green 2=red

    // :(
    // vectors aren't normalized so speed changes based on the LENGTH of the vector
    // can also change speed by setting a switch for currentIndex and altering the normalizer value
    public float lerp;
    private void Start()
    {
        currentIndex = 1;
    }


    private void OnDrawGizmos()
    {
        currentNode = nodes[currentIndex];
        previousNode = nodes[currentIndex - 1]; //Totally needs Out of bound checks
        nextNode = nodes[currentIndex + 1];
        Gizmos.color = Color.red;
        Gizmos.DrawLine(previousNode.transform.position, currentNode.transform.position);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(currentNode.transform.position, nextNode.transform.position);

        Gizmos.color = Color.cyan;
        for (int x = 0; x < nodes.Count-1; x++)
        {
            Gizmos.DrawLine(nodes[x].transform.position, nodes[x+1].transform.position);
        }

        //bullshit lerp sequence

        //should work with 3dimensional vectors?
        if (lerp != 1) //SHOULD fix glitchy teleport-y bug
        {
           // player.transform.position = Vector3.Lerp(currentNode.transform.position, nextNode.transform.position, lerp);
            player.transform.position = Vector3.MoveTowards(currentNode.transform.position, nextNode.transform.position, deltaSpeed);
            // player.transform.position = Vector3.Lerp(currentNode.transform.position, nextNode.transform.position, Time.deltaTime);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.LookRotation(nextNode.transform.position - player.transform.position), 1);
        }

        if (lerp >= 1)
        {
            currentIndex++;
            lerp = 0;
        }

        if (currentIndex == 19) // currently loops, will probably just end at the final index and then loop for the next person on button press
        {
            currentIndex = 1;
        }
        //lerp is always increasing (always moving)
        lerp += .01f * normalizer;
       
        //Set if-exception-spaghetti for nodes (or maybe just a switch)
    }
}
