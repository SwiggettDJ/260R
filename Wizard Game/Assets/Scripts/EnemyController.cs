using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float sight;
    private Vector3 moveDirection;
    private Transform playerRef;
    private Rigidbody rb;
    public float damage;
    public float speed;
    private float ogSpeed;

    void Start()
    {
        sight = 50f;
        rb = GetComponent<Rigidbody>();
        ogSpeed = speed;

    }

    public void Detection()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, sight, LayerMask.GetMask("Player"));
        for (int i = 0; i < colliders.Length; i++)
        {
            playerRef = colliders[i].transform;
            moveDirection = playerRef.position - rb.position;
            //Debug.DrawLine(rb.position,moveDirection, Color.red, 2);
        }
    }
    private void MoveEnemy()
    {
        Vector3 velocityTemp = moveDirection.normalized * (speed * 10f) * Time.deltaTime;
        velocityTemp.y = rb.velocity.y;
        rb.velocity = velocityTemp;
        transform.LookAt(playerRef.position);
        
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void FixedUpdate()
    {
        Detection();
        MoveEnemy();
        speed = ogSpeed;
    }

    private void OnCollisionEnter(Collision other)
    {
        PlayerHealth playerHP = other.gameObject.GetComponent<PlayerHealth>();
        if(playerHP != null)
        {
            playerHP.Damage(damage);
        }
    }
}
