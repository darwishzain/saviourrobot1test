using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toLeft : MonoBehaviour
{
    public GameObject thePlayer;
    player playerScript;
    void Start()
    {
        playerScript = thePlayer.GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*30*Time.deltaTime);
        if(transform.position.x<=-10)
        {
            Destroy(this.gameObject);
        }
        
        if(playerScript.startGame==true)
        {
            Destroy(this.gameObject);
        }
        

    }
}
