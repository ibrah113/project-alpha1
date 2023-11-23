using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platformTile;
    Vector3 nextSpawnPoint;
    
    public void SpawnTile(bool spawnItems)
    {
        //Creates a new GameObject and saves its information in temp
        GameObject temp = Instantiate(platformTile, nextSpawnPoint, transform.rotation);
        //Sets the next Spawnpoint to be the current position of the second child in the newly created GameObject
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if(spawnItems)
        {
            temp.GetComponent<Platform>().SpawnObstacle();
            temp.GetComponent<Platform>().SpawnObstacle();
            temp.GetComponent<Platform>().SpawnCoins();

        }
    }
    
    void Start()
    {
        //Spawns 8 Tiles at Start
        for(int i = 0; i < 8; i++)
        {
            if(i < 3) SpawnTile(false);
            else SpawnTile(true);
        }
        
    }


}
