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
    static List<Vector2Int> usedCells_central_Shooters;
    static List<Vector2Int> usedCells_central_Life;
    static List<Vector2Int> usedCells_central_Four;
    static List<Vector2Int> usedCells_central_Cross;

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
        usedCells_central_Shooters = new List<Vector2Int>();
        #region cells_Shooters
        usedCells_central_Shooters.Add(new Vector2Int(-4, -7));
        usedCells_central_Shooters.Add(new Vector2Int(-5, -7));
        usedCells_central_Shooters.Add(new Vector2Int(-4, -6));
        usedCells_central_Shooters.Add(new Vector2Int(-5, -6));
        usedCells_central_Shooters.Add(new Vector2Int(-4, -5));
        usedCells_central_Shooters.Add(new Vector2Int(-5, -5));
        usedCells_central_Shooters.Add(new Vector2Int(-4, -4));
        usedCells_central_Shooters.Add(new Vector2Int(-5, -4));
        usedCells_central_Shooters.Add(new Vector2Int(-4, -3));
        usedCells_central_Shooters.Add(new Vector2Int(-5, -3));
        usedCells_central_Shooters.Add(new Vector2Int(-4, -2));
        usedCells_central_Shooters.Add(new Vector2Int(-5, -2));


        usedCells_central_Shooters.Add(new Vector2Int(-6, -2));
        usedCells_central_Shooters.Add(new Vector2Int(-7, -2));
        usedCells_central_Shooters.Add(new Vector2Int(-8, -2));
        usedCells_central_Shooters.Add(new Vector2Int(-9, -2));
        usedCells_central_Shooters.Add(new Vector2Int(-10, -2));
        usedCells_central_Shooters.Add(new Vector2Int(-11, -2));
        usedCells_central_Shooters.Add(new Vector2Int(-6, -3));
        usedCells_central_Shooters.Add(new Vector2Int(-7, -3));
        usedCells_central_Shooters.Add(new Vector2Int(-8, -3));
        usedCells_central_Shooters.Add(new Vector2Int(-9, -3));
        usedCells_central_Shooters.Add(new Vector2Int(-10, -3));
        usedCells_central_Shooters.Add(new Vector2Int(-11, -3));


        usedCells_central_Shooters.Add(new Vector2Int(-8, -5));
        usedCells_central_Shooters.Add(new Vector2Int(-7, -5));


        usedCells_central_Shooters.Add(new Vector2Int(4, -7));
        usedCells_central_Shooters.Add(new Vector2Int(5, -7));
        usedCells_central_Shooters.Add(new Vector2Int(4, -6));
        usedCells_central_Shooters.Add(new Vector2Int(5, -6));
        usedCells_central_Shooters.Add(new Vector2Int(4, -5));
        usedCells_central_Shooters.Add(new Vector2Int(5, -5));
        usedCells_central_Shooters.Add(new Vector2Int(4, -4));
        usedCells_central_Shooters.Add(new Vector2Int(5, -4));
        usedCells_central_Shooters.Add(new Vector2Int(4, -3));
        usedCells_central_Shooters.Add(new Vector2Int(5, -3));
        usedCells_central_Shooters.Add(new Vector2Int(4, -2));
        usedCells_central_Shooters.Add(new Vector2Int(5, -2));


        usedCells_central_Shooters.Add(new Vector2Int(6, -2));
        usedCells_central_Shooters.Add(new Vector2Int(7, -2));
        usedCells_central_Shooters.Add(new Vector2Int(8, -2));
        usedCells_central_Shooters.Add(new Vector2Int(9, -2));
        usedCells_central_Shooters.Add(new Vector2Int(10, -2));
        usedCells_central_Shooters.Add(new Vector2Int(11, -2));
        usedCells_central_Shooters.Add(new Vector2Int(6, -3));
        usedCells_central_Shooters.Add(new Vector2Int(7, -3));
        usedCells_central_Shooters.Add(new Vector2Int(8, -3));
        usedCells_central_Shooters.Add(new Vector2Int(9, -3));
        usedCells_central_Shooters.Add(new Vector2Int(10, -3));
        usedCells_central_Shooters.Add(new Vector2Int(11, -3));


        usedCells_central_Shooters.Add(new Vector2Int(8, -5));
        usedCells_central_Shooters.Add(new Vector2Int(7, -5));
        #endregion
        usedCells_central_Life = new List<Vector2Int>();
        #region cells_Life
        usedCells_central_Life.Add(new Vector2Int(-1, -1));
        usedCells_central_Life.Add(new Vector2Int(0, -1));
        usedCells_central_Life.Add(new Vector2Int(1, -1));
        usedCells_central_Life.Add(new Vector2Int(-1, -2));
        usedCells_central_Life.Add(new Vector2Int(0, -2));
        usedCells_central_Life.Add(new Vector2Int(1, -2));
        usedCells_central_Life.Add(new Vector2Int(-1, -3));
        usedCells_central_Life.Add(new Vector2Int(0, -3));
        usedCells_central_Life.Add(new Vector2Int(1, -3));


        usedCells_central_Life.Add(new Vector2Int(-4, 1));
        usedCells_central_Life.Add(new Vector2Int(-5, 1));
        usedCells_central_Life.Add(new Vector2Int(-4, 0));
        usedCells_central_Life.Add(new Vector2Int(-5, 0));
        usedCells_central_Life.Add(new Vector2Int(-4, -1));
        usedCells_central_Life.Add(new Vector2Int(-5, -1));
        usedCells_central_Life.Add(new Vector2Int(-4, -2));
        usedCells_central_Life.Add(new Vector2Int(-5, -2));
        usedCells_central_Life.Add(new Vector2Int(-4, -3));
        usedCells_central_Life.Add(new Vector2Int(-5, -3));
        usedCells_central_Life.Add(new Vector2Int(-4, -4));
        usedCells_central_Life.Add(new Vector2Int(-5, -4));
        usedCells_central_Life.Add(new Vector2Int(-4, -5));
        usedCells_central_Life.Add(new Vector2Int(-5, -5));


        usedCells_central_Life.Add(new Vector2Int(4, 1));
        usedCells_central_Life.Add(new Vector2Int(5, 1));
        usedCells_central_Life.Add(new Vector2Int(4, 0));
        usedCells_central_Life.Add(new Vector2Int(5, 0));
        usedCells_central_Life.Add(new Vector2Int(4, -1));
        usedCells_central_Life.Add(new Vector2Int(5, -1));
        usedCells_central_Life.Add(new Vector2Int(4, -2));
        usedCells_central_Life.Add(new Vector2Int(5, -2));
        usedCells_central_Life.Add(new Vector2Int(4, -3));
        usedCells_central_Life.Add(new Vector2Int(5, -3));
        usedCells_central_Life.Add(new Vector2Int(4, -4));
        usedCells_central_Life.Add(new Vector2Int(5, -4));
        usedCells_central_Life.Add(new Vector2Int(4, -5));
        usedCells_central_Life.Add(new Vector2Int(5, -5));


        usedCells_central_Life.Add(new Vector2Int(0, -4));
        usedCells_central_Life.Add(new Vector2Int(0, -5));

        usedCells_central_Life.Add(new Vector2Int(0, 0));
        usedCells_central_Life.Add(new Vector2Int(0, 1));
        #endregion
        usedCells_central_Four = new List<Vector2Int>();
        #region cells_Four
        usedCells_central_Four.Add(new Vector2Int(-4, -6));
        usedCells_central_Four.Add(new Vector2Int(-5, -6));
        usedCells_central_Four.Add(new Vector2Int(-6, -6));
        usedCells_central_Four.Add(new Vector2Int(-7, -6));
        usedCells_central_Four.Add(new Vector2Int(-4, -5));
        usedCells_central_Four.Add(new Vector2Int(-5, -5));
        usedCells_central_Four.Add(new Vector2Int(-6, -5));
        usedCells_central_Four.Add(new Vector2Int(-7, -5));
        usedCells_central_Four.Add(new Vector2Int(-4, -4));
        usedCells_central_Four.Add(new Vector2Int(-5, -4));
        usedCells_central_Four.Add(new Vector2Int(-6, -4));
        usedCells_central_Four.Add(new Vector2Int(-7, -4));


        usedCells_central_Four.Add(new Vector2Int(4, -6));
        usedCells_central_Four.Add(new Vector2Int(5, -6));
        usedCells_central_Four.Add(new Vector2Int(6, -6));
        usedCells_central_Four.Add(new Vector2Int(7, -6));
        usedCells_central_Four.Add(new Vector2Int(4, -5));
        usedCells_central_Four.Add(new Vector2Int(5, -5));
        usedCells_central_Four.Add(new Vector2Int(6, -5));
        usedCells_central_Four.Add(new Vector2Int(7, -5));
        usedCells_central_Four.Add(new Vector2Int(4, -4));
        usedCells_central_Four.Add(new Vector2Int(5, -4));
        usedCells_central_Four.Add(new Vector2Int(6, -4));
        usedCells_central_Four.Add(new Vector2Int(7, -4));


        usedCells_central_Four.Add(new Vector2Int(4, 2));
        usedCells_central_Four.Add(new Vector2Int(5, 2));
        usedCells_central_Four.Add(new Vector2Int(6, 2));
        usedCells_central_Four.Add(new Vector2Int(7, 2));
        usedCells_central_Four.Add(new Vector2Int(4, 1));
        usedCells_central_Four.Add(new Vector2Int(5, 1));
        usedCells_central_Four.Add(new Vector2Int(6, 1));
        usedCells_central_Four.Add(new Vector2Int(7, 1));
        usedCells_central_Four.Add(new Vector2Int(4, 0));
        usedCells_central_Four.Add(new Vector2Int(5, 0));
        usedCells_central_Four.Add(new Vector2Int(6, 0));
        usedCells_central_Four.Add(new Vector2Int(7, 0));


        usedCells_central_Four.Add(new Vector2Int(-4, 2));
        usedCells_central_Four.Add(new Vector2Int(-5, 2));
        usedCells_central_Four.Add(new Vector2Int(-6, 2));
        usedCells_central_Four.Add(new Vector2Int(-7, 2));
        usedCells_central_Four.Add(new Vector2Int(-4, 1));
        usedCells_central_Four.Add(new Vector2Int(-5, 1));
        usedCells_central_Four.Add(new Vector2Int(-6, 1));
        usedCells_central_Four.Add(new Vector2Int(-7, 1));
        usedCells_central_Four.Add(new Vector2Int(-4, 0));
        usedCells_central_Four.Add(new Vector2Int(-5, 0));
        usedCells_central_Four.Add(new Vector2Int(-6, 0));
        usedCells_central_Four.Add(new Vector2Int(-7, 0));
        #endregion
        usedCells_central_Cross = new List<Vector2Int>();
        #region cells_Cross
        usedCells_central_Cross.Add(new Vector2Int(-3, 1));
        usedCells_central_Cross.Add(new Vector2Int(-3, 0));
        usedCells_central_Cross.Add(new Vector2Int(-2, 1));
        usedCells_central_Cross.Add(new Vector2Int(-2, 0));
        usedCells_central_Cross.Add(new Vector2Int(-1, 1));
        usedCells_central_Cross.Add(new Vector2Int(-1, 0));
        usedCells_central_Cross.Add(new Vector2Int(0, 1));
        usedCells_central_Cross.Add(new Vector2Int(0, 0));
        usedCells_central_Cross.Add(new Vector2Int(1, 1));
        usedCells_central_Cross.Add(new Vector2Int(1, 0));
        usedCells_central_Cross.Add(new Vector2Int(2, 1));
        usedCells_central_Cross.Add(new Vector2Int(2, 0));
        usedCells_central_Cross.Add(new Vector2Int(3, 1));
        usedCells_central_Cross.Add(new Vector2Int(3, 0));

        usedCells_central_Cross.Add(new Vector2Int(-8, -1));
        usedCells_central_Cross.Add(new Vector2Int(-8, -2));
        usedCells_central_Cross.Add(new Vector2Int(-7, -1));
        usedCells_central_Cross.Add(new Vector2Int(-7, -2));
        usedCells_central_Cross.Add(new Vector2Int(-6, -1));
        usedCells_central_Cross.Add(new Vector2Int(-6, -2));
        usedCells_central_Cross.Add(new Vector2Int(-5, -1));
        usedCells_central_Cross.Add(new Vector2Int(-5, -2));
        usedCells_central_Cross.Add(new Vector2Int(-4, -1));
        usedCells_central_Cross.Add(new Vector2Int(-4, -2));
        usedCells_central_Cross.Add(new Vector2Int(-3, -1));
        usedCells_central_Cross.Add(new Vector2Int(-3, -2));
        usedCells_central_Cross.Add(new Vector2Int(-2, -1));
        usedCells_central_Cross.Add(new Vector2Int(-2, -2));
        usedCells_central_Cross.Add(new Vector2Int(-1, -1));
        usedCells_central_Cross.Add(new Vector2Int(-1, -2));
        usedCells_central_Cross.Add(new Vector2Int(0, -1));
        usedCells_central_Cross.Add(new Vector2Int(0, -2));
        usedCells_central_Cross.Add(new Vector2Int(1, -1));
        usedCells_central_Cross.Add(new Vector2Int(1, -2));
        usedCells_central_Cross.Add(new Vector2Int(2, -1));
        usedCells_central_Cross.Add(new Vector2Int(2, -2));
        usedCells_central_Cross.Add(new Vector2Int(3, -1));
        usedCells_central_Cross.Add(new Vector2Int(3, -2));
        usedCells_central_Cross.Add(new Vector2Int(4, -1));
        usedCells_central_Cross.Add(new Vector2Int(4, -2));
        usedCells_central_Cross.Add(new Vector2Int(5, -1));
        usedCells_central_Cross.Add(new Vector2Int(5, -2));
        usedCells_central_Cross.Add(new Vector2Int(6, -1));
        usedCells_central_Cross.Add(new Vector2Int(6, -2));
        usedCells_central_Cross.Add(new Vector2Int(7, -1));
        usedCells_central_Cross.Add(new Vector2Int(7, -2));
        usedCells_central_Cross.Add(new Vector2Int(8, -1));
        usedCells_central_Cross.Add(new Vector2Int(8, -2));

        usedCells_central_Cross.Add(new Vector2Int(-3, -3));
        usedCells_central_Cross.Add(new Vector2Int(-3, -4));
        usedCells_central_Cross.Add(new Vector2Int(-2, -3));
        usedCells_central_Cross.Add(new Vector2Int(-2, -4));
        usedCells_central_Cross.Add(new Vector2Int(-1, -3));
        usedCells_central_Cross.Add(new Vector2Int(-1, -4));
        usedCells_central_Cross.Add(new Vector2Int(0, -3));
        usedCells_central_Cross.Add(new Vector2Int(0, -4));
        usedCells_central_Cross.Add(new Vector2Int(1, -3));
        usedCells_central_Cross.Add(new Vector2Int(1, -4));
        usedCells_central_Cross.Add(new Vector2Int(2, -3));
        usedCells_central_Cross.Add(new Vector2Int(2, -4));
        usedCells_central_Cross.Add(new Vector2Int(3, -3));
        usedCells_central_Cross.Add(new Vector2Int(3, -4));
        #endregion
    }

    public List<Vector2Int> getDimensions()
    {
        switch (objId)
        {
            case 4:
                return usedCells_Big;
            case 5:
                return usedCells_central_Shooters;
            case 6:
                return usedCells_central_Life;
            case 7:
                return usedCells_central_Four;
            case 8:
                return usedCells_central_Cross;
            default:
                return usedCells;
        }
    }
}
