using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public GameObject BulletPerfab;

    public int damage = 10;
    public float range = 100f;
    public static float BulletsNumbers;
    CountdownTimer countdownTimer;
    public AudioClip bulletSound;
    private AudioSource audioSource;
    public int playerBulletDamage = 10;
    private PlayerHealth playerHealth;
    private void Start()
    {
        BulletsNumbers = 60f;

        audioSource = GetComponent<AudioSource>();
        countdownTimer = FindObjectOfType<CountdownTimer>();
        playerHealth = FindObjectOfType<PlayerHealth>();

        audioSource.clip = bulletSound;
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetMouseButtonDown(0) && playerHealth != null && !playerHealth.IsDead())
        {

            Shoot1();
        }

    }

    private void Shoot1()
    {
        countdownTimer.ReduceBullet();
        audioSource.Play();
        var bullet = Instantiate(BulletPerfab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        Vector3 direction = Camera.main.transform.forward;
        bullet.GetComponent<Bullet>().SetBulletProb(damage, TargetType.Enemy, direction);
        bullet.GetComponent<Bullet>().ShootBullet(direction);


    }

    private void Shoot()
    {
        var bullet = Instantiate(BulletPerfab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        //BulletSpawnPoint.forward = Camera.main.transform.forward;
        //bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.forward * BulletSpeed;

        // If you are instantiating bullets programmatically, play the audio here

        audioSource.Play();

        countdownTimer.ReduceBullet();
    }
}
