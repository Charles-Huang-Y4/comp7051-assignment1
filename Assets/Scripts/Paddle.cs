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
    private float minRand = 0.6f;
    private float maxRand = 1f;
    private Vector3 startPos;

    private void Start() {
        AISpeed = Random.Range(minRand, maxRand) * GameManager.Instance.speed;
        rigidbody = GetComponent<Rigidbody>();

        startPos = transform.position;
    }

    public void Reset() {
        transform.position = startPos;
        rigidbody.velocity = Vector3.zero;
    }

    void Update() {     
        // Paddle AI
        if (GameManager.isAI && !isPlayerOne && ball.GetVelocity() != Vector3.zero) {
            GetComponent<PlayerController>().OnDisable();

            if (ball.transform.position.x > transform.position.x) {
                rigidbody.velocity = Vector3.right * AISpeed;
            } else {
                rigidbody.velocity = Vector3.left * AISpeed;
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        // when either paddles hit a wall or ball, change AI speed
        if (collision.collider.tag == "Wall" || collision.collider.tag == "Ball") {
            AISpeed = Random.Range(minRand, maxRand) * GameManager.Instance.speed;
        }
    }
}
