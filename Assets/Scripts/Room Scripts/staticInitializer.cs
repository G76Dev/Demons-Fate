using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class staticInitializer : MonoBehaviour
{
    void Start()
    {
        Size.initializeUsedCells();
    }
}
