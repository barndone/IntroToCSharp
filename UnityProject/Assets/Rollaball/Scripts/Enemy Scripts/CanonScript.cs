using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour
{
    [SerializeField][Range(1, 10)] float timeToWait = 3f;

    [SerializeField] [Range(1, 50)] float cannonForce = 10f;

    public GameObject cannonBallPrefab;
    public Transform firePoint;

    private float timer = 0f;

    private Vector3 initialVelocity = new Vector3(0,0,-1);


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToWait)
        {
            Fire();
            timer = 0f;
        }
    }

    private void Fire()
    {
        GameObject cannonBall = Instantiate(cannonBallPrefab, firePoint.position, Quaternion.identity);

        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
        rb.AddForce(initialVelocity * cannonForce, ForceMode.Impulse);
    }
}
