using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] InputActionAsset inputAction;
    [SerializeField] float force;
    private InputAction moveAction;
    Rigidbody rb;

    void Start()
    {
        force = 3.0f;
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        moveAction = inputAction.FindActionMap("ActionMap").FindAction("move");
        if (moveAction != null)
        {
            moveAction.Enable();
        }
        else
        {
            Debug.LogError("Move action not found!");
        }
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    void Update()
    {
        if (moveAction != null)
        {
            Vector2 inputVector = moveAction.ReadValue<Vector2>();
            Vector3 vectorForce = rb.GetAccumulatedForce();
            rb.AddForce(inputVector.x + vectorForce.x * force, 0, inputVector.y + vectorForce.z * force);
        }
        else
        {
            Debug.LogError("Move action is not initialized.");
        }
    }
}