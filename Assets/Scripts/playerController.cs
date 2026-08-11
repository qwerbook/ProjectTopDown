using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [SerializeField] InputAction movementInput;
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector2 moveDirection;
    [SerializeField] float moveSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementInput.Enable();
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = movementInput.ReadValue<Vector2>();
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.y * moveSpeed);
    }
}
