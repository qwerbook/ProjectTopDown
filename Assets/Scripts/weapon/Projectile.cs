using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private float damage;
    private float lifetime;
    private Rigidbody rb;

    public void Initialize(Vector3 direction, float speed, float damageAmount, float life)
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.linearVelocity = direction * speed; // Unity 6 ใช้ linearVelocity (เดิมชื่อ velocity)

        damage = damageAmount;
        lifetime = life;

        Destroy(gameObject, lifetime); // ป้องกันกระสุนหลงเหลืออยู่ตลอดไป
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage);
            Destroy(gameObject); // ชนแล้วหาย (ถ้าอยากให้ทะลุ ค่อยปรับทีหลัง)
        }
    }
}
