using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie2 : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody rb;
    Vector3 startPosition;
    Vector3 endPosition;
    float left = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = rb.position;
        endPosition = startPosition + new Vector3(10, 0, 0); //przemieszczał wzdłóż osi x o 10 jednostek
    }
    void FixedUpdate()
    {
        if (Vector3.Distance(rb.position, endPosition) > 0.1f) //jeśli można przemieścić się od obecnej pozycji do endPosition to przemieszczaj się 
        {
            Vector3 velocity = new Vector3(1, 0, 0);
            velocity = velocity.normalized * left * speed * Time.deltaTime;
            rb.MovePosition(transform.position + velocity);
        }
        else//przemieszczaj się do tyłu, odwrotnie
        {
            left = -left;
            endPosition = rb.position + new Vector3(left * 10, 0, 0);
        }
    }

}
