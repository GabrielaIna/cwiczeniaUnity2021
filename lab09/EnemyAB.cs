using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAB : MonoBehaviour
{

    //public List<Transform> points;
    //public int nextID;
    //int idChangeValue = 1;

    //public float speed = 2f;

    //private void Reset()
    //{
    //    Init();
    //}

    //private void Init()
    //{
    //    GetComponent<BoxCollider2D>().isTrigger = true;

    //    GameObject root = new GameObject(name + "_Root");

    //    //reset possition
    //    root.transform.position = transform.position;
    //    transform.SetParent(root.transform);
    //    GameObject waypoints = new GameObject("Waypoints");
    //    waypoints.transform.SetParent(root.transform);
    //    waypoints.transform.position = root.transform.position;
    //    GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform); p1.transform.position = root.transform.position;
    //    GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform); p2.transform.position = root.transform.position;

    //    points = new List<Transform>();
    //    points.Add(p1.transform);
    //    points.Add(p2.transform);
    //}

    //private void Update()
    //{
    //    MoveToNextPoint();
    //}

    //void MoveToNextPoint()
    //{
    //    Transform goalPoint = points[nextID];

    //    ////flip
    //    //if(goalPoint.transform.position.x > transform.position.x)
    //    //{
    //    //    transform.localScale = new Vector3(-1, 1, 1);
    //    //}
    //    //else
    //    //{
    //    //    transform.localScale = new Vector3(1, 1, 1);
    //    //}

    //    transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed*Time.deltaTime);
    //    if(Vector2.Distance(transform.position, goalPoint.position)<1f)
    //    {
    //        if (nextID == points.Count - 1)
    //            idChangeValue = -1;
    //        if (nextID == 0)
    //            idChangeValue = 1;
    //        nextID += idChangeValue;

    //    }
    //}
    ////private void OnTriggerEnter2D(Collider2D collision)
    ////{
    ////    if (collision.gameObject.CompareTag("Player"))
    ////    {
    ////        GameObject newpoint;
    ////        newpoint = GameObject.FindGameObjectWithTag("Player");
    ////        Vector3 newpointV3 = newpoint.transform.position;
    ////        points[1] = newpointV3;
    ////    }
    ////}
    public Transform start;
    public Transform end;
    private Rigidbody2D rb;
    public float speed = 1f;
    public GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = Mathf.Abs(transform.position.x - player.transform.position.x);
        if (dist <= 3f && transform.position.x > (start.position.x -3f) && transform.position.x < (end.position.x +3f))
        {
            if (transform.position.x < player.transform.position.x && transform.position.x < (end.position.x + 3f))
                speed = Mathf.Abs(speed);
            else if(transform.position.x > player.transform.position.x && transform.position.x > (start.position.x - 3f))
                speed = -Mathf.Abs(speed);
        }
        else
        {
            if (transform.position.x < start.position.x)
                speed = Mathf.Abs(speed);
            else if (transform.position.x > end.position.x)
                speed = -Mathf.Abs(speed);
        }
        if (speed < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else
            transform.eulerAngles = Vector3.zero;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
