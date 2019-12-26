using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField] private PlayerController thePlayer;
    private Rigidbody2D myRigidbody;
    [SerializeField] private float speed = 3;
    private string currentDirection = "Up";
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Walk(currentDirection);
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

    void OnCollisionEnter2D(Collision2D other)
    {
        string lastDirection = currentDirection;
        float distanceX = Mathf.Abs(transform.position.x - other.transform.position.x);
        float distanceY = Mathf.Abs(transform.position.y - other.transform.position.y);

        Vector2 contract = other.contacts[0].normal;
        Debug.Log(contract.x);

        if ((int)contract.x != 0)
        {
            if (contract.x > 0) // Left
            {
                if (transform.position.y > thePlayer.transform.position.y)
                    currentDirection = "Down";
                else
                    currentDirection = "Up";
            }
            else // Right
            {
                if (transform.position.y > thePlayer.transform.position.y)
                    currentDirection = "Down";
                else
                    currentDirection = "Up";
            }
        }
        else
        {
            if (contract.y > 0) // Down
            {
                if (transform.position.x > thePlayer.transform.position.x)
                    currentDirection = "Left";
                else
                    currentDirection = "Right";
            }
            else // Up
            {
                if (transform.position.x > thePlayer.transform.position.x)
                    currentDirection = "Left";
                else
                    currentDirection = "Right";
            }
        }

    }

    List<string> PathFinder()
    {
        List<string> Path = new List<string>();

        return Path;
    }
}

