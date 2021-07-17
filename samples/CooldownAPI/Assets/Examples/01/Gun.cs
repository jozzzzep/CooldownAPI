using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CooldownAPI;

public class Gun : MonoBehaviour
{
    // initialize the cooldown
    Cooldown cd_shooting;

    void Start()
    {
        // allocate the cooldown
        cd_shooting = new Cooldown(3f);
    }

    void Update()
    {
        // check if cooldown is not active (player can shoot)
        if (cd_shooting.IsActive == false)
        {
            // check if player pressed left mouse button
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }

        // debug the cooldown's timer
        Debug.Log("Cooldown timer: " + cd_shooting.Timer);
    }

    void Shoot()
    {
        Debug.Log("pew");
        // activate cooldown
        cd_shooting.Activate();
    }
}
