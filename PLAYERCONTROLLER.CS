using UnityEngine;

// Simple first-person controller using a CharacterController.
// Attach to a Capsule with a CharacterController component.
// Assign camera (playerHead) and flashlightLight (a Light component parented to camera).

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Transform playerHead; // camera transform
    public Light flashlightLight;
    public float walkSpeed = 3.5f;
    public float gravity = -9.81f;
    public float mouseSensitivity = 2.0f;

    private CharacterController cc;
    private float verticalVelocity = 0f;
    private float xRotation = 0f;

    // Mobile joystick input (set by TouchControls if present)
    [HideInInspector] public Vector2 mobileMoveInput = Vector2.zero;
    [HideInInspector] public Vector2 mobileLookInput = Vector2.zero;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        if (playerHead == null && Camera.main != null) playerHead = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleLook();
        HandleMovement();
        HandleFlashlightToggle();
        HandleInteract();
    }

    void HandleLook()
    {
        Vector2 look;
#if UNITY_EDITOR || UNITY_STANDALONE
        look = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSensitivity;
#else
        // mobile fallback: read from mobileLookInput set by TouchControls
        look = mobileLookInput * mouseSensitivity * 10f;
#endif
        xRotation -= look.y;
        xRotation = Mathf.Clamp(xRotation, -75f, 75f);
        playerHead.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * look.x);
    }

    void HandleMovement()
    {
        Vector2 input;
#if UNITY_EDITOR || UNITY_STANDALONE
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
#else
        input = mobileMoveInput;
#endif
        Vector3 move = transform.right * input.x + transform.forward * input.y;
        if (cc.isGrounded) verticalVelocity = -0.5f;
        verticalVelocity += gravity * Time.deltaTime;
        cc.Move((move * walkSpeed + Vector3.up * verticalVelocity) * Time.deltaTime);
    }

    void HandleFlashlightToggle()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlightLight != null) flashlightLight.enabled = !flashlightLight.enabled;
        }
    }

    void HandleInteract()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(playerHead.position, playerHead.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 3f))
            {
                var interact = hit.collider.GetComponent<IInteractable>();
                if (interact != null) interact.OnInteract();
            }
        }
    }
}

// Simple interactable interface for items (books, doors, puzzles).
public interface IInteractable
{
    void OnInteract();
}
