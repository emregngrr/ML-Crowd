using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Multiplier : MonoBehaviour
{
    public int characterCount = 1; 
    public float minRandomValue = 2; 
    public float maxRandomValue = 3; 
    public CrowdController crowdController;

    private int randomValue;
    private bool isMultiply;
    private bool isPlus;
    private int counter;
    void Start()
    {
        randomValue = Random.Range((int)minRandomValue, (int)maxRandomValue + 1);
        isMultiply = Random.value > 0.5f;
        if (isMultiply)
        {
            Debug.Log("Çarpma iþlemi Seçildi");
        }
        else
        {
            Debug.Log("Toplama iþlemi Seçildi");
            isPlus = true;
        }
        Debug.Log("Random Sayi=" + randomValue);
    }
    private void OnTriggerEnter(Collider other)
    {
        counter = 0;
            if (isMultiply)
            {
                // Çarpma iþlemi
                while(counter < randomValue)
                {
                    crowdController.AddClone();
                    counter++;
                }
            }
            else if(isPlus)
            {
                // Toplama iþlemi
                while(counter < randomValue) 
                {
                    crowdController.AddClone();
                    counter++;
                }
                
                isPlus = false;
            }
        
    }
}
