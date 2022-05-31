using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] float playerOffsetInX = 3f;
    [SerializeField] float moveSpeed = 10f;

    [SerializeField]float currentMovementValue;
    Vector2 currentFingerPosition;

    [SerializeField] bool moveUp;
    [SerializeField] bool moveDown;
    [SerializeField] bool moveRight;
    [SerializeField] bool moveLeft;

    private void Update()
    {

        //we want to drag our finger and move the player
        // GetFingerInput();


        if (moveUp)
        {
            currentMovementValue =  1 * moveSpeed;
            transform.Translate(Vector2.up * currentMovementValue * Time.deltaTime);
            Debug.Log(currentMovementValue);
        }
        if (moveDown)
        {
            Debug.Log(currentMovementValue);
        }
        if (moveRight)
        {
            Debug.Log(currentMovementValue);
        }
        if (moveLeft)
        {
            Debug.Log(currentMovementValue);
        }
        

        //playerMovement.Move(new Vector2(currentFingerPosition.x + playerOffsetInX,
        //   currentFingerPosition.y));

    }

    #region Button Input

    public void ReleaseButtons()
    {
        moveDown = false;
        moveUp = false;
        moveRight = false;
        moveLeft = false;
    }
    public void GetUpButtonInput()
    {
        moveUp = true;
        
    }
    public void GetDownButtonInput()
    {
        moveDown = true;

    }
    public void GetForwardButtonInput()
    {

    }
    public void GetBackButtonInput()
    {

    }

    #endregion

    private void GetFingerInput()
    {
        if (Input.GetMouseButton(0)) //continous detection
        {
            //know position of finger every frame - variable
            //turn pixel coordinates into world coordinates
            currentFingerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
