using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("Info")]
    public string weaponName;

    [Header("Combat")]
    public float damage = 10f;
    public float fireRate = 0.15f;      // fireRate per second

    [Header("Projectile")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 20f;
    public float projectileLifetime = 3f;
}
