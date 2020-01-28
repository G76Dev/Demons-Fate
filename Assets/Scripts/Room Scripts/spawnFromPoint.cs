using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFromPoint : MonoBehaviour
{
    public int openingDirection; //1 abajo, 2 arriba, 3 izq, 4 drch

    roomController rController;
    Transform transformRoomController;
    int rand;
    public bool spawned = false;

    void Start()
    {
        GameObject roomControllerObject = GameObject.FindGameObjectWithTag("Rooms");
        rController = roomControllerObject.GetComponent<roomController>();
        transformRoomController = roomControllerObject.GetComponent<Transform>();
        Invoke("spawnRooms", 1);
    }

    void spawnRooms()
    {
        //yield return new WaitForSeconds(3);
        if (!spawned)
        {
            if (rController.currentRooms < rController.maxRooms)
            {
                if (openingDirection == 1)
                {
                    rand = Random.Range(0, rController.upRooms.Length);
                    var createdRoom = Instantiate(rController.upRooms[rand], transform.position, Quaternion.identity, transformRoomController);
                    rController.roomCreated(createdRoom);
                }
                else if (openingDirection == 2)
                {
                    rand = Random.Range(0, rController.downRooms.Length);
                    var createdRoom = Instantiate(rController.downRooms[rand], transform.position, Quaternion.identity, transformRoomController);
                    rController.roomCreated(createdRoom);
                }
                else if (openingDirection == 3)
                {
                    rand = Random.Range(0, rController.rightRooms.Length);
                    var createdRoom = Instantiate(rController.rightRooms[rand], transform.position, Quaternion.identity, transformRoomController);
                    rController.roomCreated(createdRoom);
                }
                else if (openingDirection == 4)
                {
                    rand = Random.Range(0, rController.leftRooms.Length);
                    var createdRoom = Instantiate(rController.leftRooms[rand], transform.position, Quaternion.identity, transformRoomController);
                    rController.roomCreated(createdRoom);
                }
                spawned = true;
            }
            else
            {
                var blockInstance = Instantiate(rController.block, transform.position, Quaternion.identity, transformRoomController);
                blockInstance.GetComponent<Rigidbody2D>().WakeUp();
                rController.lastRoomInit();
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
                    var blockInstance = Instantiate(rController.block, transform.position, Quaternion.identity, transformRoomController);
                    blockInstance.GetComponent<Rigidbody2D>().WakeUp();
                }
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
