using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour
{
    float mouseX, mouseY;
    float STX, STY;
    [SerializeField] int speed;
    // Start is called before the first frame update
    void Start()
    {
        STX = transform.position.x;
        STY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;

        this.GetComponent<RectTransform>().position = new Vector2(
            (mouseX / Screen.width)*speed + STX,
            (mouseY / Screen.height)*speed + STY
            );
    }
}
