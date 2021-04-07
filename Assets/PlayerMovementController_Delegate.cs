using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController_Delegate : MonoBehaviour
{
    public InputMaster inputMaster;
    public CharacterController characterController;
    public float moveSpeed = 10;

    private Vector2 vector2d; 

#if UNITY_EDITOR
    private void OnValidate()
    {
        characterController = GetComponent<CharacterController>();
    }
#endif

    private void Awake()
    {
        inputMaster = new InputMaster();
        inputMaster.Enable();
        inputMaster.Player.Movement.performed += ctx =>
        {
            vector2d = ctx.ReadValue<Vector2>();
        };
    }

    private void Update()
    {
        if (vector2d != Vector2.zero)
        {
            Vector3 vector3d = new Vector3(vector2d.x, 0, vector2d.y);
            Vector3 direction = transform.TransformDirection(vector3d);
            characterController.Move(direction * moveSpeed * Time.deltaTime);
        }
    }
}