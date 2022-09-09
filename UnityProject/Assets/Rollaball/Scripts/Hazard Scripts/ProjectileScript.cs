using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] [Range(1f, 5f)] private float projectileDestructionTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRidOfProjectileCoroutine());
    }
    
    IEnumerator GetRidOfProjectileCoroutine()
    {
        yield return new WaitForSeconds(projectileDestructionTime);
        Destroy(gameObject);
    }
}
