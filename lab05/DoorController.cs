using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float elevatorSpeed = 3f;
    private bool isRunning = false;
    private float distance = 4f;
    private bool isRunningLeft = false;
    private bool isRunningRight = false;
    private float leftPosition;
    private float rightPosition;
    void Start()
    {
        rightPosition = transform.position.z + distance;
        leftPosition = transform.position.z;
    }
    void Update()
    {
        if (transform.position.z >= rightPosition)
        {
            isRunningLeft = true;
            isRunningRight = false;
            elevatorSpeed = -elevatorSpeed;
            isRunning = true;
        }
        if (isRunningRight && transform.position.z >= rightPosition)
        {
            isRunning = false;
        }
        else if (isRunningLeft && transform.position.z <= leftPosition)
        {
            isRunning = false;
        }
        if (isRunning)
        {
            Vector3 move = -transform.forward * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.z <= leftPosition)
            {
                isRunningRight = true;
                isRunningLeft = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }
}
