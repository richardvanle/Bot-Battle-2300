using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Robot : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public float fireVelocity;
    public float laserCooldownSeconds;
    private int currentSpawnIndex;

    public Transform robotTarget;
    [Tooltip("Order: Right | Left")]
    public List<Transform> laserSpawnPoints;
    public Laser laserPrefab;
    public Animator animator;
    [SerializeField] private TextMeshProUGUI robotHealthText;
    private bool isDead;

    public void FireLaser()
    {
        if (isDead)
        {
            return;
        }
        Debug.Log("FireLaser");
        Transform selectedSpawnPoint = laserSpawnPoints[currentSpawnIndex];
        Vector3 targetPosition = robotTarget.position + Vector3.down;
        Vector3 direction = (targetPosition - selectedSpawnPoint.position).normalized;

        Laser laser = Instantiate(laserPrefab, selectedSpawnPoint.position, Quaternion.LookRotation(direction));
        Rigidbody laserRigidbody = laser.GetComponent<Rigidbody>();
        laserRigidbody.velocity = direction * fireVelocity;

        StartCoroutine(nameof(LaserCooldown));
    }

    private IEnumerator LaserCooldown()
    {
        Debug.Log("Laser Cooldown Start");
        yield return new WaitForSeconds(laserCooldownSeconds);

        currentSpawnIndex = Random.Range(0, laserSpawnPoints.Count);
        animator.SetTrigger($"LaserChargeUp{currentSpawnIndex}");
        Debug.Log("Laser Cooldown Triggred");
    }

    private void Start()
    {
        currentHealth = maxHealth;
        robotHealthText.text = currentHealth.ToString();
        StartCoroutine(nameof(LaserCooldown));
    }

    private void Update()
    {
        transform.LookAt(robotTarget);

    }

    private void OnCollisionEnter(Collision other)
    {
        Laser laser = other.gameObject.GetComponent<Laser>();
        if (laser == null)
        {
            return;
        }
        currentHealth -= laser.damage;
        robotHealthText.text = currentHealth.ToString();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        enabled = false;
        animator.SetBool("isDead", true);
        Debug.Log("Robot dies");
    }
}