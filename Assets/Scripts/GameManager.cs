using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    public static bool isAI = false;
    public static bool canDisco = false;
    public Ball ball;
    public Cube cube;
    private GameObject paddle1;
    private GameObject paddle2;
    public float speed = 100;
    public int pointsToWin = 5;
    
    private int _playerOneScore;
    private int _playerTwoScore;
    private TextMeshProUGUI playerOneGUI;
    private TextMeshProUGUI playerTwoGUI;
    private Light lightComponent;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance = this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        paddle1 = GameObject.Find("Player1");
        paddle2 = GameObject.Find("Player2");
        playerOneGUI = GameObject.FindGameObjectWithTag("PlayerOneScore").GetComponent<TextMeshProUGUI>();
        playerTwoGUI = GameObject.FindGameObjectWithTag("PlayerTwoScore").GetComponent<TextMeshProUGUI>();

        PlayerTwoText(_playerTwoScore);
    }

    private void Start() {
        if (isAI) {
            paddle2.GetComponent<PlayerController>().OnDisable();
        } else {
            paddle2.GetComponent<PlayerController>().OnEnable();
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            canDisco = !canDisco;
            if (canDisco) {
                speed *= 1.5f;
            } else {
                UnDisco();
                speed /= 1.5f;
            }
        }

        if (canDisco) {
            Disco();
        }
    }

    public void IncrementPlayerOneScore() {
        playerOneGUI.text = (++_playerOneScore).ToString();
    }

    public void IncrementPlayerTwoScore() {
        PlayerTwoText(++_playerTwoScore);
    }

    public bool CanDisco() {
        return canDisco;
    }

    // Changes the text on Player 2's side (adds 'AI' before the score if it is on)
    private void PlayerTwoText(int score) {
        if (isAI) {
            playerTwoGUI.text = "AI: " + score.ToString();
        } else {
            playerTwoGUI.text = score.ToString();
        }
    }

    // Disco!!!
    private void Disco() {
        lightComponent = GameObject.FindGameObjectWithTag("Light").GetComponent<Light>();
        cube = GameObject.FindGameObjectWithTag("Cube").GetComponent<Cube>();
        int xRot = Random.Range(-1, 1);
        int yRot = Random.Range(-1, 1);
        int zRot = Random.Range(-1, 1);
        cube.transform.Rotate(new Vector3(xRot, yRot, zRot), 5000000 * Time.deltaTime);

        if (Random.Range(0, 50) == 0) {

            lightComponent.color = GetRandomColor();
            cube.ChangeColor(GetRandomColor());
        }
    }

    // Resets everything back to where it was before Disco()
    private void UnDisco() {
        lightComponent = GameObject.FindGameObjectWithTag("Light").GetComponent<Light>();
        cube = GameObject.FindGameObjectWithTag("Cube").GetComponent<Cube>();
        lightComponent.color = Color.white;
        cube.ChangeColor(Color.white);
        cube.transform.rotation = Quaternion.Euler(Vector3.zero);
        playerOneGUI.color = Color.white;
        playerTwoGUI.color = Color.white;
    }

    private Color GetRandomColor() {
        Color color = new Color();
        color.r = Random.Range(0f, 1f);
        color.g = Random.Range(0f, 1f);
        color.b = Random.Range(0f, 1f);

        return color;
    }

    private Vector3 GetRandomVector3() {
        int xRot = Random.Range(-1, 1);
        int yRot = Random.Range(-1, 1);
        int zRot = Random.Range(-1, 1);

        return new Vector3(xRot, yRot, zRot);
    }

    private void OnValidate() {
        if(speed < 0) {
            speed = 0;
        }

        if(pointsToWin < 0) {
            pointsToWin = 0;
        }
    }
}
