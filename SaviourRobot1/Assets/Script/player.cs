using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public Rigidbody2D thePlayer;
    public GameObject[] theHeart;
    public TextMeshProUGUI theStatus;

    public float jumpForce;
    public float life;

    public bool startGame;
    void Start()
    {
        thePlayer = GetComponent<Rigidbody2D>();
        gameOn();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")))
        {
            Time.timeScale = 1;
            thePlayer.velocity = new Vector2(0, 1) * jumpForce * Time.deltaTime;
        }
        if (startGame)
        {
            if (transform.position.y > 5 || transform.position.y < -5)
            {
                startGame = false;
                minusHealth();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="enemy")
        {
            minusHealth();
        }
    }
    void gameOn()
    {
        startGame = true;
        Time.timeScale = 0;//Pause the game
        theStatus.text = "Press [Spacebar] to start";//if player press spacebar the game continues
        transform.position = new Vector2(0, 0);//reset the player position
    }

    void minusHealth()
    {
        if(life<1)
        {
            Destroy(theHeart[0].gameObject);
        }
        else if (life < 2)
        {
            Destroy(theHeart[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(theHeart[2].gameObject);
        }
        else if (life < 4)
        {
            Destroy(theHeart[3].gameObject);
        }
        else if (life < 5)
        {
            Destroy(theHeart[4].gameObject);
        }
        life--;
        gameOn();
    }
}
