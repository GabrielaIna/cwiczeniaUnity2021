using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie3 : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody rb;
    Vector3 startPosition;
    Vector3 endPosition;
    float x = 10; //na początku przemieszcza się do 10;0;0 analogicznie warunki niżej
    float z = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = rb.position;
        endPosition = startPosition + new Vector3(10, 0, 0);

    }

    void FixedUpdate()
    {
        if (Vector3.Distance(rb.position, endPosition) >= 0.1f)
        {
            Vector3 velocity = new Vector3(x, 0, z);
            velocity = velocity.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + velocity);
        }
        else
        {
            transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self); //obrót
            if (x == 10 && z == 0)
            {
                x = 0; z = 10;
                startPosition = rb.position;
                endPosition = startPosition + new Vector3(0, 0, z);
            }
            else if (x == 0 && z == 10)
            {
                x = -10; z = 0;
                startPosition = rb.position;
                endPosition = startPosition + new Vector3(x, 0, 0);
            }
            else if (x == -10 && z == 0)
            {
                x = 0; z = -10;
                startPosition = rb.position;
                endPosition = startPosition + new Vector3(0, 0, z);
            }
            else
            {
                x = 10; z = 0;
                startPosition = rb.position;
                endPosition = startPosition + new Vector3(x, 0, 0);
            }
        }
    }



}
