using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveP : MonoBehaviour
{
    public float speed;
    public float count;
    Vector3 p1;
    Vector3 p2;

    // Start is called before the first frame update
    void Start()
    {
        p1 = new Vector3(-5, -5, -5);
        p2 = new Vector3(5, 5, 5);
        this.transform.position = p1;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        Debug.Log("count : "+ count);
        transform.position = Vector3.MoveTowards(transform.position, p2, Time.deltaTime * speed);
        if (count > 1)
            speed = 15;
    }
}
