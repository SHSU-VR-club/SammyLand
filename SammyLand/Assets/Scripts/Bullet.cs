using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject gunReference;
    public float distFromGun;
    public float timeSpawn;
    public Gun gunScript;

    private void Awake()
    {
        timeSpawn = Time.time;
        gunReference = GameObject.Find("Gun");
        gunScript = gunReference.GetComponentInChildren<Gun>();
    }
    void Update()
    {
        distFromGun = (gunReference.transform.position - transform.position).magnitude;

        if (distFromGun >= gunScript.distBeforeDestroy || Time.time - timeSpawn > gunScript.timeBeforeDestroy)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
