using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingStage : MonoBehaviour
{
    public CrowdController crowdController;
    public GameController gameController;
    private Rigidbody rb;
    private bool hasBeenAddedToArmy = false;
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
        if (!collision.gameObject.CompareTag("PushingStageObject"))
        {
            if (hasBeenAddedToArmy) return;


            SkinnedMeshRenderer otherRenderer = collision.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
            SkinnedMeshRenderer myRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

            if (myRenderer != null && otherRenderer != null)
            {
                Material myMaterial = myRenderer.material;
                Material otherMaterial = otherRenderer.material;

                string myHex = ColorUtility.ToHtmlStringRGB(myMaterial.color);
                string otherHex = ColorUtility.ToHtmlStringRGB(otherMaterial.color);

                if (myHex == otherHex)
                {
                    AddToArmy(this.gameObject, otherMaterial);
                }
                else
                {
                    if (collision.gameObject.CompareTag("Clone"))
                    {
                        this.gameObject.SetActive(false);
                        collision.gameObject.SetActive(false);
                        CrowdController.instance.totalClone--;
                    }
                    if (collision.gameObject.CompareTag("Player"))
                    {
                        this.gameObject.SetActive(false);

                        if (GameController.instance.lastClone)
                        {
                            collision.gameObject.SetActive(false);
                            CrowdController.instance.totalClone--;
                            GameController.instance.gameLost = true;
                        }
                    }
                }
            }
        }
    }

    private void AddToArmy(GameObject enemy,Material material)
    {
          enemy.tag = "Clone"; 
          enemy.AddComponent<Controller>();

          SkinnedMeshRenderer enemyRenderer = enemy.GetComponentInChildren<SkinnedMeshRenderer>();
          enemyRenderer.material.color = material.color; 

          CrowdController.Clones.Add(enemy);
          crowdController.AddClone();
          CrowdController.instance.totalClone++;
          Destroy(enemy.GetComponent<PushingStage>());
        
    }
}
