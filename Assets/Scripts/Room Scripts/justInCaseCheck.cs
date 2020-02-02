using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class justInCaseCheck : MonoBehaviour
{

    public void deleteCentral(Vector2Int pos)
    {
        if(pos.x == gameObject.transform.position.x && pos.y == gameObject.transform.position.y)
        Destroy(gameObject);
    }

}
