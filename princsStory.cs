using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class princsStory : MonoBehaviour
{
    public GameObject story;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        story.SetActive(true);
    }
}
