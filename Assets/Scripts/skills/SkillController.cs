using UnityEngine;
using UnityEngine.InputSystem;

public class SkillController : MonoBehaviour
{
    [System.Serializable]
    public class SkillSlot
    {
        public SkillData skillData;
        [HideInInspector] public float cooldownTimer;
    }

    [SerializeField] private SkillSlot[] skillSlots = new SkillSlot[3]; // Q, E, Space

    private void Update()
    {
        for (int i = 0; i < skillSlots.Length; i++)
        {
            if (skillSlots[i].cooldownTimer > 0f)
            {
                skillSlots[i].cooldownTimer -= Time.deltaTime;
            }
        }

        // ตัวอย่าง polling แบบง่าย ใช้ keyboard โดยตรง
        // (ในระบบจริงแนะนำผูกผ่าน Input Action เหมือน Movement)
        if (Keyboard.current.qKey.wasPressedThisFrame) TryUseSkill(0);
        if (Keyboard.current.eKey.wasPressedThisFrame) TryUseSkill(1);
        if (Keyboard.current.spaceKey.wasPressedThisFrame) TryUseSkill(2);
    }

    private void TryUseSkill(int index)
    {
        if (index >= skillSlots.Length) return;

        SkillSlot slot = skillSlots[index];
        if (slot.skillData == null || slot.cooldownTimer > 0f) return;

        slot.skillData.Execute(gameObject);
        slot.cooldownTimer = slot.skillData.cooldown;
    }

    // เผื่อ UI อยากโชว์ cooldown percentage
    public float GetCooldownNormalized(int index)
    {
        if (index >= skillSlots.Length || skillSlots[index].skillData == null) return 0f;
        return skillSlots[index].cooldownTimer / skillSlots[index].skillData.cooldown;
    }
}
