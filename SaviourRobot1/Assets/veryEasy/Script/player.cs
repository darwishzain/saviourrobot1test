using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class player : MonoBehaviour
{
    public Rigidbody2D thePlayer;
    public GameObject[] theHeart;
    public TextMeshProUGUI theStatus;
    public GameObject theDrone;
    public GameObject theCorona;
    public GameObject toEasybtn;

    public float jumpForce;
    public float life;
    public float minY, maxY;
    public float distance;
    public float countDown;

    public bool startGame;
    public bool winGame=false;
    void Start()
    {
        thePlayer = GetComponent<Rigidbody2D>();
        toEasybtn.SetActive(false);
        gameOn();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Jump")))
        {
            Time.timeScale = 1;
            startGame = true;
            thePlayer.velocity = new Vector2(0, 1) * jumpForce * Time.deltaTime;
        }
        if (startGame)
        {
            countDown -= Time.deltaTime;
            theStatus.text = countDown.ToString("F2")+"km";
            if (transform.position.y > 5 || transform.position.y < -5)
            {
                minusHealth();
            }
            if(countDown<=0)
            {
                winGame = true;
                toEasybtn.SetActive(true);
                //theStatus.text = "You've won. Continue with next level";
                Time.timeScale = 0;               
            }
        }
    }
    IEnumerator theCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            float yCorona = Random.Range(minY, maxY);
            float yDrone = Random.Range(-minY, -maxY);

            Instantiate(theCorona, new Vector2(10, yCorona), Quaternion.identity);
            Instantiate(theDrone, new Vector2(10, yDrone), Quaternion.identity);
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
        StopAllCoroutines();
        Time.timeScale = 0;//Pause the game

        countDown = distance;
        StartCoroutine(theCoroutine());
        theStatus.text = "Press [Spacebar] to start";//if player press spacebar the game continues
        transform.position = new Vector2(0, 0);//reset the player position
        transform.rotation = Quaternion.identity;
    }

    void minusHealth()
    {
        life--;
        startGame = false;
            if (life < 1)
            {
                Destroy(theHeart[0].gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                
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
            
            gameOn();
        
        
    }
}
