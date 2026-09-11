using UnityEngine;

[CreateAssetMenu(fileName = "NewMissile", menuName = "Skills/Missile")]
public class MissileSkillData : SkillData
{
    [Header("Missile Settings")]
    public GameObject missilePrefab;
    public float missileSpeed = 15f;
    public float missileDamage = 30f;

    public override void Execute(GameObject user)
    {
        PlayerAim aim = user.GetComponent<PlayerAim>();
        if (aim == null) return;

        Transform firePoint = user.transform; // หรือดึง firePoint จริงถ้ามี reference
        GameObject missileObj = Instantiate(
            missilePrefab,
            firePoint.position,
            Quaternion.LookRotation(aim.AimDirection, Vector3.up)
        );

        Projectile projectile = missileObj.GetComponent<Projectile>();
        projectile.Initialize(aim.AimDirection, missileSpeed, missileDamage, 5f);
    }
}
