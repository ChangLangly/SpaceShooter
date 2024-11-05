using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadProjectile : MonoBehaviour
{
    private Rigidbody rb;
    private ShipControl shipControl;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shipControl = GameObject.Find("Ship").GetComponent<ShipControl>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = 30 * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("shieldShip"))
        {
            Destroy(gameObject);
            Debug.Log("Shield Blocked Laser");
        }
    }
}
