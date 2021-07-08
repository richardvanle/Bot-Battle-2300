using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;

    [SerializeField] private TextMeshProUGUI playerHealthText;

    [SerializeField]
    private Transform xrCameraTransform;
    [SerializeField]
    private CapsuleCollider bodyCollider;


    private bool isPlayerDead;


    // Start is called before the first frame update
    void Start()
    {
        SetPlayerHealth(playerMaxHealth);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnControllerColliderHit " + other.gameObject.name);
        Laser laser = other.collider.GetComponent<Laser>();
        if (laser == null)
        {
            return;
        }
        Debug.Log("OnControllerColliderHit " + laser.damage);
        SetPlayerHealth(playerCurrentHealth - laser.damage);

        if (playerCurrentHealth <= 0)
        {
            PlayerDie();
        }

    }
    private void PlayerDie()
    {
        isPlayerDead = true;
        enabled = false;
        Debug.Log("Player is dead");
    }

    private void SetPlayerHealth(int newHealth)
    {
        playerCurrentHealth = newHealth;
        playerHealthText.text = playerCurrentHealth.ToString();

        Debug.Log("SetPlayerHealth" + playerCurrentHealth);
        // Put audio cues here for laser
    }

    private void LateUpdate()
    {
        var center = bodyCollider.transform.InverseTransformPoint(xrCameraTransform.position);
        center.y = bodyCollider.bounds.center.y;
        bodyCollider.center = center;
    }
}


