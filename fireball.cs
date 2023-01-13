using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public int speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fMove = Time.deltaTime * speed;
        transform.Translate(new Vector3(0, 1, 0) * fMove);
    }
}
