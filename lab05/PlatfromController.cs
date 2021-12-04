using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromController : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 5f;
    private bool isRunningLeft = false;
    private bool isRunningRight = false;
    private float leftPosition;
    private float rightPosition;
    void Start()
    {
        rightPosition = transform.position.x + distance;
        leftPosition = transform.position.x;
    }
    void Update()
    {
        if (transform.position.x >= rightPosition)
        {
            isRunningLeft = true;
            isRunningRight = false;
            elevatorSpeed = -elevatorSpeed;
            isRunning = true;
        }
        if (isRunningRight && transform.position.x >= rightPosition)
        {
            isRunning = false;
        }
        else if (isRunningLeft && transform.position.x <= leftPosition)
        {
            isRunning = false;
        }
        if (isRunning)
        {
            Vector3 move = transform.right * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            other.gameObject.transform.parent = transform;
            if (transform.position.x <= leftPosition)
            {
                isRunningRight = true;
                isRunningLeft = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        other.gameObject.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            other.gameObject.transform.parent = null;
        }
    }
}
