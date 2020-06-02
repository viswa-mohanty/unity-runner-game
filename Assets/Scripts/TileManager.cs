using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject[] tilePrefabs2;//new
    public GameObject[] tilePrefabs3;//new
    public GameObject[] tilePrefabs4;//new
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;
    private int countOfSpawns = 0; //new
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;

    void Start()
    {
        for (int i = 0; i<numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, tilePrefabs2.Length));
                //SpawnTile(4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn - (numberOfTiles*tileLength))
        {
           /*SpawnTile(Random.Range(0, tilePrefabs.Length));
           //SpawnTile(4);
            DeleteTile();*/

            //new
            if((countOfSpawns % 20) < 5)
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
                DeleteTile();

            } 
            else if ((countOfSpawns % 25) >= 5 && (countOfSpawns % 25) < 10)
            {
                SpawnTile(Random.Range(0, tilePrefabs2.Length));
                DeleteTile();
            }
            else if ((countOfSpawns % 25) >= 10  && (countOfSpawns % 25) < 15)
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
                DeleteTile();
            }
            else if ((countOfSpawns % 25) >= 15 && (countOfSpawns % 25) < 20)
            {
                SpawnTile(Random.Range(0, tilePrefabs3.Length));
                DeleteTile();
            }
            else 
            {
                SpawnTile(Random.Range(0, tilePrefabs4.Length));
                DeleteTile();
            }
            //end new
        }
    }

    public void SpawnTile(int tileIndex)
    {
        //Original One
        //Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);

        //I added the below 2 lines
        Vector3 newPosition = new Vector3(-1.5f, 0, zSpawn);
        //GameObject go = Instantiate(tilePrefabs[tileIndex], newPosition, transform.rotation);
        //new
        GameObject go = new GameObject();
        if ((countOfSpawns % 25) < 5)
        {
            go = Instantiate(tilePrefabs[tileIndex], newPosition, transform.rotation);
        }
        else if ((countOfSpawns % 25) >= 5 && (countOfSpawns % 25) < 10)
        {
            go = Instantiate(tilePrefabs2[tileIndex], newPosition, transform.rotation);
        }
        else if ((countOfSpawns % 25) >= 10 && (countOfSpawns % 25) < 15)
        {
            go = Instantiate(tilePrefabs[tileIndex], newPosition, transform.rotation);
        }
        else if ((countOfSpawns % 25) >= 15 && (countOfSpawns % 25) < 20)
        {
            go = Instantiate(tilePrefabs3[tileIndex], newPosition, transform.rotation);
        }
        else
        {
            go = Instantiate(tilePrefabs4[tileIndex], newPosition, transform.rotation);
        }
        activeTiles.Add(go);
        zSpawn += tileLength;
        countOfSpawns++;//new

    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
