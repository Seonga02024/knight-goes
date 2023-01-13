using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveforward : MonoBehaviour
{
    public int speed = 10;
    int speed1 = 10;
    int speed2 = 10;
    private float time;
    float time_change;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject parent = transform.parent.gameObject;
        speed1 = parent.GetComponent<oneAttack>().attack_speed;
        speed2 = parent.GetComponent<oneAttack>().attack_speed2;
        time_change = parent.GetComponent<oneAttack>().time_change;
        if (time < time_change)
        {
            speed = speed1;
        }
        else
        {
            speed = speed2;
        }
        float fMove = Time.deltaTime * speed;
        transform.Translate(new Vector3(0,1,0) * fMove);
        time += Time.deltaTime;
    }

    //void OnBecameInvisible()
    //{
    //    GameObject parent = transform.parent.gameObject;
    //    Destroy(parent);
    //}
}
