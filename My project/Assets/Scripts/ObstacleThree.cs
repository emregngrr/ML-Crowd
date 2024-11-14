using System.Collections;
using UnityEngine;

public class ObstacleThree : MonoBehaviour
{
    public Transform handle;           // Handle nesnesi referansý
    public Transform punch;            // Punch nesnesi referansý
    public float punchDistance = 2f;   // Punch objesinin ileri geri hareket mesafesi
    public float punchSpeed = 5f;      // Punch objesinin hareket hýzý
    public float punchDelay = 3f;      // Yumruk hareketleri arasýndaki gecikme süresi (saniye)
    public float handleScaleFactor = 1.5f; // Handle nesnesinin uzama oraný

    private Vector3 initialPunchPosition;
    private Vector3 initialHandleScale;
    private Vector3 targetHandleScale;

    private bool isPunching = false; // Punch iþlemi durumu

    void Start()
    {
        if (handle != null && punch != null)
        {
            initialPunchPosition = punch.localPosition;  // Punch baþlangýç pozisyonunu kaydet
            initialHandleScale = handle.localScale;      // Handle baþlangýç ölçeðini kaydet
            targetHandleScale = new Vector3(initialHandleScale.x * handleScaleFactor, initialHandleScale.y, initialHandleScale.z);
            StartCoroutine(PunchRoutine());
        }
        else
        {
            Debug.LogError("Handle veya Punch referansý eksik!");
        }
    }

    IEnumerator PunchRoutine()
    {
        while (true)
        {
            // Gecikme süresi kadar bekle
            yield return new WaitForSeconds(punchDelay);

            // Punch ileri hareketi ve handle uzama
            Vector3 targetPunchPosition = initialPunchPosition + Vector3.right * punchDistance;
            float t = 0f;  // Zaman deðiþkeni

            // Handle'ýn X ekseninde uzamasý
            while (Vector3.Distance(punch.localPosition, targetPunchPosition) > 0.01f)
            {
                punch.localPosition = Vector3.MoveTowards(punch.localPosition, targetPunchPosition, punchSpeed * Time.deltaTime);
                t += Time.deltaTime * punchSpeed;
                handle.localScale = Vector3.Lerp(initialHandleScale, targetHandleScale, t); // Handle'ýn boyutu artar
                yield return null;
            }

            // Bir süre bekle (yumruk ileri pozisyonda kalsýn)
            yield return new WaitForSeconds(0.2f);

            // Punch geri hareketi ve handle eski ölçeðe dönme
            t = 0f;  // Zaman deðiþkenini sýfýrla
            while (Vector3.Distance(punch.localPosition, initialPunchPosition) > 0.01f)
            {
                punch.localPosition = Vector3.MoveTowards(punch.localPosition, initialPunchPosition, punchSpeed * Time.deltaTime);
                t += Time.deltaTime * punchSpeed;
                handle.localScale = Vector3.Lerp(targetHandleScale, initialHandleScale, t); // Handle eski haline geri döner
                yield return null;
            }
        }
    }
}
