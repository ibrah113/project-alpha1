using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    //Check if gameObject Collides with another gameObject
    private void OnCollisionEnter(Collision collision)
    {
        //If gameObject is a player
        if(collision.gameObject.CompareTag("Player"))
        {
            //Call Die in player script
            player.Die();
        }
    }

}
