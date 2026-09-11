using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class DashExecutor : MonoBehaviour
{
    private Rigidbody rb;
    private playerController playerMovement; // เผื่ออยากปิด movement ปกติระหว่าง dash

    public bool IsDashing { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerMovement = GetComponent<playerController>();
    }

    public void StartDash(float distance, float duration)
    {
        if (IsDashing) return;
        StartCoroutine(DashRoutine(distance, duration));
    }

    private IEnumerator DashRoutine(float distance, float duration)
    {
        IsDashing = true;
        if (playerMovement != null) playerMovement.enabled = false; // กัน movement ปกติแทรก

        Vector3 direction = transform.forward; // ใช้ทิศที่หันอยู่ (จาก PlayerAim)
        Vector3 startPos = rb.position;
        Vector3 endPos = startPos + direction * distance;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.fixedDeltaTime;
            float t = elapsed / duration;
            rb.MovePosition(Vector3.Lerp(startPos, endPos, t));
            yield return new WaitForFixedUpdate();
        }

        if (playerMovement != null) playerMovement.enabled = true;
        IsDashing = false;
    }
}
