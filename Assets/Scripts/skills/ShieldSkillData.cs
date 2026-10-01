using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewShield", menuName = "Skills/Shield")]
public class ShieldSkillData : SkillData
{
    [Header("Shield Settings")]
    public float shieldDuration = 2f;

    public override void Execute(SkillContext context)
    {
        context.CoroutineRunner.StartCoroutine(ShieldRoutine(context));
    }

    private IEnumerator ShieldRoutine(SkillContext context)
    {
        context.IsShielded = true;
        // ในอนาคต: เปิด VFX โล่ตรงนี้ (เช่น context.Transform.Find("ShieldVFX").gameObject.SetActive(true))

        yield return new WaitForSeconds(shieldDuration);

        context.IsShielded = false;
        // ปิด VFX โล่ตรงนี้
    }
}
