using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camcontroll : MonoBehaviour
{
    public GameObject player;
    private float offset;
    public float startP; 
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.x - player.transform.position.x;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(player.transform.position.x < 50 && player.transform.position.x > startP)
            transform.position = new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);
    }
}
