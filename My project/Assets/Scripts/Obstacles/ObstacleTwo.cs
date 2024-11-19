using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTwo : MonoBehaviour
{
    public GameController gameController;
    public float rotationSpeed = 300f;
    public float moveSpeed = 10f;        
    public float moveDistance = 10f;    
    public float moveDelay = 2f;


    private bool canMove = false;
    private float timer = 0f;
    private Vector3 startPosition;

    void Start()
    {
        
        startPosition = transform.position;
    }
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);

        if (!canMove)
        {
            timer += Time.deltaTime;
            if (timer >= moveDelay)
            {
                canMove = true;
            }
        }

        if (canMove)
        {
            float offset = Mathf.PingPong((Time.time - moveDelay) * moveSpeed, moveDistance);
            transform.position = startPosition + Vector3.right * offset;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Clone"))
        {
            Debug.Log("Tag == Clone");
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Tag == Player");
            Debug.Log("LastCLone:" + GameController.instance.lastClone);

            if (GameController.instance.lastClone)
            {
                Debug.Log("Last Clone Has Been Eliminated");
                collision.gameObject.SetActive(false);
                GameController.instance.gameLost = true;
            }

        }

    }
}
