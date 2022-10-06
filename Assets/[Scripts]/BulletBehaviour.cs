using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ScreenBounds
{
    public Boundary horizontal;
    public Boundary vertical;
}

public class BulletBehaviour : MonoBehaviour
{
    public BulletDirection direction;
    public float speed;
    public Vector3 velocity;
    public ScreenBounds bounds;

    // Start is called before the first frame update
    void Start()
    {
        switch(direction)
        {
            case BulletDirection.UP:
                velocity = Vector3.up * speed;
                break;
            case BulletDirection.RIGHT:
                velocity = Vector3. right * speed;
                break;
            case BulletDirection.DOWN:
                velocity = Vector3.down * speed;
                break;
            case BulletDirection.LEFT:
                velocity = Vector3.left * speed;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        transform.position += velocity * Time.deltaTime;
    }

    void CheckBounds()
    {
        if((transform.position.x > bounds.horizontal.max) ||
          (transform.position.x < bounds.horizontal.min)  ||
          (transform.position.y > bounds.vertical.max)    ||
          (transform.position.y < bounds.vertical.max))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy (this.gameObject);
    }
}
