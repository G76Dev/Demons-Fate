using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size : MonoBehaviour
{
    public int objId = 0;
    public int dimSize = 1;
    public int move = 1;
    static List<Vector2Int> usedCells;
    static List<Vector2Int> usedCells_Big;

    public static void initializeUsedCells()
    {
        usedCells = new List<Vector2Int>();
        usedCells.Add(new Vector2Int(0, 0));
        usedCells_Big = new List<Vector2Int>();
        #region cells_Big
        usedCells_Big.Add(new Vector2Int(-4, -4));
        usedCells_Big.Add(new Vector2Int(-3, -4));
        usedCells_Big.Add(new Vector2Int(-2, -4));
        usedCells_Big.Add(new Vector2Int(-1, -4));
        usedCells_Big.Add(new Vector2Int(0, -4));
        usedCells_Big.Add(new Vector2Int(1, -4));
        usedCells_Big.Add(new Vector2Int(2, -4));
        usedCells_Big.Add(new Vector2Int(3, -4));
        usedCells_Big.Add(new Vector2Int(4, -4));

        usedCells_Big.Add(new Vector2Int(-4, -3));
        usedCells_Big.Add(new Vector2Int(-3, -3));
        usedCells_Big.Add(new Vector2Int(-2, -3));
        usedCells_Big.Add(new Vector2Int(-1, -3));
        usedCells_Big.Add(new Vector2Int(0, -3));
        usedCells_Big.Add(new Vector2Int(1, -3));
        usedCells_Big.Add(new Vector2Int(2, -3));
        usedCells_Big.Add(new Vector2Int(3, -3));
        usedCells_Big.Add(new Vector2Int(4, -3));

        usedCells_Big.Add(new Vector2Int(-4, -2));
        usedCells_Big.Add(new Vector2Int(-3, -2));
        usedCells_Big.Add(new Vector2Int(-2, -2));
        usedCells_Big.Add(new Vector2Int(-1, -2));
        usedCells_Big.Add(new Vector2Int(0, -2));
        usedCells_Big.Add(new Vector2Int(1, -2));
        usedCells_Big.Add(new Vector2Int(2, -2));
        usedCells_Big.Add(new Vector2Int(3, -2));
        usedCells_Big.Add(new Vector2Int(4, -2));

        usedCells_Big.Add(new Vector2Int(-4, -1));
        usedCells_Big.Add(new Vector2Int(-3, -1));
        usedCells_Big.Add(new Vector2Int(-2, -1));
        usedCells_Big.Add(new Vector2Int(-1, -1));
        usedCells_Big.Add(new Vector2Int(0, -1));
        usedCells_Big.Add(new Vector2Int(1, -1));
        usedCells_Big.Add(new Vector2Int(2, -1));
        usedCells_Big.Add(new Vector2Int(3, -1));
        usedCells_Big.Add(new Vector2Int(4, -1));

        usedCells_Big.Add(new Vector2Int(-4, 0));
        usedCells_Big.Add(new Vector2Int(-3, 0));
        usedCells_Big.Add(new Vector2Int(-2, 0));
        usedCells_Big.Add(new Vector2Int(-1, 0));
        usedCells_Big.Add(new Vector2Int(0, 0));
        usedCells_Big.Add(new Vector2Int(1, 0));
        usedCells_Big.Add(new Vector2Int(2, 0));
        usedCells_Big.Add(new Vector2Int(3, 0));
        usedCells_Big.Add(new Vector2Int(4, 0));

        usedCells_Big.Add(new Vector2Int(-4, 1));
        usedCells_Big.Add(new Vector2Int(-3, 1));
        usedCells_Big.Add(new Vector2Int(-2, 1));
        usedCells_Big.Add(new Vector2Int(-1, 1));
        usedCells_Big.Add(new Vector2Int(0, 1));
        usedCells_Big.Add(new Vector2Int(1, 1));
        usedCells_Big.Add(new Vector2Int(2, 1));
        usedCells_Big.Add(new Vector2Int(3, 1));
        usedCells_Big.Add(new Vector2Int(4, 1));

        usedCells_Big.Add(new Vector2Int(-4, 2));
        usedCells_Big.Add(new Vector2Int(-3, 2));
        usedCells_Big.Add(new Vector2Int(-2, 2));
        usedCells_Big.Add(new Vector2Int(-1, 2));
        usedCells_Big.Add(new Vector2Int(0, 2));
        usedCells_Big.Add(new Vector2Int(1, 2));
        usedCells_Big.Add(new Vector2Int(2, 2));
        usedCells_Big.Add(new Vector2Int(3, 2));
        usedCells_Big.Add(new Vector2Int(4, 2));

        usedCells_Big.Add(new Vector2Int(-4, 3));
        usedCells_Big.Add(new Vector2Int(-3, 3));
        usedCells_Big.Add(new Vector2Int(-2, 3));
        usedCells_Big.Add(new Vector2Int(-1, 3));
        usedCells_Big.Add(new Vector2Int(0, 3));
        usedCells_Big.Add(new Vector2Int(1, 3));
        usedCells_Big.Add(new Vector2Int(2, 3));
        usedCells_Big.Add(new Vector2Int(3, 3));
        usedCells_Big.Add(new Vector2Int(4, 3));

        usedCells_Big.Add(new Vector2Int(-4, 4));
        usedCells_Big.Add(new Vector2Int(-3, 4));
        usedCells_Big.Add(new Vector2Int(-2, 4));
        usedCells_Big.Add(new Vector2Int(-1, 4));
        usedCells_Big.Add(new Vector2Int(0, 4));
        usedCells_Big.Add(new Vector2Int(1, 4));
        usedCells_Big.Add(new Vector2Int(2, 4));
        usedCells_Big.Add(new Vector2Int(3, 4));
        usedCells_Big.Add(new Vector2Int(4, 4));
        #endregion
    }

    public List<Vector2Int> getDimensions()
    {
        switch (objId)
        {
            case 4:
                return usedCells_Big;
            default:
                return usedCells;
        }
    }
}
