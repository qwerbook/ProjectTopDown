using UnityEngine;

[CreateAssetMenu(fileName = "NewMissile", menuName = "Skills/Missile")]
public class MissileSkillData : SkillData
{
    [Header("Missile Settings")]
    public GameObject missilePrefab;
    public float missileSpeed = 15f;
    public float missileDamage = 30f;

    public override void Execute(SkillContext context)
    {
        if (missilePrefab == null) return;

        GameObject missileObj = Object.Instantiate(
            missilePrefab,
            context.Transform.position,
            Quaternion.LookRotation(context.Aim.AimDirection, Vector3.up)
        );

        Projectile projectile = missileObj.GetComponent<Projectile>();
        projectile.Initialize(context.Aim.AimDirection, missileSpeed, missileDamage, 5f);
    }
}
