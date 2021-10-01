using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public bool isPlayerOne;
    public Ball ball;

    private float AISpeed;
    private Rigidbody rigidbody;
    private KeyCode up;
    private KeyCode down;
    private float minRand = 0.6f;
    private float maxRand = 1f;
    private Vector3 startPos;

    private void Start() {
        AISpeed = Random.Range(minRand, maxRand) * GameManager.Instance.speed;
        rigidbody = GetComponent<Rigidbody>();
        if (isPlayerOne) {
            up = KeyCode.UpArrow;
            down = KeyCode.DownArrow;
        } else {
            up = KeyCode.W;
            down = KeyCode.S;
        }
        startPos = transform.position;
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

        // Not Paddle AI
        if (Input.GetKeyDown(up)) {
            rigidbody.velocity = Vector3.left * GameManager.Instance.speed;
        }
        if (Input.GetKeyUp(up)) {
            rigidbody.velocity = Vector3.zero;
        }

        if (Input.GetKeyDown(down)) {
            rigidbody.velocity = Vector3.right * GameManager.Instance.speed;
        }
        if (Input.GetKeyUp(down)) {
            rigidbody.velocity = Vector3.zero;
        }
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
}
