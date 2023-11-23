using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PlatformSpawner spawner;
    
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        //Gets the spawner script
        spawner = GameObject.FindObjectOfType<PlatformSpawner>();
    }


    //Spawns a platform and destroys it after a few seconds if player wxits the plaatform
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            spawner.SpawnTile(true);
            Destroy(gameObject, 2);
        }

    }

    public GameObject obstaclePrefab;

    //Spawns obstacle on either of the 3 spawnpoints
    public void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position + new Vector3(0, 0, 0), Quaternion.identity, transform);
    }

    public GameObject coinPrefab;
    
    //Spawn 10 coins randomly on the platform
    public void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for(int i = 0; i < coinsToSpawn; i++)
        {
            GameObject coin = Instantiate(coinPrefab, transform);
            coin.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    //Get a random pont on the platform
    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        //Check if point is on collider (should not be normally called) and if not gemerating a new point
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        //Makes sure the pint is always on y-level 1
        point.y = 1;

        return point;
    }
}
