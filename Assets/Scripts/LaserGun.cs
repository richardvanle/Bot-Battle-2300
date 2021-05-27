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
    }
    private void Fire()
    {
        Laser laser = Instantiate(laserPrefab, firePoint.position, Quaternion.LookRotation(firePoint.forward));
        Rigidbody laserRigidbody = laser.GetComponent<Rigidbody>();
        laserRigidbody.AddForce(firePoint.forward * velocity, ForceMode.Impulse);
    }
}
