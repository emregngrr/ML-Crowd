using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float sideMoveSpeed = 5f;
    public float runningSpeed = 5f;
    public float jumpForce = 5f; 
    private Vector3 previousPosition;
    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded = true; 

    private Vector2 touchStartPosition; 
    private Vector2 touchEndPosition;   
    private bool swipeDetected = false;

    void Start()
    {
        previousPosition = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); 
        if (rb == null)
        {
            Debug.LogError("Rigidbody bileþeni eklenmedi! Lütfen eklediðinizden emin olun.");
        }

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        transform.position += Vector3.forward * runningSpeed * Time.deltaTime;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
                swipeDetected = false;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                Vector3 touchPosition = GetTouchWorldPosition();
                touchPosition.z = transform.position.z;

                Vector3 targetPosition = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, sideMoveSpeed * Time.deltaTime);

                if (transform.position.x > previousPosition.x)
                {
                    animator.SetBool("isMovingRight", true);
                    animator.SetBool("isMovingLeft", false);
                }
                else if (transform.position.x < previousPosition.x)
                {
                    animator.SetBool("isMovingRight", false);
                    animator.SetBool("isMovingLeft", true);
                }
                else
                {
                    animator.SetBool("isMovingRight", false);
                    animator.SetBool("isMovingLeft", false);
                }

                previousPosition = transform.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchEndPosition = touch.position;

                if (!swipeDetected && isGrounded && IsSwipeUp())
                {
                    Jump();
                    swipeDetected = true;
                }
            }
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; 
        animator.SetTrigger("Jump"); 
    }

    bool IsSwipeUp()
    {
        float swipeThreshold = 50f; 
        return (touchEndPosition.y - touchStartPosition.y) > swipeThreshold;
    }

    Vector3 GetTouchWorldPosition()
    {
        Vector3 touchPosScreen = Input.GetTouch(0).position;
        Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(new Vector3(touchPosScreen.x, touchPosScreen.y, Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
        return touchPosWorld;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (!gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}




    
