using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectMover : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction moveAction;
    public float speed = 10.0f;

    private void OnEnable()
    {
        // Asignar la acción de movimiento
        moveAction = inputActions.FindActionMap("ActionMap").FindAction("move");
        if (moveAction != null)
        {
            moveAction.Enable();
            //Debug.Log("Move action enabled.");
        }
        else
        {
           // Debug.LogError("Move action not found!");
        }
    }

    private void OnDisable()
    {
        moveAction.Disable();
       // Debug.Log("Move action disabled.");
    }

    void Update()
    {
        if (moveAction != null)
        {
            // Leer el valor del joystick como un vector 2D
            Vector2 inputVector = moveAction.ReadValue<Vector2>();
           // Debug.Log($"Input Vector: {inputVector}");

            // Crear un Vector3 para el movimiento a partir del Vector2
            Vector3 movement = new Vector3(inputVector.x, 0, inputVector.y);

            // Aplicar el movimiento al objeto
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
            //Debug.Log($"Object moved to position: {transform.position}");
        }
        else
        {
           // Debug.LogError("Move action is not initialized.");
        }
    }
}