using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        //Rotate Coin constantly
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }

    //Checks if coin overlaps with another gameObject
    private void OnTriggerEnter(Collider other)
    {
        //If gameObject is an Obstacle
        if(other.gameObject.GetComponent<Obstacle>() != null)
        {
            //Desroy coin
            Destroy(gameObject);
        }

        //If gameObject is the Player
        if (other.gameObject.CompareTag("Player"))
        {
            //Call AddCoin in player script
            player.AddCoin();

            //Destroy soin
            Destroy(gameObject);
        }
    }
}
