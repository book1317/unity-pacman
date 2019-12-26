using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] Text scoreText;
    private Rigidbody2D myRigidbody;
    public int score;
    private LevelController theLevel;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        theLevel = FindObjectOfType<LevelController>();
    }

    void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetButtonDown("Left"))
                Walk("Left");
            else if (Input.GetButtonDown("Right"))
                Walk("Right");
            else if (Input.GetButtonDown("Up"))
                Walk("Up");
            else if (Input.GetButtonDown("Down"))
                Walk("Down");
        }
    }

    void Walk(string direction)
    {
        switch (direction)
        {
            case "Left":
                myRigidbody.velocity = new Vector3(-speed, 0, 0);
                break;
            case "Right":
                myRigidbody.velocity = new Vector3(speed, 0, 0);
                break;
            case "Up":
                myRigidbody.velocity = new Vector3(0, speed, 0);
                break;
            case "Down":
                myRigidbody.velocity = new Vector3(0, -speed, 0);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Food theFood = other.GetComponent<Food>();
            increaScore(theFood.score);
            theLevel.theFoodManager.RemoveFood(theFood);
            Destroy(other.gameObject);
            theLevel.CheckWin();
        }
        if (other.CompareTag("Ghost"))
        {
            Death();
        }
    }

    void increaScore(int score)
    {
        this.score += score;
        UpdateScoreText(this.score);
    }

    void UpdateScoreText(int score)
    {
        scoreText.text = score + "";
    }

    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //     void Walk(string direction)
    // {
    //     switch (direction)
    //     {
    //         case "Left":
    //             transform.position = new Vector3(-speed, transform.position.y, transform.position.z);
    //             break;
    //         case "Right":
    //             transform.position = new Vector3(speed, transform.position.y, transform.position.z);
    //             break;
    //         case "Up":
    //             transform.position = new Vector3(transform.position.x, speed, transform.position.z);
    //             break;
    //         case "Down":
    //             transform.position = new Vector3(transform.position.x, -speed, transform.position.z);
    //             break;
    //     }
    // }
}
