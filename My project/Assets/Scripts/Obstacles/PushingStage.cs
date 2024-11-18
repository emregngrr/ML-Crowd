using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingStage : MonoBehaviour
{
    public GameController gameController;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Colored Enemy Rigidbody bileþeni eklenmedi!");
        }

        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Clone"))
        {
            Debug.Log("Tag == Clone");
            this.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Tag == Player");
            this.gameObject.SetActive(false);
            Debug.Log("LastCLone:" + gameController.lastClone);
            
            if(GameController.instance.lastClone)
            {
                Debug.Log("Last Clone Has Been Eliminated");
                collision.gameObject.SetActive(false);
            }
            
        }
        
    }

}
