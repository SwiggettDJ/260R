using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody rb;

    [SerializeField] private float speed = 5f;

    private Vector3 moveDirection;
    private Vector3 lookDirection;
    private bool isTouching = false;
    private Vector2 touchStart;
    private Vector2 touchEnd;
    
    public Image joystick;
    public Image joystickOutline;

    public float joystickRadius;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
            joystick.transform.position = touchStart;
            joystickOutline.transform.position = touchStart;
            joystick.enabled = true;
            joystickOutline.enabled = true;
        }

        if (Input.GetMouseButton(0))
        {
            isTouching = true;
            touchEnd = Input.mousePosition;
        }
        else
        {
            isTouching = false;
            joystick.enabled = false;
            joystickOutline.enabled = false;
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
            lookDirection = rb.position + moveDirection;
            
            MovePlayer();
        }

        
    }

    private void MovePlayer()
    {
        rb.velocity = moveDirection * speed;
        transform.LookAt(lookDirection);
    }
}
