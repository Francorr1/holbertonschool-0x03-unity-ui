using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;
    public float speed = 1000f;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            score += 1;
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            SetHealthText();
        }
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("You Win!");
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }
}
