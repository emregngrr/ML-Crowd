using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleThree : MonoBehaviour
{

    public Transform handle;           
    public Transform punch;            
    public float punchDistance = 2f;   
    public float punchSpeed = 5f;      
    public float punchDelay = 3f;      
    public float handleScaleFactor = 1.5f; 

    private Vector3 initialPunchPosition;
    private Vector3 initialHandleScale;
    private Vector3 targetHandleScale;

    private bool isPunching = false; 

    void Start()
    {
        if (handle != null && punch != null)
        {
            initialPunchPosition = punch.localPosition;  
            initialHandleScale = handle.localScale;      
            targetHandleScale = new Vector3(initialHandleScale.x * handleScaleFactor, initialHandleScale.y, initialHandleScale.z);
            StartCoroutine(PunchRoutine());
        }
        else
        {
            Debug.LogError("Referanslar eksik!");
        }
    }

    IEnumerator PunchRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(punchDelay);

            Vector3 targetPunchPosition = initialPunchPosition + Vector3.right * punchDistance;
            float t = 0f;  

            while (Vector3.Distance(punch.localPosition, targetPunchPosition) > 0.01f)
            {
                punch.localPosition = Vector3.MoveTowards(punch.localPosition, targetPunchPosition, punchSpeed * Time.deltaTime);
                t += Time.deltaTime * punchSpeed;
                handle.localScale = Vector3.Lerp(initialHandleScale, targetHandleScale, t); 
                yield return null;
            }

            yield return new WaitForSeconds(0.2f);

            t = 0f;  
            while (Vector3.Distance(punch.localPosition, initialPunchPosition) > 0.01f)
            {
                punch.localPosition = Vector3.MoveTowards(punch.localPosition, initialPunchPosition, punchSpeed * Time.deltaTime);
                t += Time.deltaTime * punchSpeed;
                handle.localScale = Vector3.Lerp(targetHandleScale, initialHandleScale, t); 
                yield return null;
            }
        }
    }
}
