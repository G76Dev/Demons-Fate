using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementSpawner : MonoBehaviour
{
    [SerializeField] Vector2Int topLeft;
    [SerializeField] Vector2Int bottomRight;
    int usableHeight;
    int usableWidth;
    HashSet<Vector2Int> usedCells = new HashSet<Vector2Int>();

    void Start()
    {
        usableHeight = topLeft.y - bottomRight.y + 1;
        usableWidth = bottomRight.x - topLeft.x + 1;
    }

    public void initializeElement(GameObject element, Transform roomInstance, int amount)
    {
        for(int i=0; i<amount; i++)
        {
            Instantiate(element, getRandomPosition() + transform.position, Quaternion.identity, roomInstance);
        }
    }

    Vector3 getRandomPosition()
    {
        Vector2Int positionVector = new Vector2Int(Random.Range(topLeft.x, bottomRight.x) , Random.Range(bottomRight.y, topLeft.y));
        while (usedCells.Contains(positionVector))
        {
            moveRandomPos(ref positionVector);
        }
        usedCells.Add(positionVector);
        return new Vector3(positionVector.x, positionVector.y, 0);
    }

    void moveRandomPos(ref Vector2Int posVector)
    {
        Vector2Int moveDir = new Vector2Int(Random.Range(-1, 2), Random.Range(-1, 2));

        posVector += moveDir;
        if (posVector.y >= topLeft.y + 1)
        {
            posVector.y = bottomRight.y;
        }
        else if (posVector.y <= bottomRight.y - 1)
        {
            posVector.y = topLeft.y;
        }

        if (posVector.x <= topLeft.x - 1)
        {
            posVector.x = bottomRight.x;
        }
        else if (posVector.x >= bottomRight.x + 1)
        {
            posVector.x = topLeft.x;
        }
    }
}
