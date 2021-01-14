using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toLeft : MonoBehaviour
{
    public GameObject thePlayer;//Player gameObject reference
    player playerScript;//Script in player Reference
    public float sideForce;//Alter in editor for enemy speed 
    void Start()
    {
        playerScript = thePlayer.GetComponent<player>();//referencing script from player
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*sideForce*Time.deltaTime);//move sideways to the left
        if(transform.position.x<=-10)//if beyond the view
        {
            Destroy(this.gameObject);
        }
        
        if(playerScript.startGame==true)//if win the game
        {
            Destroy(this.gameObject);
        }
        

    }
}
