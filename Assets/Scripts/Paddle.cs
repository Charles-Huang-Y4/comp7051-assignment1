using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public bool isPlayerOne;
    public Ball ball;
    public PlayerKeyboardInput input;

    private float AISpeed;
    private Rigidbody rigidbody;
    private float minRand = 0.6f;
    private float maxRand = 1f;
    private Vector3 startPos;
    private InputAction movement;

    private void Awake() {
        input = new PlayerKeyboardInput();
    }

    private void Start() {
        AISpeed = Random.Range(minRand, maxRand) * GameManager.Instance.speed;
        rigidbody = GetComponent<Rigidbody>();

        startPos = transform.position;

        if (isPlayerOne) {
            movement = input.Player1.ArrowKeys;
        } else {
            movement = input.Player2.WASD;
        }
    }

    public void Reset() {
        transform.position = startPos;
        rigidbody.velocity = Vector3.zero;
    }

    void Update() {     
        // Paddle AI
        if (GameManager.Instance.IsAI() && !isPlayerOne && ball.GetVelocity() != Vector3.zero) {
            if (ball.transform.position.x > transform.position.x) {
                rigidbody.velocity = Vector3.right * AISpeed;
            } else {
                rigidbody.velocity = Vector3.left * AISpeed;
            }
            return;
        }

        rigidbody.velocity = new Vector3(movement.ReadValue<Vector2>().x, movement.ReadValue<Vector2>().y, 0) * GameManager.Instance.speed;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Wall") {
            rigidbody.velocity = Vector3.zero;
        }

        // when either paddles hit a wall or ball, change AI speed
        if (collision.collider.tag == "Wall" || collision.collider.tag == "Ball") {
            AISpeed = Random.Range(minRand, maxRand) * GameManager.Instance.speed;
        }
    }

    public void OnEnable() {
        input.Enable();
    }

    public void OnDisable() {
        input.Disable();
    }
}
