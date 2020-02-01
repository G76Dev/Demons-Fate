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
    Vector2Int simplifiedPos;

    void Start()
    {
        simplifiedPos = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        GameObject roomControllerObject = GameObject.FindGameObjectWithTag("Rooms");
        rController = roomControllerObject.GetComponent<roomController>();
        transformRoomController = roomControllerObject.GetComponent<Transform>();
        Invoke("spawnRooms", 0.5f);
    }

    void spawnRooms()
    {
        if (!rController.usedRooms.Contains(simplifiedPos)){
            if (rController.currentRooms < rController.maxRooms && rController.canInitLastRoom)
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
                rController.usedRooms.Add(simplifiedPos); //se añade al conjunto de posiciones ya usadas
                spawned = true;
            }
            else
            {
                var blockInstance = Instantiate(rController.block, transform.position, Quaternion.identity, transformRoomController);
                if(openingDirection == 2)
                {
                    var auxWall = Instantiate(rController.topWall, new Vector3(transform.position.x, transform.position.y - 10.55f, transform.position.z), Quaternion.identity, transformRoomController);
                    auxWall.transform.localScale = new Vector3(1.578f, 1.85f, 1);
                }
                //blockInstance.GetComponent<Rigidbody2D>().WakeUp();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
