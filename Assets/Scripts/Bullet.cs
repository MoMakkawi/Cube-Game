﻿using UnityEngine;
public enum TargetType
{
    Player,
    Enemy
}
public class Bullet : MonoBehaviour
{   
    public TargetType owner;
    private CountdownTimer countdownTimer;
    private int damage;
    private Vector3 _direction;
    [SerializeField] private float _bulletSpeedShoot;
    private Rigidbody _rigidbodyBullet;
    private void Awake()
    {
        countdownTimer = FindObjectOfType<CountdownTimer>();
        _rigidbodyBullet=GetComponent<Rigidbody>();
    }

    public void SetBulletProb(int damage, TargetType owner, Vector3 direction, float bulletSpeed = 80f)
    {
        _bulletSpeedShoot = bulletSpeed;
        this.damage = damage;
        this.owner = owner;
        _direction = direction;

        if (owner == TargetType.Player)
        {
            
            //meshRenderer.material.color = Color.white;
        }
        else
        {
           
            //meshRenderer.material.color = Color.black;

        }

    }
    public void ShootBullet()
    {
        _rigidbodyBullet.velocity = _direction * _bulletSpeedShoot;
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (owner == TargetType.Player && collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerhealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerhealth != null)
            {

                playerhealth.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        else if (owner == TargetType.Enemy && collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
