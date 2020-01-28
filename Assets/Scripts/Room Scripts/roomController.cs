﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomController : MonoBehaviour
{
    [Header("Elements")]
    public List<GameObject> elementList;
    public List<int> elementNumberMean;
    public List<int> elementNumberVariance;

    [HideInInspector] public HashSet<Vector2Int> usedCells = new HashSet<Vector2Int>();

    [HideInInspector] public int maxRooms;
    [HideInInspector] public int currentRooms = 0;

    [Header("Rooms")]
    public int maxRoomsMean;
    public int maxRoomsVariance;
    public GameObject[] downRooms;
    public GameObject[] upRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;
    public GameObject block;
    public GameObject ending;
    public GameObject lastRoom;
    bool canInitLastRoom = true;

    private void Start()
    {
        maxRooms = Random.Range(maxRoomsMean - maxRoomsVariance, maxRoomsMean + maxRoomsVariance) - 1;   
    }

    public void roomCreated(GameObject r)
    {
        currentRooms++;
        lastRoom = r;
    }

    public void lastRoomInit()
    {
        if (canInitLastRoom)
        {
            canInitLastRoom = false;
            Instantiate(ending, lastRoom.transform.position, Quaternion.identity, lastRoom.transform);
        }
    }

    /*void Start()
    {
        //se inicializa la habitacion
        var roomInstance = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity, transform);

        //por cada elemento de roomSpawner se inicializa en la habitacion
        elementSpawner roomScript = roomInstance.GetComponent<elementSpawner>();
        for (int i = 0; i < elementList.Count; i++)
        {
            int number = Random.Range(elementNumberMean[i] - elementNumberVariance[i], elementNumberMean[i] + elementNumberVariance[i]);
            roomScript.initializeElement(elementList[i], roomInstance.transform, number);
        }
    }*/
}
