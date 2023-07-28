using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform BulletSpawnPoint;
    public GameObject BulletPerfab;
    public float BulletSpeed = 40f;
    public static float BulletsNumbes;

    public AudioClip bulletSound;

    private void Start()
    {
        BulletsNumbes = 70f;
        CountdownTimer.BulletRemaining = BulletsNumbes;

        // Get the AudioSource component attached to this GameObject
        AudioSource audioSource = GetComponent<AudioSource>();

        // Assign the bulletSound AudioClip to the AudioSource
        audioSource.clip = bulletSound;
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

            // If you are instantiating bullets programmatically, play the audio here
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            BulletsNumbes--;
            CountdownTimer.BulletRemaining = BulletsNumbes;
        }
    }
}
