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

    public GameObject centralElement;

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

            //se añaden posiciones inutilizables
            //rController.usedCells.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y));

            rController.usedCells.Add(new Vector2Int((int)transform.position.x + 10, (int)transform.position.y - 2));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x + 10, (int)transform.position.y - 1));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x + 10, (int)transform.position.y));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x + 10, (int)transform.position.y + 1));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x + 9, (int)transform.position.y - 2));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x + 9, (int)transform.position.y - 1));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x + 9, (int)transform.position.y));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x + 9, (int)transform.position.y + 1));

            rController.usedCells.Add(new Vector2Int((int)transform.position.x - 10, (int)transform.position.y - 2));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x - 10, (int)transform.position.y - 1));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x - 10, (int)transform.position.y));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x - 10, (int)transform.position.y + 1));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x - 9, (int)transform.position.y - 2));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x - 9, (int)transform.position.y - 1));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x - 9, (int)transform.position.y));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x - 9, (int)transform.position.y + 1));

            rController.usedCells.Add(new Vector2Int((int)transform.position.x -1, (int)transform.position.y - 6));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y - 6));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y - 6));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y - 5));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y - 5));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y - 5));

            rController.usedCells.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y + 2));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + 2));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y + 2));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y + 3));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + 3));
            rController.usedCells.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y + 3));

            if(rController.currentRooms > rController.maxRooms)
            {
                rController.usedCells.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y));
                rController.usedCells.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y));
                rController.usedCells.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y));
                rController.usedCells.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y + 1));
                rController.usedCells.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y + 1));
                rController.usedCells.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y + 1));
                rController.usedCells.Add(new Vector2Int((int)transform.position.x, (int)transform.position.y - 1));
                rController.usedCells.Add(new Vector2Int((int)transform.position.x + 1, (int)transform.position.y - 1));
                rController.usedCells.Add(new Vector2Int((int)transform.position.x - 1, (int)transform.position.y - 1));
            }

            if (Random.Range(0.0f, 1.0f) < rController.centralChance)
            {
                initializeCentralElement(rController.centralElemList[Random.Range(0, rController.centralElemList.Count)]);
            }

            for (int i = 0; i < rController.elementList.Count; i++)
            {
                int amount = Random.Range(rController.elementNumberMean[i] - rController.elementNumberVariance[i], rController.elementNumberMean[i] + rController.elementNumberVariance[i]);
                initializeElement(rController.elementList[i], amount);
            }
        }
    }

    public void initializeCentralElement(GameObject element)
    {
        Vector2Int positionVector = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        centralElement = Instantiate(element, new Vector3Int(positionVector.x, positionVector.y, 0), Quaternion.identity, transform);

        //se añaden al hashset las casillas que ocupa el element
        rController.usedCells.Add(positionVector);
        Size elementSize = element.GetComponent<Size>();
        if (elementSize.getDimensions().Count > 1)
        {
            for (int i = 1; i < elementSize.getDimensions().Count; i++)
            {
                rController.usedCells.Add(positionVector + elementSize.getDimensions()[i]);
            }
        }

        if (element.CompareTag("Enemy")) { GameObject.Find("Canvas").GetComponent<PlayerInterface>().addEnemiesToKill(1); }
    }

    public void initializeElement(GameObject element, int amount)
    {
        for(int i=0; i<amount; i++)
        {
            Instantiate(element, getRandomPosition(element), Quaternion.identity, transform);
        }
        if (element.CompareTag("Enemy")) { GameObject.Find("Canvas").GetComponent<PlayerInterface>().addEnemiesToKill(amount); }
    }

    Vector3Int getRandomPosition(GameObject element)
    {
        Size elementSize = element.GetComponent<Size>();
        Vector2Int positionVector = new Vector2Int(Random.Range(topLeft.x + 1, bottomRight.x - 1) , Random.Range(bottomRight.y + 1, topLeft.y - 1));
        int counter = 0;
        while (rController.usedCells.Contains(positionVector) && counter < 100)
        {
            moveRandomPos(ref positionVector, elementSize.move);
            counter++;
        }

        //se añaden al hashset las casillas que ocupa el element
        rController.usedCells.Add(positionVector);
        if (elementSize.dimSize > 1)
        {
            for (int i = 1; i < elementSize.dimSize; i++)
            {
                rController.usedCells.Add(positionVector + elementSize.getDimensions()[i]);
            }
        }
        return new Vector3Int(positionVector.x, positionVector.y, 0);
    }

    void moveRandomPos(ref Vector2Int posVector, int multiply)
    {
        Vector2Int moveDir = new Vector2Int(Random.Range(-1, 2) * multiply, Random.Range(-1, 2) * multiply);

        posVector += moveDir;
        if (posVector.y >= topLeft.y)
        {
            posVector.y = bottomRight.y + (2 + multiply - 1);
        }
        else if (posVector.y <= bottomRight.y)
        {
            posVector.y = topLeft.y - (2 + multiply - 1);
        }

        if (posVector.x <= topLeft.x)
        {
            posVector.x = bottomRight.x - (2 + multiply - 1);
        }
        else if (posVector.x >= bottomRight.x)
        {
            posVector.x = topLeft.x + (2 + multiply - 1);
        }
    }
}
