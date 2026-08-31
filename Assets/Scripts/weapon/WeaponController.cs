using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private WeaponData currentWeapon;
    [SerializeField] private Transform firePoint; // ตำแหน่งที่กระสุนเกิด (ปลายปืน)

    private PlayerAim playerAim;
    private float fireCooldownTimer;
    private bool isFiring;

    private void Awake()
    {
        playerAim = GetComponent<PlayerAim>(); // ดึงทิศเล็งจากระบบที่ทำไปแล้ว
    }

    private void Update()
    {
        HandleFireInput();

        fireCooldownTimer -= Time.deltaTime;

        if (isFiring && fireCooldownTimer <= 0f)
        {
            Fire();
            fireCooldownTimer = currentWeapon.fireRate;
        }
    }

    private void HandleFireInput()
    {
        // อ่านปุ่มซ้ายเมาส์แบบ polling ตรงๆ (คล้ายกับที่ทำใน PlayerAim)
        isFiring = Mouse.current != null && Mouse.current.leftButton.isPressed;
    }

    private void Fire()
    {
        if (currentWeapon.projectilePrefab == null) return;

        GameObject bulletObj = Instantiate(
            currentWeapon.projectilePrefab,
            firePoint.position,
            Quaternion.LookRotation(playerAim.AimDirection, Vector3.up)
        );

        Projectile projectile = bulletObj.GetComponent<Projectile>();
        projectile.Initialize(
            playerAim.AimDirection,
            currentWeapon.projectileSpeed,
            currentWeapon.damage,
            currentWeapon.projectileLifetime
        );
    }

    // เผื่ออนาคตเปลี่ยนอาวุธ (ตาม Loadout system)
    public void EquipWeapon(WeaponData newWeapon)
    {
        currentWeapon = newWeapon;
    }
}
