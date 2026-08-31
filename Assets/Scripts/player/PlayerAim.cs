using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    [Header("aim setting")]
    [SerializeField]private float rotationSpeed;
    [SerializeField]private LayerMask groundLayerMask;

    private Camera mainCamera;
    private Plane aimPlane;

    public Vector3 AimDirection { get; private set; }
    public Vector3 AimPoint { get; private set; }

    private InputSystem_Actions controls;


    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAimPlane();
        Vector3 targetPoint = GetMouseWorldPoint();
        AimPoint = targetPoint;

        Vector3 direction = targetPoint - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.001f)
        {
            AimDirection = direction.normalized;
            RotateTowardsAim();
        }
    }

    private void UpdateAimPlane()
    {
        aimPlane = new Plane(Vector3.up, transform.position);
    }
    
    private Vector3 GetMouseWorldPoint()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Ray ray = mainCamera.ScreenPointToRay(mouseScreenPos);

        if(aimPlane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }

        return transform.position + transform.forward;
    }

    private void RotateTowardsAim()
    {
        Quaternion targetRotation = Quaternion.LookRotation(AimDirection, Vector3.up);

        if(rotationSpeed <= 0f)
        {
            transform.rotation = targetRotation;
        }
        else
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
                );
        }
    }
}
