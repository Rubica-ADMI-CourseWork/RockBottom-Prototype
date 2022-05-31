using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveAmount;
    public void Move(Vector2 movePosition)
    {
        transform.position = movePosition;
    }

}
