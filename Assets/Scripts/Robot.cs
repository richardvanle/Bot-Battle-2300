using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision other)
    {
        Laser laser = other.gameObject.GetComponent<Laser>();
        if (laser == null)
        {
            return;
        }
        currentHealth -= laser.damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("isDead", true);
        Debug.Log("Robot dies");
    }
}