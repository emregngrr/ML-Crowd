using System.Collections;
using UnityEngine;

public class ObstacleThree : MonoBehaviour
{
    public Transform handle;           // Handle nesnesi referans�
    public Transform punch;            // Punch nesnesi referans�
    public float punchDistance = 2f;   // Punch objesinin ileri geri hareket mesafesi
    public float punchSpeed = 5f;      // Punch objesinin hareket h�z�
    public float punchDelay = 3f;      // Yumruk hareketleri aras�ndaki gecikme s�resi (saniye)
    public float handleScaleFactor = 1.5f; // Handle nesnesinin uzama oran�

    private Vector3 initialPunchPosition;
    private Vector3 initialHandleScale;
    private Vector3 targetHandleScale;

    private bool isPunching = false; // Punch i�lemi durumu

    void Start()
    {
        if (handle != null && punch != null)
        {
            initialPunchPosition = punch.localPosition;  // Punch ba�lang�� pozisyonunu kaydet
            initialHandleScale = handle.localScale;      // Handle ba�lang�� �l�e�ini kaydet
            targetHandleScale = new Vector3(initialHandleScale.x * handleScaleFactor, initialHandleScale.y, initialHandleScale.z);
            StartCoroutine(PunchRoutine());
        }
        else
        {
            Debug.LogError("Handle veya Punch referans� eksik!");
        }
    }

    IEnumerator PunchRoutine()
    {
        while (true)
        {
            // Gecikme s�resi kadar bekle
            yield return new WaitForSeconds(punchDelay);

            // Punch ileri hareketi ve handle uzama
            Vector3 targetPunchPosition = initialPunchPosition + Vector3.right * punchDistance;
            float t = 0f;  // Zaman de�i�keni

            // Handle'�n X ekseninde uzamas�
            while (Vector3.Distance(punch.localPosition, targetPunchPosition) > 0.01f)
            {
                punch.localPosition = Vector3.MoveTowards(punch.localPosition, targetPunchPosition, punchSpeed * Time.deltaTime);
                t += Time.deltaTime * punchSpeed;
                handle.localScale = Vector3.Lerp(initialHandleScale, targetHandleScale, t); // Handle'�n boyutu artar
                yield return null;
            }

            // Bir s�re bekle (yumruk ileri pozisyonda kals�n)
            yield return new WaitForSeconds(0.2f);

            // Punch geri hareketi ve handle eski �l�e�e d�nme
            t = 0f;  // Zaman de�i�kenini s�f�rla
            while (Vector3.Distance(punch.localPosition, initialPunchPosition) > 0.01f)
            {
                punch.localPosition = Vector3.MoveTowards(punch.localPosition, initialPunchPosition, punchSpeed * Time.deltaTime);
                t += Time.deltaTime * punchSpeed;
                handle.localScale = Vector3.Lerp(targetHandleScale, initialHandleScale, t); // Handle eski haline geri d�ner
                yield return null;
            }
        }
    }
}
