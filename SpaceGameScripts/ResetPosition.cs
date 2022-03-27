using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{   
    float y = 40.96002f;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        y = GetComponent<BoxCollider>().size.y*4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y <= startPos.y - y)
        {
            transform.position = startPos;
        }
    }
}
