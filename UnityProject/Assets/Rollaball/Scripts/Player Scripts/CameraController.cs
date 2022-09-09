using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        //calculate the offset for the camera based on current position of player
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //update position based off of the offset and the player position
        transform.position = player.transform.position + offset;
    }
}
