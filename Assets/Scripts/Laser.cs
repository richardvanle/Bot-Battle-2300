using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float duration;
    public int damage;
    public Animator animator;
    public Rigidbody laserRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

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

        Debug.Log("Laser hit " + other.gameObject.name);
        animator.SetBool("laserHit", true);
    
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
