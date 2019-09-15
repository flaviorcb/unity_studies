using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 300;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 2f;
    [SerializeField] float maxTimeBetweenShots = 10f;
    [SerializeField] Bullet bullet;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip deathAudioClip;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;
    [SerializeField] private AudioClip fireAudioClip;
    [SerializeField] private float fireSoundVolume = 0.7f;
    [SerializeField] private int deathPoints = 100;

    private GameSession gameSession;
    private UIManager uiManager;


    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        gameSession = FindObjectOfType<GameSession>();
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        uiManager.ChangeScore(gameSession.GetScore());

    }

    // Update is called once per frame
    void Update()
    {
        countDownAndShoot();

    }

    private void countDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {

        Bullet bulletAux = Instantiate(bullet, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(fireAudioClip, Camera.main.transform.position, fireSoundVolume);

        bulletAux.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ProcessDamage(other.gameObject.GetComponent<DamageDealer>().getDamage());
    }

    private void ProcessDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {

            GameObject explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);

            Destroy(explosion, durationOfExplosion);
            Destroy(gameObject);


            AudioSource.PlayClipAtPoint(deathAudioClip, Camera.main.transform.position, deathSoundVolume);

            gameSession.AddToScore(deathPoints);

            uiManager.ChangeScore(gameSession.GetScore());


        }
    }
}
