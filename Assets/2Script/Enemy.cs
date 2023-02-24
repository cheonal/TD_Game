using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float startHelath = 100;
    public float health;
    public int worth = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image HealthBar;

    private bool isDead = false;
    void Start()
    {
        health = startHelath;
        speed = startSpeed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        HealthBar.fillAmount = health / startHelath;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
    }
    void Die()
    {
        isDead = true;
        PlayerStats.Money += worth;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlives--;

        Destroy(gameObject);
    }

}
