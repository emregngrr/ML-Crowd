using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float sideMoveSpeed = 5f;
    public float runningSpeed = 5f;
    private Vector3 previousPosition; // Önceki pozisyonu saklamak için deðiþken
    private Animator animator; // Animator bileþeni

    void Start()
    {
        previousPosition = transform.position;
        animator = GetComponent<Animator>(); // Animator bileþenini al
    }

    void Update()
    {
        transform.position += Vector3.forward * runningSpeed * Time.deltaTime;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = GetTouchWorldPosition();
            touchPosition.z = transform.position.z;

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                Vector3 targetPosition = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, sideMoveSpeed * Time.deltaTime);

                // Hareket yönünü kontrol et
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

                // Þimdiki pozisyonu önceki pozisyon olarak kaydediyoruz
                previousPosition = transform.position;
            }
        }
    }

    Vector3 GetTouchWorldPosition()
    {
        Vector3 touchPosScreen = Input.GetTouch(0).position;
        Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(new Vector3(touchPosScreen.x, touchPosScreen.y, Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
        return touchPosWorld;
    }
}
