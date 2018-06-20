using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool started;

    public float speed = 2f;
    public float minDistance = 0.2f;

    public float rotationSpeed;

    Vector3 target;
    Vector3 direction;

    Rigidbody2D rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        target = transform.position;
    }


    void Update ()
    {
        TakeInput();
        Move();
        Rotate();

        if(Input.anyKey && !started)
        {
            started = true;
        }
	}

    void TakeInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Vector3.Distance(transform.position, target) <= minDistance)
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = 0;

                rotationSpeed = Random.Range(-rotationSpeed, rotationSpeed);
            }
        }        
    }

    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }

    void Rotate()
    {
        if(started)
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

}
