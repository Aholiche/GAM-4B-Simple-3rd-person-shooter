using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System;

public class Target : MonoBehaviour
{
    public float health, maxHealth = 50f;
    public Transform player;
    public NavMeshAgent enemy;
    public Text enemyCountText;

    [SerializeField] FloatingHealthBar healthBar;

    public event Action<float> Damaged = delegate { };

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    void Update()
    {
        enemy.SetDestination(player.position);
    }

    //Used for observer to observe the changes made to healthbars
    private void OnEnable()
    {
        //subscribing to get notified when damage has occured
        health.Damaged += TakeDamage;
    }

    private void OnDisable()
    {
        //Unsubscribing from event
        health.Damaged -= TakeDamage;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        Damaged.Invoke(amount);
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0f)
        {
            Dead();
        }
    }

    void Dead()
    {
        Destroy(gameObject);

    }
}
