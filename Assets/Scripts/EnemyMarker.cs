using UnityEngine;
using UnityEngine.UI;

public class EnemyMarker : MonoBehaviour
{
    public GameObject marker; // إشارة إلى العلامة
    public float hideDistance = 5f; // المسافة لإخفاء العلامة
    public Color nearColor = Color.red; // اللون عند الاقتراب
    public Color farColor = Color.green; // اللون عند البعد

    private Transform player; // إشارة إلى اللاعب
    private Image markerImage; // صورة العلامة

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        markerImage = marker.GetComponent<Image>();
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            print(distance);
            // تغيير لون العلامة بناءً على المسافة
            if (distance > hideDistance)
            {
                markerImage.color = farColor;
                marker.SetActive(true); // إظهار العلامة عندما تكون المسافة أكبر من hideDistance
            }
            else
            {
                markerImage.color = nearColor;
                marker.SetActive(false); // إخفاء العلامة عندما تكون المسافة أقل من أو تساوي hideDistance
            }
        }
    }
}
