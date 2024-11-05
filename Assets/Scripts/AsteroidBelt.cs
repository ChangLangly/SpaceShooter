using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBelt : MonoBehaviour
{
    public Vector3 rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = new Vector3(0, 0, 80);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
