using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{

    [SerializeField] Color newColor;
    [SerializeField] Renderer rend;

    private void Start()
    {
        rend.material.SetColor("_Color", newColor);
    }

    void ChangeColor()
    {

    }
}
