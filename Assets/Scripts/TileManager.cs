using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;

    void Start()
    {
        for (int i = 0; i<numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length));
                //SpawnTile(4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn - (numberOfTiles*tileLength))
        {
           SpawnTile(Random.Range(0, tilePrefabs.Length));
           //SpawnTile(4);
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        //Original One
        //Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);

        //I added the below 2 lines
        Vector3 newPosition = new Vector3(-1.5f, 0, zSpawn);
        GameObject go = Instantiate(tilePrefabs[tileIndex], newPosition, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;

    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
