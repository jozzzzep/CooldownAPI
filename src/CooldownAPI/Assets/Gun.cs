using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CooldownAPI;

public class Gun : MonoBehaviour
{
    Cooldown cd_shooting;

    void Start()
    {
        cd_shooting = new Cooldown(3f);
    }

    void Update()
    {
        if (cd_shooting.IsActive == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
        Debug.Log("Cooldown timer: " + cd_shooting.Timer);
    }

    void Shoot()
    {
        Debug.Log("pew");
        cd_shooting.Activate();
    }
}
