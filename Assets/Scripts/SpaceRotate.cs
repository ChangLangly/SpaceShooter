using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRotate : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 30, 0);

    public GameObject badOne;
    public GameObject badTwo;
    public GameObject badThree;
    public GameObject powerupOne;
    public GameObject powerupTwo;
    public Transform badOneT;
    public Transform badTwoT;
    public Transform badThreeT;
    public Transform powerupOneT;
    public Transform powerupTwoT;
    


    public void Start()
    {
        StartCoroutine("SpawnBadOne");
        StartCoroutine("SpawnBadTwo");
        StartCoroutine("SpawnBadThree");
        StartCoroutine("SpawnPowerupOne");
        StartCoroutine("SpawnPowerupTwo");
    }
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);



    }

    IEnumerator SpawnBadOne()
    {
        while (true) 
        {
            GameObject newBadOne = Instantiate(badOne, badOneT.position, badOneT.rotation);   
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator SpawnBadTwo()
    {
        while (true) 
        {
            GameObject newBadTwo = Instantiate(badTwo, badTwoT.position, badTwoT.rotation);
            yield return new WaitForSeconds(3);
        }
    }

    IEnumerator SpawnBadThree()
    {
        while (true) 
        {
            GameObject newBadThree = Instantiate(badThree, badThreeT.position, badThreeT.rotation);
            yield return new WaitForSeconds(5);
        }
    }
    
    IEnumerator SpawnPowerupOne()
    {
        while (true) 
        {
            GameObject newPowerupOne = Instantiate(powerupOne, powerupOneT.position, powerupOneT.rotation);
            yield return new WaitForSeconds(10);                                 
        }                                                                       
    }                                                                           
                                                                                
    IEnumerator SpawnPowerupTwo()                                               
    {                                                                           
        while (true)                                                            
        {                                                                       
            GameObject newPowerupTwo = Instantiate(powerupTwo, powerupTwoT.position, powerupTwoT.rotation);
            yield return new WaitForSeconds(20);
        }
    }
}