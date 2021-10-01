using UnityEngine;

public class Cube : MonoBehaviour
{
    public Ball ball;
    private Material material;
    private float rotationSpeed = 500000;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        transform.position = ball.GetPosition();

        if (GameManager.Instance.CanDisco()) {
            int xRot = Random.Range(-1, 1);
            int yRot = Random.Range(-1, 1);
            int zRot = Random.Range(-1, 1);

            transform.Rotate(new Vector3(xRot, yRot, zRot), rotationSpeed * Time.deltaTime);
        }
    }

    public void ChangeColor(Color color) {
        material.color = color;
    }
}
