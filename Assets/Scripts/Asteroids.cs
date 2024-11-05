using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    private Vector3[] vector3s = new Vector3[] {new Vector3(12, 30, -43), new Vector3(-1, -28, -22), new Vector3(-15, 37, 55)};
    private Rigidbody rb;
    private float speed = 10.0f;
    private ShipControl shipControl;
    // Start is called before the first frame update
    void Start()
    {
        shipControl = GameObject.Find("Ship").GetComponent<ShipControl>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = speed * -transform.right;   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = vector3s[Random.Range(0, 2)];
        transform.Rotate(rotation * Time.deltaTime);
    }
}
