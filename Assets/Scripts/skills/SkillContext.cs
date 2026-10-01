using UnityEngine;

public class SkillContext
{
    public Transform Transform;
    public Rigidbody Rigidbody;
    public InputSystem_Actions Movement;
    public PlayerAim Aim;
    public MonoBehaviour CoroutineRunner;

    // State ของ skill ที่ต้องให้ระบบอื่นอ่านได้ (เก็บไว้ที่นี่ ไม่ใช่ใน SkillData)
    public bool IsShielded;

    public SkillContext(GameObject player)
    {
        Transform = player.transform;
        Rigidbody = player.GetComponent<Rigidbody>();
        Movement = player.GetComponent<InputSystem_Actions>();
        Aim = player.GetComponent<PlayerAim>();
        CoroutineRunner = player.GetComponent<SkillController>();
    }
}
