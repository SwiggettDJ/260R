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

    [SerializeField] private float speed = 25f;
    
    private Vector3 velocityTemp;

    public Joystick stick;
    

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(stick.Horizontal * (speed * 10) * Time.deltaTime, rb.velocity.y, stick.Vertical * (speed * 10) * Time.deltaTime);
        if (direction.normalized != Vector3.zero)
        {
            rb.velocity = direction;
            if (rb.velocity.magnitude >= 0.5f)
            {
                anim.SetBool("isRunning", true);
                anim.speed = new Vector2(stick.Horizontal,stick.Vertical).magnitude;
            }
            else
            {
                anim.speed = 1;
                anim.SetBool("isRunning", false);
            }
           
        }
        else
        {
            if (rb.velocity.magnitude >= 1)
            {
                velocityTemp = (rb.velocity * .9f);
                velocityTemp.y = rb.velocity.y;
                rb.velocity = velocityTemp;
            }
            anim.speed = 1;
            anim.SetBool("isRunning", false);
        }
        transform.LookAt(rb.position + new Vector3(direction.x, 0f, direction.z));
    }

}
