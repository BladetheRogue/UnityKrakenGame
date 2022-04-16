using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    public float speed = 5f;
    public float MaxPos = 1f;
    public float MinPos = -1f;

    private RectTransform spriteObject;

    void Start()
    {
        spriteObject = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 position = spriteObject.anchoredPosition;

        position.y += speed * Time.deltaTime;

        if (position.y > MaxPos)
        {
            position.y = MinPos;
        }
        spriteObject.anchoredPosition = position;
    }
}
