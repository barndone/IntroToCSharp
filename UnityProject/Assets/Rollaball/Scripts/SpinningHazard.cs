using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningHazard : MonoBehaviour
{
    public Vector3 rotationVector = new Vector3(0.0f, 10.0f, 0.0f);

    void Update()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }
}
