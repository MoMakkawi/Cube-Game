using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public GameObject BulletPerfab;
    public float BulletSpeed = 40f;
    public static float BulletsNumbes;

    private void Start()
    {
        BulletsNumbes = 70f;
        CountdownTimer.BulletRemaining = BulletsNumbes;
    }

    // Update is called once per frame
    void Update()
    {
        if (BulletsNumbes < 0 
            && CountdownTimer.SocreNumber < Bullet.EnemyNumber)
            MainMenu.GameOver();

        if(Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(BulletPerfab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.forward * BulletSpeed;
            BulletsNumbes--;
            CountdownTimer.BulletRemaining = BulletsNumbes;
        }
    }
}
