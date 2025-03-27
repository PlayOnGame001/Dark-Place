using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class CharacterScript : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private CharacterController Ghost;
    private Animator animator; 
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        Ghost = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Получаем аниматор
    }

    void Update()
    {
        groundedPlayer = Ghost.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0.0f;
        if (cameraForward != Vector3.zero)
        {
            cameraForward.Normalize();
        }

        Vector3 moveStep = playerSpeed * Time.deltaTime * (
            moveValue.x * Camera.main.transform.right +
            moveValue.y * cameraForward
        );
        Ghost.Move(moveStep);

        // Проверяем, движется ли персонаж
        bool isMoving = moveValue.sqrMagnitude > 0.01f;
        animator.SetBool("isWalking", isMoving); // Включаем/выключаем анимацию ходьбы

        // Прыжок
        if (jumpAction.ReadValue<float>() > 0 && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        Ghost.Move(playerVelocity * Time.deltaTime);
    }
}
