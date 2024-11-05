using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Projectiles : MonoBehaviour
{
    public float speed = 50.0f;
    private ObjectPool<Projectiles> projPool;
    private Rigidbody rb;
    private float timeUntilDestruction = 5.0f;
    private float currentTime;
    public Vector3 rotationSpeed = new Vector3(0, 0, 90);
    private ShipControl shipControl;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentTime = timeUntilDestruction;
        speed = 30.0f;
        shipControl = GameObject.Find("Ship").GetComponent<ShipControl>();
    }

    private void Start()
    {
        ApplyVelocity();
    }

    private void Update()
    {
        if (currentTime > 0.0f)
        {
            currentTime -= Time.deltaTime;  
        }
        else { DestroyProj(); }
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    public void SetPool(ObjectPool<Projectiles> pool)
    {
        projPool = pool;
    }

    private void OnEnable()
    {
        ApplyVelocity();
        currentTime = timeUntilDestruction;
    }

    private void ApplyVelocity()
    {
        rb.velocity = speed * transform.right;

    }

    private void DestroyProj()
    {
        if (projPool != null) { projPool.Release(this); }
        else { Destroy(gameObject); }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("asteroid"))
        {
            Destroy(other.gameObject);
            shipControl.AddPoints(3);
            Debug.Log("Destroyed Asteroid");
        }
        
        if (other.CompareTag("mine"))
        {
            Destroy(other.gameObject);
            shipControl.AddPoints(6);
            Debug.Log("Killed Enemy Mine");
        }

        if (other.CompareTag("heal"))
        {
            Destroy(other.gameObject);
            shipControl.TakeLife(-10);
            Debug.Log("Got Health");
        }

        if (other.CompareTag("shield"))
        {
            Destroy(other.gameObject);
            shipControl.ShieldsUp();
            Debug.Log("Shields Up");
        }
    }
}
