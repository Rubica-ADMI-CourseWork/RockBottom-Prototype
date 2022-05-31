using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoystick : MonoBehaviour, IPointerUpHandler,IDragHandler,IPointerDownHandler
{
    //the rect transform of the joystick knob
    private RectTransform joystickTransform;

    //threshold at which we pass values to the player, below this - we don't accept values
    [SerializeField] float dragThreshold = 0.6f;

    //distance the joystick moves around on the screen
    [SerializeField] int dragMovementDistance = 30;

    //limits movement range of the joystick
    [SerializeField] int dragOffsetDistance = 100;

    //event used to alert other scripts of input events
    public event Action<Vector2> OnMove;

    #region Unity Callbacks
    private void Awake()
    {
        joystickTransform = (RectTransform)transform;
    } 
    #endregion


    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickTransform,
            eventData.position,
            null,
            out offset);

        //clamp offset value to values between -1 and 1
        offset = Vector2.ClampMagnitude(offset,dragOffsetDistance)/dragOffsetDistance;
        //move the knob by the offset * dragOffsetDistance
        joystickTransform.anchoredPosition = offset * dragOffsetDistance;

        //get a movement vector from the offset to pass to the character
        Vector2 inputVector = CalculateMovementInput(offset);
        OnMove?.Invoke(inputVector);
    }

    private Vector2 CalculateMovementInput(Vector2 offset)
    {
        //is the knob moving in the x direction > dragThreshold? if so pass it's value if not pass zero
        float xValue = Mathf.Abs(offset.x) > dragThreshold ? offset.x : 0;

        //is the knob moving in the y direction > dragThreshold? if so pass it's value if not pass zero
        float yValue = Mathf.Abs(offset.y) > dragThreshold? offset.y: 0;

        return new Vector2(xValue, yValue);
    }

    //Called when user lifts finger off the joystick knob
    public void OnPointerUp(PointerEventData eventData)
    {
        //set the knob back to original position
        joystickTransform.anchoredPosition = Vector2.zero;

        //alert interested observers of this event
        OnMove?.Invoke(Vector2.zero);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }
}
