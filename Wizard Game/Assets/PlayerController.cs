using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody rb;

    [SerializeField] private float speed = 5f;
    [SerializeField] private Camera cam;

    private float horizontal;
    private float vertical;
    private Vector3 moveDirection;
    private bool isTouching = false;
    private Vector2 touchStart;
    private Vector2 touchEnd;

    private Vector3 mousePos;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            isTouching = true;
            touchEnd = Input.mousePosition;
        }
        else
        {
            isTouching = false;
        }
        
        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            mousePos = raycastHit.point;
        }
        
        //moveDirection = new Vector3(horizontal, 0f, vertical);

        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.LookAt(new Vector3(mousePos.x,transform.position.y,mousePos.z));
        
    }

    private void FixedUpdate()
    {
        if (isTouching)
        {
            Vector2 offset = touchEnd - touchStart;
            Vector2 clamped = Vector2.ClampMagnitude(offset, 1.0f);
            moveDirection = new Vector3(clamped.x, 0f, clamped.y);
            MovePlayer();
        }

        
    }

    private void MovePlayer()
    {
        rb.velocity = moveDirection * speed;
    }
}
