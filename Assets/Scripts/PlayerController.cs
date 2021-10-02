using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private GameObject _player;
    private ControllerInput _controllerInput;
    private InputAction _movement;
    private Rigidbody _rigidbody;
    private Vector2 _currentMove;

    private void Awake() {
        _controllerInput = new ControllerInput();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        // Get reference to player's controller movement and enable the respective actions
        if (_player.name.Equals("Player1")) {
            _movement = _controllerInput.Player1.Movement;
        } else if (_player.name.Equals("Player2")) {
            _movement = _controllerInput.Player2.Movement;
        }

        _movement.Enable();
    }

    private void OnDisable() {
        // Disable player movement via controller input
        if (_movement != null) {
            _movement.Disable();
        }
    }

    public void OnMove(InputAction.CallbackContext context) {
        _currentMove = context.ReadValue<Vector2>();
    }

    private void Update() {
        Vector3 moveVelocity = GameManager.Instance.speed * (
            _currentMove.x * Vector3.right +
            _currentMove.y * Vector3.forward
            );
        Vector3 moveThisFrame = Time.deltaTime * moveVelocity;

        transform.position += moveThisFrame;
    }
}
