using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject projectilePrefab;


    // Update is called once per frame
    void Update()
    {

        // Button: enter/return
        if (Input.GetButtonDown("Fire1"))
        {
            Throw();
        }
    }

    void Throw()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
