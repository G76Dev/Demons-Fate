using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [SerializeField] GameObject fadeIn;
    Color currentCol;
    void Start()
    {
        fadeIn.GetComponent<SpriteRenderer>().color = currentCol;
    }

    private void Update()
    {
        if(currentCol.a >= 0)
        currentCol = new Color(currentCol.r, currentCol.g, currentCol.b, currentCol.a - 1);
    }
}
