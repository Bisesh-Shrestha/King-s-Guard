using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject flamePrefab;
    public bool checkprojectile = false;


    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (checkprojectile)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(flamePrefab, firePoint.position, firePoint.rotation);
            }

        }     
    }
}
