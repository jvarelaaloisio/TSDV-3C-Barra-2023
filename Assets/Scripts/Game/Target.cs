using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    enum MoveType
    {
        StaticMovement,
        VerticalMovement,
        HorizontalMovement,
        RandomMovement,
        AccelerationMovement
    }

    [Header("Targets configuration")] [SerializeField]
    private float speed = 5f;
   

    [SerializeField] private float moveDistance = 5f;
    [SerializeField] private float health = 50f;
    [SerializeField] private MoveType moveType;

    [Header("Acceleration options")] 
    
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float maxSpeed = 10f;
    private float distanceTraveled = 0;
    private float originalSpeed;
    private bool isMovingForward = true;

    private Vector3 originalPosition;
    private bool movingRight = true;
    private bool movingUp = true;

    private TargetsManager targetsManager;
    

    private void Start()
    {
        originalSpeed = speed;
        originalPosition = transform.position;
        targetsManager = FindObjectOfType<TargetsManager>();
    }
    private void Update()
    {
        Move();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        targetsManager.UpdateTargets();
        Destroy(gameObject);
    }

    void Move()
    {
        switch (moveType)
        {
            case MoveType.HorizontalMovement:
                HorizontalMovement();

                break;
            case MoveType.StaticMovement:
                break;
            case MoveType.VerticalMovement:
                VerticalMovement();
                break;
            case MoveType.RandomMovement:
                RandomMovement();
                break;
            case MoveType.AccelerationMovement:
                AccelerationMovement();
                break;
        }

        void HorizontalMovement()
        {
            // Calculate the new position
            float newPositionX = transform.position.x + (movingRight ? speed : -speed) * Time.deltaTime;

            // Check if the new position is within the range
            if (Mathf.Abs(newPositionX - originalPosition.x) > moveDistance)
            {
                // Change direction when reaching the range limit
                movingRight = !movingRight;
            }

            // Update the object's position
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        }

        void VerticalMovement()
        {
            // Calculate the new position
            float newPositionY = transform.position.y + (movingUp ? speed : -speed) * Time.deltaTime;

            // Check if the new position is within the range
            if (Mathf.Abs(newPositionY - originalPosition.y) > moveDistance)
            {
                // Change direction when reaching the range limit
                movingUp = !movingUp;
            }

            // Update the object's position
            transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
        }

        void RandomMovement()
        {
            // Calculate a random direction within the movement range
            Vector3 randomDirection = Random.insideUnitCircle.normalized * moveDistance;

            // Calculate the target position
            Vector3 targetPosition = originalPosition + randomDirection;

            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime * 5);
        }

        void AccelerationMovement()
        {
            // Calculate the movement direction
            Vector3 movementDirection = isMovingForward ? Vector3.forward : Vector3.back;

            // Move the target along the movement direction
            transform.Translate(movementDirection * (speed * Time.deltaTime));

            // Increment the distance traveled
            distanceTraveled += speed * Time.deltaTime;

            // Accelerate the speed
            speed += acceleration * Time.deltaTime;

            // Clamp the speed to the maximum value
            speed = Mathf.Clamp(speed, originalSpeed, maxSpeed);

            // Check if the distance limit is reached
            if (distanceTraveled >= moveDistance)
            {
                // Reverse the movement direction
                isMovingForward = !isMovingForward;

                // Reset the distance traveled and speed
                distanceTraveled = 0f;
            }
        }
    }
}