using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float duration;
    public int damage;
    public Animator animator;
    public Rigidbody laserRigidBody;

    public void Update()
    {
        duration -= Time.deltaTime;
        if (duration < 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        // Play hit animation
        // Create animation with parameter "laserHit" a for Laser Prefab (idle and explosion/particle)
        animator.SetTrigger("laserHit");
        // Disable collider
        laserRigidBody.detectCollisions = false;
        laserRigidBody.velocity = Vector3.zero;
        laserRigidBody.angularVelocity = Vector3.zero;
        enabled = false;
    }

    public void OnExplodeAnimationFinished()
    {
        Destroy(gameObject);
    }
}
