using UnityEngine;
using System.Collections;

public class ShieldExecutor : MonoBehaviour
{
    public bool IsShielded { get; private set; }

    public void ActivateShield(float duration)
    {
        StartCoroutine(ShieldRoutine(duration));
    }

    private IEnumerator ShieldRoutine(float duration)
    {
        IsShielded = true;
        // ในอนาคต: เปิด VFX โล่ตรงนี้
        yield return new WaitForSeconds(duration);
        IsShielded = false;
        // ปิด VFX โล่ตรงนี้
    }
}
