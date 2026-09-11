using UnityEngine;

[CreateAssetMenu(fileName = "NewDash", menuName = "Skills/Dash")]
public class DashSkillData : SkillData
{
    [Header("Dash Settings")]
    public float dashDistance = 5f;
    public float dashDuration = 0.15f;

    public override void Execute(GameObject user)
    {
        DashExecutor executor = user.GetComponent<DashExecutor>();
        if (executor != null)
        {
            executor.StartDash(dashDistance, dashDuration);
        }
    }
}
