using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rd2d;
    public float speed;
    public Text scoreText;
    public Text winText;
    public Text lifeText;
    private int lifeValue = 3;
    private int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        scoreText.text = "Count: " + scoreValue.ToString();
        lifeText.text = "Life: " + lifeValue.ToString();
        winText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            scoreText.text = "Count: " + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            if (scoreValue >= 8)
            {
                winText.text = "You win! Game created by Yna Camagay.";
            }
            if (scoreValue == 4)
            {
                transform.position = new Vector2(50.0f, 5.0f);
                lifeText.text = "Life: " + lifeValue.ToString();
            }
        }
        else if(collision.collider.tag == "Enemy")
        {
            lifeValue -= 1;
            lifeText.text = "Life: " + lifeValue.ToString();
            Destroy(collision.collider.gameObject);
            if (lifeValue == 0)
            {
                winText.text = "You lose! Game Created by Yna Camagay.";
                Destroy(this);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
}
