using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadShips : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 10.0f;
    private GameObject player;
    public GameObject projSpawn;
    public GameObject laser;
    public ShipControl shipControl;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = speed * -transform.right;
        player = GameObject.Find("Ship");
        StartCoroutine("ShootMe");
        shipControl = GameObject.Find("Ship").GetComponent<ShipControl>();
    }

    private void Update()
    {
        transform.LookAt(player.transform);
    }

    public IEnumerator ShootMe()
    {
        while (true)
        {
            InstantiateLaser();
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void InstantiateLaser()
    {
        GameObject newLaser = Instantiate(laser, projSpawn.transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("proj"))
        {
            Destroy(gameObject);
            shipControl.AddPoints(10);
            Debug.Log("Killed Enemy Ship");
        }
    }
}
