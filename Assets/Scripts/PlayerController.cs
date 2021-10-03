using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private GameObject _player;
    private InputActions _inputActions;
    private InputAction _movement;
    private Rigidbody _rigidbody;
    private Vector2 _currentMove;

    private void Awake() {
        _inputActions = new InputActions();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnEnable() {
        this.enabled = true;

        // Get reference to player's controller movement and enable the respective actions
        if (_player.name.Equals("Player1")) {
            _movement = _inputActions.Player1.Movement;
        } else if (_player.name.Equals("Player2")) {
            _movement = _inputActions.Player2.Movement;
        }
        
        if (_movement != null)
            _movement.Enable();
    }

    public void OnDisable() {
        this.enabled = false;

        if (_movement != null)
            _movement.Disable();
    }

    public void OnMove(InputAction.CallbackContext context) {
        _currentMove = context.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        Vector3 pos = new Vector3(_currentMove.x, 0, _currentMove.y);
        _rigidbody.velocity = pos * GameManager.Instance.speed;
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Wall") {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
