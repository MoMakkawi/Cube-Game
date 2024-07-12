using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public GameObject BulletPerfab;

    public int damage = 10;
    public float range = 100f;
    public static float BulletsNumbes;
    CountdownTimer countdownTimer;
    public AudioClip bulletSound;
    private AudioSource audioSource;
    public int playerBulletDamage = 10;
    private void Start()
    {
        BulletsNumbes = 70f;

        audioSource = GetComponent<AudioSource>();
        countdownTimer = FindObjectOfType<CountdownTimer>();

        audioSource.clip = bulletSound;
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot();
            Shoot1();
        }
    }

    private void Shoot1()
    {
        countdownTimer.ReduceBullet();
        RaycastHit hit;
        audioSource.Play();
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            var bullet = Instantiate(BulletPerfab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            Vector3 direction = BulletSpawnPoint.forward;
            bullet.GetComponent<Bullet>().SetBulletProb(damage, TargetType.Enemy, direction);
            bullet.GetComponent<Bullet>().ShootBullet();
        }

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
