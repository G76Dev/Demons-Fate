using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFromPoint : MonoBehaviour
{
    public int openingDirection; //1 abajo, 2 arriba, 3 izq, 4 drch

    roomPrefabs rPrefabs;
    Transform transformRoomPrefabs;
    int rand;
    public bool spawned = false;

    void Start()
    {
        GameObject roomPrefabsObject = GameObject.FindGameObjectWithTag("Rooms");
        rPrefabs = roomPrefabsObject.GetComponent<roomPrefabs>();
        transformRoomPrefabs = roomPrefabsObject.GetComponent<Transform>();
        Invoke("spawnRooms", 1);
    }

    void spawnRooms()
    {
        //yield return new WaitForSeconds(3);
        if (!spawned)
        {
            if (rPrefabs.currentRooms < rPrefabs.maxRooms)
            {
                if (openingDirection == 1)
                {
                    rand = Random.Range(0, rPrefabs.upRooms.Length);
                    var createdRoom = Instantiate(rPrefabs.upRooms[rand], transform.position, Quaternion.identity, transformRoomPrefabs);
                    rPrefabs.roomCreated(createdRoom);
                }
                else if (openingDirection == 2)
                {
                    rand = Random.Range(0, rPrefabs.downRooms.Length);
                    var createdRoom = Instantiate(rPrefabs.downRooms[rand], transform.position, Quaternion.identity, transformRoomPrefabs);
                    rPrefabs.roomCreated(createdRoom);
                }
                else if (openingDirection == 3)
                {
                    rand = Random.Range(0, rPrefabs.rightRooms.Length);
                    var createdRoom = Instantiate(rPrefabs.rightRooms[rand], transform.position, Quaternion.identity, transformRoomPrefabs);
                    rPrefabs.roomCreated(createdRoom);
                }
                else if (openingDirection == 4)
                {
                    rand = Random.Range(0, rPrefabs.leftRooms.Length);
                    var createdRoom = Instantiate(rPrefabs.leftRooms[rand], transform.position, Quaternion.identity, transformRoomPrefabs);
                    rPrefabs.roomCreated(createdRoom);
                }
                spawned = true;
            }
            else
            {
                var blockInstance = Instantiate(rPrefabs.block, transform.position, Quaternion.identity, transformRoomPrefabs);
                blockInstance.GetComponent<Rigidbody2D>().WakeUp();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if(!collision.GetComponent<spawnFromPoint>().spawned && !spawned)
            {
                if (transform.position.x != 0 && transform.position.y != 0)
                {
                    var blockInstance = Instantiate(rPrefabs.block, transform.position, Quaternion.identity, transformRoomPrefabs);
                    blockInstance.GetComponent<Rigidbody2D>().WakeUp();
                }
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
