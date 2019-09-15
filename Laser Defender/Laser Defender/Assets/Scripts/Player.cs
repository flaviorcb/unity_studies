using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour

{

    float xMin, xMax, yMin, yMax;

    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 200;

    [Header("Projectile")]
    [SerializeField] Bullet bullet;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileFiringPeriod = 0.20f;
    [SerializeField] AudioClip deathAudioClip;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private float shootSoundVolume;
    [SerializeField] private Level level;
    

    UIManager uiManager;


    Coroutine firingCouroutine;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        setUpMoveBoundaries();
        uiManager.ChangeLife(health);
        
    }

    private void setUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        //Se tiver dúvida no código abaixo pode consultar a documentação ou  a aula 89 do curso (Jogo Space Invaders)
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();

    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCouroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            ////Para todas as corotinas que estão rodando em Player. É uma forma de parar de atirar continuamente, mas pode causar efeitos colaterais
            ////Pois não para só a rotina de tiros, mas também pode para outras.
            //StopAllCoroutines();

            //Esta é uma forma mais racional de parar a corrotina.
            StopCoroutine(firingCouroutine);

        }

    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            Bullet bulletAux = Instantiate(bullet, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            bulletAux.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }


    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = transform.position.x + deltaX;
        var newYPos = transform.position.y + deltaY;

        newXPos = Mathf.Clamp(newXPos, xMin, xMax);
        newYPos = Mathf.Clamp(newYPos, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            Debug.Log("Enemy Projectile destroyed before process damage on player");
            return;
        }
        processDamage(damageDealer);
    }

    private void processDamage(DamageDealer damageDealer)
    {
        health -= damageDealer.getDamage();

        uiManager.ChangeLife(health);

        damageDealer.Hit();

        if (health <= 0)
        {
            processDeath();
        }
    }

    private void processDeath()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathAudioClip, Camera.main.transform.position, deathSoundVolume);
        level.LoadGameOverScene();
    }

   
}
