using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtRobotBody : MonoBehaviour
{
    public Transform robotTarget;

    void Update()
    {
        transform.LookAt(robotTarget);

    }

}


