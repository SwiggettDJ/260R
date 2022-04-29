using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;

    [SerializeField] private float speed = 5f;

    private Vector3 moveDirection;
    private Vector3 lookDirection;
    private bool isTouching = false;
    private Vector2 touchStart;
    private Vector2 touchEnd;
    private Vector3 velocityTemp;

    public Image joystick;
    public Image joystickOutline;

    public float joystickRadius;


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);
            
            // Makes it so player can only use touchpad on left side of screen so it doesnt overlap with buttons
            if (firstTouch.phase == TouchPhase.Began & firstTouch.position.x < Screen.width * .7f)
            {

                    touchStart = firstTouch.position;
                    joystick.transform.position = touchStart;
                    joystickOutline.transform.position = touchStart;
                    joystick.enabled = true;
                    joystickOutline.enabled = true;
                    isTouching = true;
                    
                    //Debug.DrawLine(rb.position,touchStart, Color.red, 2);
            }
                

            if (firstTouch.phase == TouchPhase.Moved)
            {
                touchEnd = firstTouch.position;
            }

            if(firstTouch.phase == TouchPhase.Ended)
            {
                HideJoystick();
            }
            
        }
        
    }

    private void FixedUpdate()
    {
        if (isTouching)
        {
            Vector2 offset = touchEnd - touchStart;
            Vector2 clamped = Vector2.ClampMagnitude(offset, 1.0f);
            moveDirection = new Vector3(clamped.x, 0f, clamped.y);
            
            joystick.transform.position = new Vector2(touchStart.x + moveDirection.x * joystickRadius, touchStart.y + moveDirection.z * joystickRadius);
        }
        else
        {
            //Slow down gradually then stop
            if (rb.velocity.magnitude >= 0.2)
            {
                moveDirection = (moveDirection * .5f);
            }
            else
            {
                moveDirection = moveDirection * 0;
            }
            
        }
        MovePlayer();

        if (rb.velocity.magnitude >= 0.5f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void MovePlayer()
    {
        lookDirection = rb.position + moveDirection;
        velocityTemp = moveDirection * speed;
        velocityTemp.y = rb.velocity.y;
        rb.velocity = velocityTemp;
        transform.LookAt(lookDirection);
    }

    public void HideJoystick()
    {
        isTouching = false;
        joystick.enabled = false;
        joystickOutline.enabled = false;
    }

}
