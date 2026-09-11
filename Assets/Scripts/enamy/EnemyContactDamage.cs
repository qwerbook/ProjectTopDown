using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(enemyData.contactDamage);
        }
    }
}
