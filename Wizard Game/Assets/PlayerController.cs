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
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Camera cam;

    private float horizontal;
    private float vertical;
    private Vector3 moveDirection;

    private Vector3 mousePos;
    
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            mousePos = raycastHit.point;
        }
        
        moveDirection = new Vector3(horizontal, 0f, vertical);

        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.LookAt(new Vector3(mousePos.x,transform.position.y,mousePos.z));
        
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }
}
