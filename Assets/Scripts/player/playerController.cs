using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class playerController : MonoBehaviour
{
    [Header("Movement")]
    //[SerializeField] InputAction movementInput;
    [SerializeField] float moveSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    
    private Vector2 inputMove;
    private Vector3 currentVelocity;

    [SerializeField] Rigidbody rb;
    private InputSystem_Actions controls;
    private void Awake()
    {
        rb.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;

        //movementInput.Enable();

        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Move.performed += MovePerformed;
        controls.Player.Move.canceled += MovePerformed;
    }


    private void OnDisable()
    {
        controls.Player.Move.performed -= MovePerformed;
        controls.Player.Move.canceled -= MovePerformed;
        controls.Player.Disable();
    }

    private void MovePerformed(InputAction.CallbackContext ctx)
    {
        inputMove = ctx.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        //inputMove = movementInput.ReadValue<Vector2>();
        
    }

    private void FixedUpdate()
    {
        //rb.linearVelocity = new Vector3(inputMove.x * moveSpeed, 0, inputMove.y * moveSpeed).normalized;

        Vector3 targetDirection = new Vector3(inputMove.x, 0f, inputMove.y).normalized;
        Vector3 targetVelocity = targetDirection * moveSpeed;

        float rate = targetVelocity.magnitude > 0.01f ? acceleration : deceleration;
        currentVelocity = Vector3.MoveTowards(currentVelocity, targetVelocity, rate * Time.fixedDeltaTime);

        rb.MovePosition(rb.position + currentVelocity * Time.fixedDeltaTime);
    }
}
