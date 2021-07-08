using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    private bool isPlayerDead;


    // Start is called before the first frame update
    void Start()
    {
        SetPlayerHealth(playerMaxHealth);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("OnControllerColliderHit " + hit.gameObject.name);
        Laser laser = hit.collider.GetComponent<Laser>();
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

}


