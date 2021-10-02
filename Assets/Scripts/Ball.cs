using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 startPos;
    private bool isStart;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        startPos = transform.position;
        isStart = true;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            Launch();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "PlayerOneWall") {
            GameManager.Instance.IncrementPlayerTwoScore();
        } else if (collision.collider.tag == "PlayerTwoWall") {
            GameManager.Instance.IncrementPlayerOneScore();
        }

        if (collision.collider.tag == "PlayerOneWall" || collision.collider.tag == "PlayerTwoWall") {
            transform.position = startPos;
            Launch();
        }
    }

    private void Launch() {
        float x;
        float y;

        if (Random.Range(0, 2) == 1) {
            x = 1;
        } else {
            x = -1;
        }

        if (Random.Range(0, 2) == 1) {
            y = 1;
        } else {
            y = -1;
        }

        rigidbody.velocity = new Vector3(x * GameManager.Instance.speed, 0, y * GameManager.Instance.speed);
    }

    public void Reset() {
        transform.position = startPos;
        rigidbody.velocity = Vector3.zero;
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public Vector3 GetVelocity() {
        return rigidbody.velocity;
    }
}
