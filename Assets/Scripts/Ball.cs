using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 startPos;
    private int pointsToWin;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        startPos = transform.position;
        pointsToWin = GameManager.Instance.pointsToWin;
        Yeet();
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "PlayerOneWall") {
            GameManager.Instance.IncrementPlayerTwoScore();
        } else if (collision.collider.tag == "PlayerTwoWall") {
            GameManager.Instance.IncrementPlayerOneScore();
        }

        if (collision.collider.tag == "PlayerOneWall" || collision.collider.tag == "PlayerTwoWall") {
            transform.position = startPos;
            if (GameManager.Instance.getPlayerOneScore() == pointsToWin
                || GameManager.Instance.getPlayerTwoScore() == pointsToWin) 
            {
                BallReset();
            }
            else
            {
                Yeet();
            }
            
        }
        
    }

    // Yeets the ball somewhere when the game starts
    private void Yeet() {
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

        _rigidbody.velocity = new Vector3(x * GameManager.Instance.speed, 0, y * GameManager.Instance.speed);
    }

    private void BallReset() {
        // The game was won, reset;

        transform.position = startPos;
        _rigidbody.velocity = Vector3.zero;

        GameManager.Instance.setPlayerOneScore(0);
        GameManager.Instance.setPlayerTwoScore(0);
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public Vector3 GetVelocity() {
        return _rigidbody.velocity;
    }
}
