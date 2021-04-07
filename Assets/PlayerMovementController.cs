using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
    public InputMaster inputMaster;
    public CharacterController characterController;
    public float moveSpeed = 10;

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
    }

    private void Update()
    {
        Vector2 vector2d = inputMaster.Player.Movement.ReadValue<Vector2>();
        if (vector2d != Vector2.zero)
        {
            Vector3 vector3d = new Vector3(vector2d.x, 0, vector2d.y);
            Vector3 direction = transform.TransformDirection(vector3d);
            characterController.Move(direction * moveSpeed * Time.deltaTime);
        }
    }
}