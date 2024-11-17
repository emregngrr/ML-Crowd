using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMTrigger : MonoBehaviour
{
    public GameObject pushingStage; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Clone") || collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);

            Animator[] animators = pushingStage.GetComponentsInChildren<Animator>();

            foreach (Animator animator in animators)
            {
                animator.applyRootMotion = true;
            }
        }
    }
}
