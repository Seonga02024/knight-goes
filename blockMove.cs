using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockMove : MonoBehaviour
{
    Vector3 firstP;
    int a = 1;

    // Start is called before the first frame update
    void Start()
    {
        firstP = transform.position;
    }

    private void Update()
    {
        if (firstP.y < transform.position.y)
        {
            a = -1;
        }
        else if (firstP.y - 1f > transform.position.y)
        {
            a = 1;
        }
        transform.Translate(Vector3.up * 0.5f * Time.deltaTime * a);
    }
    
}
