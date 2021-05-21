using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public Transform firePoint;
    public Laser laserPrefab;
    public float velocity;

    public void OnSelectEntered()
    {
        Fire();
        Debug.Log("Right trigger fired OnSelectEntered");
    }
    private void Fire()
    {
        Laser laser = Instantiate(laserPrefab, firePoint.position, Quaternion.LookRotation(firePoint.forward));
        Rigidbody laserRigidbody = laser.GetComponent<Rigidbody>();
        laserRigidbody.AddForce(firePoint.forward * velocity, ForceMode.Impulse);
        Debug.Log("Right trigger fired Fire");
    }
}
