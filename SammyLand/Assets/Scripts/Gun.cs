using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    public Transform endPoint;
    public Transform endPoint2;
    public Vector3 dirToShoot;
    public GameObject bullet;
    public float bulletSpeed = 800f;
    public float distBeforeDestroy = 30f;
    public float timeBeforeDestroy = 10f;
    public Transform rHpos;

    // hold
    public bool held;

    // Fire rate & modifiers
    bool canShoot;
    float timeOfShot;
    public float shotsPerSecond = 2f;

    void OnDrawGizmos()
    {
        dirToShoot = (endPoint2.position - endPoint.position).normalized; //Normalize for direction.
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(endPoint.transform.position, dirToShoot + endPoint.position);
    }

    public void OnShoot()
    {
        if (!canShoot)
            return;

        GameObject currShot = Instantiate(bullet);
        currShot.transform.position = endPoint.position;
        currShot.GetComponent<Rigidbody>().AddForce(dirToShoot * bulletSpeed); ;

        canShoot = false;
        timeOfShot = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            OnShoot();
        }
        if(timeOfShot + 1/shotsPerSecond < Time.time)
        {
            canShoot = true;
        }
    }
}
