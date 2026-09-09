using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyData enemyData;

    private float currentHealth;

    public event Action OnDeath; // ให้ระบบอื่น (Spawner, UI, Score) subscribe ได้

    private void Awake()
    {
        currentHealth = enemyData.maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
        // ในอนาคต: เล่น death VFX, drop item, ส่ง score ผ่าน event นี้แทนการเขียนตรงนี้เลย
    }
}
