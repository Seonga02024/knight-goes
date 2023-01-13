using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyFireball : MonoBehaviour
{
    private float time;
    public GameObject fireball;
    public float delayTime;
    Vector3 p;

    // Start is called before the first frame update
    void Start()
    {
        p = this.transform.position;
        Instantiate(fireball, p, Quaternion.Euler(new Vector3(0, 0, 90)));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > delayTime)
        {
            Instantiate(fireball, p, Quaternion.Euler(new Vector3(0, 0, 90)));
            time = 0;
        }
    }
}
