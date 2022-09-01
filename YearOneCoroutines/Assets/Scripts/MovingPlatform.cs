using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float endY;
    float startY;
    [SerializeField] [Range(1, 10)] float distanceToMove = 3;

    bool isMovingUp = true;
    [SerializeField] [Range(1, 10)] float moveSpeed = 1.6f;

    //convert to either kind of movement rather than just vertical
    //use vector3 instead of float?

    Vector3 startPos;
    Vector3 endPos;

    [SerializeField] Vector3 movementVector = new Vector3(0,3);


    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        endY = transform.position.y + distanceToMove;

        startPos = transform.position;
        endPos = transform.position + movementVector;
    }

    // Update is called once per frame
    void Update()
    {
        int mod = (isMovingUp)? 1 : -1;
        transform.position += Vector3.up * moveSpeed * mod * Time.deltaTime;

        
        if (isMovingUp)
        {
            if(transform.position.y > endY)
            {
                transform.position = new Vector3(transform.position.x, endY, transform.position.z);             //ensures we actually end at our end position
                isMovingUp = false;
            }
        }
        else
        {
            if (transform.position.y < startY)
            {
                transform.position = new Vector3(transform.position.x, startY, transform.position.z);           //ensures we actually end at our start position
                isMovingUp = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position + (Vector3.up * distanceToMove), new Vector3(transform.lossyScale.x, transform.lossyScale.y, 0.1f));
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.up * distanceToMove));
    }
}
