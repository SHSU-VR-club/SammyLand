using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointCount; //Each target will have their own "point count"

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        Destroy(gameObject);
        Debug.Log($"Collided with {collision.gameObject.name}");
        Score.setScore(Score.getScore() + pointCount);
    }
}
