using UnityEngine;

public class Cube : MonoBehaviour
{
    public Ball ball;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        transform.position = ball.GetPosition();
    }

    public void ChangeColor(Color color) {
        material.color = color;
    }
}
