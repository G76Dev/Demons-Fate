using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomPrefabs : MonoBehaviour
{
    [HideInInspector] public int maxRooms;
    [HideInInspector] public int currentRooms = 0;
    public int maxRoomsMean;
    public int maxRoomsVariance;

    public GameObject[] downRooms;
    public GameObject[] upRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject block;

    public GameObject lastRoom;

    private void Start()
    {
        maxRooms = Random.Range(maxRoomsMean - maxRoomsVariance, maxRoomsMean + maxRoomsVariance) - 1;   
    }

    public void roomCreated(GameObject r)
    {
        currentRooms++;
        lastRoom = r;
    }
}
