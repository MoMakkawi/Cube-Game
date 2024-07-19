using System.Collections;
using UnityEngine;

public class enemydie : MonoBehaviour
{
    public GameObject breakCube; // إشارة إلى الـ "BreakCube"
    public GameObject cube; // إشارة إلى الكائن الأصلي
    public float destroyDelay = 2f; // التأخير قبل التدمير
    public AudioSource audioSource; // مصدر الصوت لتشغيل المقطع الصوتي
    public AudioClip breakSound; // المقطع الصوتي الذي سيتم تشغيله
    // Start is called before the first frame update
    public void breakblock()
    {
        audioSource = GetComponent<AudioSource>();
        breakCube.transform.position = cube.transform.position;
        cube.SetActive(false);
        StartCoroutine(DestroyAfterDelay());
    }
    private IEnumerator DestroyAfterDelay()
    {
        audioSource.PlayOneShot(breakSound);
        breakCube.SetActive(true);

        yield return new WaitForSeconds(destroyDelay);

        // تدمير الكائن
        Destroy(gameObject);
    }
}
