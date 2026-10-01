using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewDash", menuName = "Skills/Dash")]
public class DashSkillData : SkillData
{
    [Header("Dash Settings")]
    public float dashDistance = 5f;
    public float dashDuration = 0.15f;

    public override void Execute(SkillContext context)
    {
        context.CoroutineRunner.StartCoroutine(DashRoutine(context));
    }

    private IEnumerator DashRoutine(SkillContext context)
    {
        context.Movement.Disable(); // ปิด movement ปกติชั่วคราวระหว่าง dash

        Vector3 direction = context.Transform.forward; // ใช้ทิศที่หันอยู่ (จาก PlayerAim)
        Vector3 startPos = context.Rigidbody.position;
        Vector3 endPos = startPos + direction * dashDistance;

        float elapsed = 0f;
        while (elapsed < dashDuration)
        {
            elapsed += Time.fixedDeltaTime;
            float t = elapsed / dashDuration;
            context.Rigidbody.MovePosition(Vector3.Lerp(startPos, endPos, t));
            yield return new WaitForFixedUpdate();
        }

        context.Movement.Enable();
    }
}
