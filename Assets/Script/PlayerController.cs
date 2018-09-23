using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;

    private Rigidbody rb;
    private int count;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetCountText();
        winText.text ="";
        SetScoreText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("NegPickUp"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Pick Up" + "NegPickUp"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetScoreText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Finished with a score of: [x]";
        }

    }

    void SetScoreText ()
    {
        scoreText.text = "Score: " + score.ToString();

    }

}
