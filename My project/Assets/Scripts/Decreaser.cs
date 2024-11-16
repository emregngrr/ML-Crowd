using UnityEngine;

public class Decreaser : MonoBehaviour
{
    public int characterCount = 1;
    public float minRandomValue = 2;
    public float maxRandomValue = 5;
    public CrowdController crowdController; 

    private int randomValue;

    private void Start()
    {
        
        randomValue = Random.Range((int)minRandomValue, (int)maxRandomValue + 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            
            if (characterCount > 0 && randomValue > 0)
            {
                other.gameObject.SetActive(false); 
                characterCount--; 
                randomValue--;   

            }
        }
    }
}