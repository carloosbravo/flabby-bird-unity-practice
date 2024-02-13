using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMovement : MonoBehaviour
{

    [SerializeField] public float _speed = 7.65f;
    private float maxTime = 8f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
        if (timer > maxTime)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
