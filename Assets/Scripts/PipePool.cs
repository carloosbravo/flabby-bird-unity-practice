using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public GameObject pipePrefab;
    public int poolSize = 5;
    public float spawnRate = 2f;
    public float pipeMinY = -1f;
    public float pipeMaxY = 3.5f;
    public float distanceBetweenPipes = 7f;
    private List<GameObject> pipes;
    private float lastSpawnTime;
    private float pipeWidth;
    private Camera mainCamera;

    void Start()
    {
        pipes = new List<GameObject>();
        mainCamera = Camera.main; // Obtener la cámara principal
        GameObject pipe;
        for (int i = 0; i < poolSize; i++)
        {
            pipe = Instantiate(pipePrefab);
            pipe.SetActive(false);
            pipes.Add(pipe);
        }
        pipeWidth = pipePrefab.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnRate)
        {
            lastSpawnTime = Time.time;
            SpawnPipe();
        }



    }

    void SpawnPipe()
    {
        GameObject pipe = GetPooledPipe();
        if (pipe != null)
        {
            float randomY = Random.Range(pipeMinY, pipeMaxY);
            pipe.transform.position = new Vector2(transform.position.x, randomY);
            pipe.transform.position += Vector3.right * distanceBetweenPipes;

            pipe.SetActive(true);
        }
    }

    GameObject GetPooledPipe()
    {
        foreach (GameObject pipe in pipes)
        {
            if (!pipe.activeInHierarchy)
            {
                return pipe;
            }
        }
        return null;
    }
}