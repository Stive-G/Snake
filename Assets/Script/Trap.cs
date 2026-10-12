using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject trapPrefab;
    public BoxCollider2D area;
    public int numberOfTraps = 4;
    private List<Transform> traps = new List<Transform>();

    private void Start()
    {
        GenerateTraps();
    }

    public void GenerateTraps()
    {
        ClearTraps();

        Bounds bounds = area.bounds;

        for (int i = 0; i < numberOfTraps; i++)
        {
            Transform trap = Instantiate(trapPrefab).transform;
            traps.Add(trap);

            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);

            trap.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        }
    }

    public void ClearTraps()
    {
        foreach (Transform trap in traps)
        {
            Destroy(trap.gameObject);
        }

        traps.Clear();
    }
}
