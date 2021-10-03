using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    public static bool isAI = false;
    public static bool canDisco = false;
    public float speed = 100;
    public int pointsToWin = 5; 

    private Cube cube;
    private GameObject paddle2;
    private GameObject winnerText;
    private GameObject tryAgainButton;

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

        paddle2 = GameObject.Find("Player2");
        playerOneGUI = GameObject.FindGameObjectWithTag("PlayerOneScore").GetComponent<TextMeshProUGUI>();
        playerTwoGUI = GameObject.FindGameObjectWithTag("PlayerTwoScore").GetComponent<TextMeshProUGUI>();
        tryAgainButton = GameObject.Find("TryAgain");

        tryAgainButton.SetActive(false);

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
        ++_playerOneScore;
        playerOneGUI.text = (_playerOneScore).ToString();
        if (_playerOneScore == pointsToWin) {
            PlayerOneWins(true);
        }
    }

    public void IncrementPlayerTwoScore() {
        ++_playerTwoScore;
        PlayerTwoText(_playerTwoScore);
        if (_playerTwoScore == pointsToWin) {
            PlayerOneWins(false);
        }
    }

    private void PlayerOneWins(bool b) {
        winnerText = GameObject.Find("Winner");
        tryAgainButton.SetActive(true);
        if (b) {
            winnerText.GetComponent<TextMeshProUGUI>().text = "Player One Wins!!!";    
        } else {
            if (isAI) {
                winnerText.GetComponent<TextMeshProUGUI>().text = "Computer Wins!!!";
            } else {
                winnerText.GetComponent<TextMeshProUGUI>().text = "Player Two Wins!!!";
            }
        }
    }

    // Disco!!!
    private void Disco() {
        int rotationalSpeed = 500000;
        lightComponent = GameObject.FindGameObjectWithTag("Light").GetComponent<Light>();
        cube = GameObject.FindGameObjectWithTag("Cube").GetComponent<Cube>();
        cube.transform.Rotate(GetRandomVector3(), rotationalSpeed * Time.deltaTime);

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

    // Changes the text on Player 2's side (adds 'AI' before the score if it is on)
    private void PlayerTwoText(int score) {
        if (isAI) {
            playerTwoGUI.text = "AI: " + score.ToString();
        } else {
            playerTwoGUI.text = score.ToString();
        }
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

    public int getPlayerOneScore()
    {
        return _playerOneScore;
    }

    public int getPlayerTwoScore()
    {
        return _playerTwoScore;
    }
}
