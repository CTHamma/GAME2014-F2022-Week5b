using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Boundary horizontalBoundary;
    public Boundary verticalBoundary;
    public Boundary screenBounds;
    public float horizontalSpeed;
    public float verticalSpeed;
    public SpriteRenderer spriteRenderer;
    public Color randomColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResetEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        var horizontallLength = horizontalBoundary.max - horizontalBoundary.min;
        transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed, horizontallLength) - horizontalBoundary.max, 
            transform.position.y - verticalSpeed * Time.deltaTime, transform.position.z);
    }

    public void CheckBounds()
    {
        if (transform.position.y < screenBounds.min)
        {
            ResetEnemy();
        }
    }

    public void ResetEnemy()
    {
        var RandomXPosition = Random.Range(horizontalBoundary.min, horizontalBoundary.max);
        var RandomYPosition = Random.Range(verticalBoundary.min, verticalBoundary.max);
        horizontalSpeed = Random.Range(1.0f, 6.0f);
        verticalSpeed = Random.Range(1.0f, 3.0f);
        transform.position = new Vector3(RandomXPosition, RandomYPosition, 0.0f);

        List<Color> colorList = new List<Color>() { Color.red, Color.yellow, Color.magenta, Color.cyan, Color.white, Color.white };
        var RandomColor = colorList[Random.Range(0, 6)];
        spriteRenderer.material.SetColor("_Color", RandomColor);
    }
}
