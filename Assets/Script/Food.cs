using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    [SerializeField] private BoxCollider2D area;
    [SerializeField] private Transform slowFoodPrefab;
    [SerializeField] private Snake snakeFast;
    private int foodEatenCount = 0;
    private float originalSpeed;
    [SerializeField] private UnityEvent eventEnter;

    private void Start()
    {
        originalSpeed = snakeFast.speed;
        RandPosition();
    }

    private void RandPosition()
    {
        Bounds bounds = area.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private IEnumerator ResetSpeedCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (snakeFast != null)
        {
            snakeFast.speed = originalSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Snake"))
        {
            RandPosition();
            Trap trapGenerator = GetComponent<Trap>();
            if (trapGenerator != null)
            {
                trapGenerator.GenerateTraps();
            }
            foodEatenCount++;
            if (foodEatenCount % 5 == 0)
            {
                if (snakeFast != null)
                {
                    snakeFast.speed = 1.5f;
                    StartCoroutine(ResetSpeedCoroutine(10f));
                }
            }
            eventEnter.Invoke();
            GameManager.instance.AddScore();
        }
    }
}
