using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtRobotGun : MonoBehaviour
{
    public Transform gunTarget;

    void Update()
    {
        transform.LookAt(gunTarget);
    }
}