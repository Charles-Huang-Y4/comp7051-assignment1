using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    public Ball ball;
    public Cube cube;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public GameObject paddle1;
    public GameObject paddle2;
    public float speed = 100;
    public int pointsToWin = 5;
    
    private int _playerOneScore;
    private int _playerTwoScore;
    private TextMeshProUGUI playerOneGUI;
    private TextMeshProUGUI playerTwoGUI;
    private Light lightComponent;
    public static bool isAI = false;
    private bool canDisco;
    private List<GameObject> wallList;
    private List<GameObject> paddleList;

    private Vector3 originalPaddleScale;
    private Color originalLightColor;
    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        playerOneGUI = GameObject.FindGameObjectWithTag("PlayerOneScore").GetComponent<TextMeshProUGUI>();
        playerTwoGUI = GameObject.FindGameObjectWithTag("PlayerTwoScore").GetComponent<TextMeshProUGUI>();
        lightComponent = GameObject.FindGameObjectWithTag("Light").GetComponent<Light>();

        wallList = new List<GameObject>();
        paddleList = new List<GameObject>();

        wallList.Add(wall1);
        wallList.Add(wall2);
        wallList.Add(wall3);
        wallList.Add(wall4);

        paddleList.Add(paddle1);
        paddleList.Add(paddle2);

        originalPaddleScale = paddle1.transform.localScale;
        originalLightColor = lightComponent.color;
    }

    private void ResetGame() {
        ResetScores();
        paddle1.GetComponent<Paddle>().Reset();
        paddle2.GetComponent<Paddle>().Reset();
        ball.Reset();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            ResetGame();
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            isAI = !isAI;
            PlayerTwoText(_playerTwoScore);
            ResetGame();
            if (isAI) {
                paddle2.GetComponent<Paddle>().OnDisable();
            } else {
                paddle2.GetComponent<Paddle>().OnEnable();
            }
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            canDisco = !canDisco;

            if (canDisco) {
                AudioManager.instance.Play();
                speed *= 1.5f;
            } else {
                UnDisco();
                AudioManager.instance.Stop();
                speed /= 1.5f;
            }
        }
    }

    void FixedUpdate() {
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

    public void ResetScores() {
        _playerOneScore = 0;
        _playerTwoScore = 0;

        playerOneGUI.text = "0";
        PlayerTwoText(0);
    }

    public bool IsAI() {
        return isAI;
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
        int chance = 25;

        if (Random.Range(0, chance) == 0) {
            lightComponent.color = GetRandomColor();
        }

        if (Random.Range(0, chance) == 0) {
            cube.ChangeColor(GetRandomColor());
        }

        foreach (GameObject obj in wallList) {
            if (Random.Range(0, chance) == 0) {
                obj.GetComponent<Renderer>().material.color = GetRandomColor();
            }
        }

        foreach (GameObject obj in paddleList) {      
            if (Random.Range(0, chance) == 0) {
                obj.GetComponent<Renderer>().material.color = GetRandomColor();
            }
        }

        // For some reason GetRandomColor() doesn't work but this does...
        // Anywho, I hope to find out why in the future...
        if (Random.Range(0, 100) == 0) {
            playerOneGUI.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1); 
        }

        if (Random.Range(0, 100) == 0) {
            playerTwoGUI.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        }
    }

    // Resets everything back to where it was before Disco()
    private void UnDisco() {
        lightComponent.color = originalLightColor;
        cube.ChangeColor(Color.white);
        cube.transform.rotation = Quaternion.Euler(Vector3.zero);
        playerOneGUI.color = Color.white;
        playerTwoGUI.color = Color.white;

        foreach (GameObject obj in wallList) {
            obj.GetComponent<Renderer>().material.color = Color.black;
        }

        foreach (GameObject obj in paddleList) {
            obj.GetComponent<Renderer>().material.color = Color.white;
            obj.transform.rotation = Quaternion.Euler(Vector3.zero);
            obj.transform.localScale = originalPaddleScale;
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
}
