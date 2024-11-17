using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] InputActionAsset inputAction;
    [SerializeField] float force;
    [SerializeField] float rotationForce;
    private InputAction moveAction;
    private InputAction turnAction;
    private Rigidbody rb;

    void Start()
    {
        rotationForce = 15.0f;
        force = 15.0f;
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        moveAction = inputAction.FindActionMap("ActionMap").FindAction("move");
        turnAction = inputAction.FindActionMap("ActionMap").FindAction("turn");
        if (moveAction != null)
        {
            moveAction.Enable();
            turnAction.Enable();
        }
        else
        {
            Debug.LogError("Move action not found!");
        }
    }

    private void OnDisable()
    {
        moveAction.Disable();
        turnAction.Disable();
    }

    void Update()
    {
        if (moveAction != null)
        {
            Vector2 inputMoveVector = moveAction.ReadValue<Vector2>();
            Vector3 accumulatedForce = rb.GetAccumulatedForce();
            Vector3 forwardForce = transform.forward * inputMoveVector.y * force;
            rb.AddForce(forwardForce + accumulatedForce, ForceMode.Force);

            Vector2 inputTurnVector = turnAction.ReadValue<Vector2>();
            Vector3 rotationTorque = Vector3.up * inputTurnVector.x * rotationForce;
            rb.AddTorque(rotationTorque, ForceMode.Force);
        }
        else
        {
            Debug.LogError("Move action is not initialized.");
        }
    }
}