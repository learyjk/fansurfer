using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    [SerializeField] private float speed;

    private float leftScreenEdge;

    private void Start() 
    {
        leftScreenEdge = Camera.main.orthographicSize * -2 - 5;
        speed = GameStatus.GetInstance().GetSpeed();
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < leftScreenEdge)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            GameStatus.GetInstance().GameOver();
        }
    }
}
