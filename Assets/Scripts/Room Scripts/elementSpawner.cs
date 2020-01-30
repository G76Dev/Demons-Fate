using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementSpawner : MonoBehaviour
{
    [SerializeField] Vector2Int topLeft;
    [SerializeField] Vector2Int bottomRight;
    [SerializeField] bool isStartingRoom = false;
    int usableHeight;
    int usableWidth;

    roomController rController;

    void Start()
    {
        usableHeight = topLeft.y - bottomRight.y + 1;
        usableWidth = bottomRight.x - topLeft.x + 1;

        rController = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomController>();

        if (!isStartingRoom)
        {
            topLeft.x += (int)transform.position.x; //se ajusta a la x de la room adecuada
            topLeft.y += (int)transform.position.y; //se ajusta a la y de la room adecuada
            bottomRight.x += (int)transform.position.x; //se ajusta a la x de la room adecuada
            bottomRight.y += (int)transform.position.y; //se ajusta a la y de la room adecuada


            rController.usedCells.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y)); //se añade el centro de la room para que no se puedan crear cosas en el

            for (int i = 0; i < rController.elementList.Count; i++)
            {
                int amount = Random.Range(rController.elementNumberMean[i] - rController.elementNumberVariance[i], rController.elementNumberMean[i] + rController.elementNumberVariance[i]);
                initializeElement(rController.elementList[i], amount);
            }
        }
    }

    public void initializeElement(GameObject element, int amount)
    {
        for(int i=0; i<amount; i++)
        {
            Instantiate(element, getRandomPosition(), Quaternion.identity, transform);
        }
        if (element.CompareTag("Enemy")) { GameObject.Find("Canvas").GetComponent<PlayerInterface>().addEnemiesToKill(amount); }
    }

    Vector3 getRandomPosition()
    {
        Vector2Int positionVector = new Vector2Int(Random.Range(topLeft.x + 1, bottomRight.x - 1) , Random.Range(bottomRight.y + 1, topLeft.y - 1));
        while (rController.usedCells.Contains(positionVector))
        {
            moveRandomPos(ref positionVector);
        }
        rController.usedCells.Add(positionVector);
        return new Vector3(positionVector.x, positionVector.y, 0);
    }

    void moveRandomPos(ref Vector2Int posVector)
    {
        Vector2Int moveDir = new Vector2Int(Random.Range(-1, 2), Random.Range(-1, 2));

        posVector += moveDir;
        if (posVector.y >= topLeft.y)
        {
            posVector.y = bottomRight.y + 2;
        }
        else if (posVector.y <= bottomRight.y)
        {
            posVector.y = topLeft.y - 2;
        }

        if (posVector.x <= topLeft.x)
        {
            posVector.x = bottomRight.x - 2;
        }
        else if (posVector.x >= bottomRight.x)
        {
            posVector.x = topLeft.x + 2;
        }
    }
}
