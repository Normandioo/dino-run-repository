using UnityEngine;

public class obstacleScript : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;


    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

    

}
