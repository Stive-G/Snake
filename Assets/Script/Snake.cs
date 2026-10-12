
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 snakeDirection = Vector2.right;
    private List<Transform> snakeSeg = new List<Transform>();
    [SerializeField] private Transform snakeSegmentPrefab;
    private int size = 4;
    [SerializeField] public float speed = 1f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject playerScore;
    [SerializeField] private AudioClip shootSound;

    private void Start()
    {
        Dead();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            snakeDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            snakeDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            snakeDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            snakeDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            menuPause.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        MoveSnake();
    }
    private void MoveSnake()
    {
        for (int i = snakeSeg.Count - 1; i > 0; i--)
        {
            snakeSeg[i].position = snakeSeg[i - 1].position;
        }
        Vector3 newPosition = transform.position + new Vector3(snakeDirection.x * speed, snakeDirection.y * speed, 0.0f);
        transform.position = newPosition;
    }
    private void Dead()
    {
        for (int i = 1; i < snakeSeg.Count; i++)
        {
            Destroy(snakeSeg[i].gameObject);
        }
        snakeSeg.Clear();
        snakeSeg.Add(transform);

        for (int i = 1; i < size; i++)
        {
            snakeSeg.Add(Instantiate(snakeSegmentPrefab));
        }

        transform.position = Vector3.zero;
    }
    private void Grow()
    {
        SoundManager.instance.PlaySound(shootSound);
        Transform seg = Instantiate(snakeSegmentPrefab);
        seg.position = snakeSeg[snakeSeg.Count - 1].position;
        snakeSeg.Add(seg);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Grow();
        }
        else if (other.CompareTag("Danger") || other.CompareTag("Trap"))
        {
            Dead();
            gameManager.GetScore();
            playerScore.SetActive(true);
        }
    }
}