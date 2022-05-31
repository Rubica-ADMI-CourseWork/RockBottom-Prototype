using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 MovementVector { private set; get; }
    [SerializeField] float moveSpeed = 10f;
    //reference to the MobileJoystick Component on the joystick Knob
    [SerializeField] private MobileJoystick joystick;

    private void Start()
    {
        joystick.OnMove += MoveCharacter;
    }
    private void Update()
    {
        transform.Translate(new Vector3(MovementVector.x * moveSpeed * Time.deltaTime,
            MovementVector.y * moveSpeed * Time.deltaTime,transform.position.z));
    }
    public void MoveCharacter(Vector2 moveVector)
    {
        MovementVector = moveVector;
        
    }

}
