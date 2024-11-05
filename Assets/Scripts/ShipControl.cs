using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class ShipControl : MonoBehaviour
{

    public ProjPool projPooler;

    float moveSpeed = 200.0f;
    public TMP_Text lifeText;
    public TMP_Text pointsText;
    public int lifePoints;
    public int points;
    public GameObject shield;
    public GameObject endPanel;
    public TMP_Text endPanelMessage;
    private void Start()
    {
        projPooler = GameObject.Find("ProjSpawner").GetComponent<ProjPool>();
        lifePoints = 100;
        shield.SetActive(false);
        endPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            projPooler.InstantiateProj();
        }
        float verticalInput = Input.GetAxis("Horizontal");
        Vector3 movementY = new Vector3(0.0f, 0.0f, verticalInput);

        transform.Rotate(movementY * moveSpeed * Time.deltaTime);

        LifeTrack();
        PointsTrack();
        EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("badProj"))
        {
            TakeLife(5);
            Debug.Log("Hit by BadShip");
        }

        if (other.CompareTag("asteroid"))
        {
            TakeLife(2);
        }

        if (other.CompareTag("mine"))
        {
            TakeLife(100);
        }
    }

    public void LifeTrack()
    {
        lifeText.text = "Life -  " + lifePoints;
    }
    
    public void PointsTrack()
    {
        pointsText.text = "Kill Points -  " + points;
    }

    public void TakeLife(int takePoints)
    {
        lifePoints -= takePoints;
    }

    public void AddPoints(int addPoints)
    {
        points += addPoints;
    }

    public void ShieldsUp()
    {
        shield.SetActive(true);
        Invoke("ShieldsDown", 10);
    }

    void ShieldsDown()
    {
        shield.SetActive(false);
    }

    public void EndGame()
    {
        if (lifePoints <= 0)
        {
            endPanelMessage.text = "You's a Looser! Wanna Reincarnate?";
            endPanel.SetActive(true);
            shield.SetActive(true);
            Destroy(gameObject);
        }

        if (points >= 100)
        {
            endPanelMessage.text = "Dang mane! You've killed so many loser purple farts, Noone in this whole quadrant will mess with you and therefore the game shall become boring... Wanna Reincarnate?";
            endPanel.SetActive(true);
            shield.SetActive(true);
            Destroy(gameObject);
        }
    }
}
