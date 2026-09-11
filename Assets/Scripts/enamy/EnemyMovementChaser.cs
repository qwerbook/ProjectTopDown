using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovementChaser : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    private Rigidbody rb;
    private Transform target; // อ้างอิงผู้เล่น

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Start()
    {
        // วิธีง่ายสุดตอนนี้: หา Player ผ่าน Tag
        // ในอนาคตอาจเปลี่ยนเป็นรับ reference จาก Spawner แทนการค้นหาเองทุกตัว
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
        }
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0f;
        direction.Normalize();

        rb.MovePosition(rb.position + direction * enemyData.moveSpeed * Time.fixedDeltaTime);

        // หันหน้าเข้าหาผู้เล่นด้วย (เผื่อ sprite มีทิศทาง)
        if (direction.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }
}
