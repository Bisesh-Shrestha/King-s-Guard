using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject flamePrefab;


    // Update is called once per frame
    void Update()
    {
        Shoot();

    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(flamePrefab, firePoint.position, firePoint.rotation);
        }

    }
}
