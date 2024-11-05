using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = speed * -transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
