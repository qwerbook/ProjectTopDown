using UnityEngine;

public abstract class SkillData : ScriptableObject
{
    [Header("Info")]
    public string skillName;
    public float cooldown = 5f;

    // แต่ละ skill ต้องกำหนดเองว่า "ทำงานยังไงเมื่อถูกใช้"
    public abstract void Execute(GameObject user);
}
