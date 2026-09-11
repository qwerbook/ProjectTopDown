using UnityEngine;

[CreateAssetMenu(fileName = "NewShield", menuName = "Skills/Shield")]
public class ShieldSkillData : SkillData
{
    [Header("Shield Settings")]
    public float shieldDuration = 2f;

    public override void Execute(GameObject user)
    {
        ShieldExecutor executor = user.GetComponent<ShieldExecutor>();
        if (executor != null)
        {
            executor.ActivateShield(shieldDuration);
        }
    }
}
