using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public CharacterController2D controller;
    public Rigidbody2D rb;
    public GameManager gm;

    public Enemy enemy;

    public Score st;
    public int enemyCount;
    public int enemyKill;

    public GameObject gameOverMenu;

    public Transform gun;
    public GameObject bullet;
    public Transform shotPoint;

    float timeBtwShots;
    public float startTimeBtwShots;

    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;  

    float horizontalMovement;
    public float movementSpeed;

    bool jump = false;
    public int extraJumpsValue;
    int extraJumps;
    public float jumpForce;

    public int maxPlayerHealth;
    public int currentPlayerHealth;
    public HealthBar healthBar;

    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        gun = transform.GetChild(0);
        shotPoint = gun.transform.GetChild(0);

        extraJumps = extraJumpsValue;

        currentPlayerHealth = maxPlayerHealth;
        healthBar.SetMaxHealth(maxPlayerHealth);
    }

    void Update()
    {
        GunScript();

        horizontalMovement = Input.GetAxisRaw("Horizontal") * movementSpeed;

        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            jump = true;
            extraJumps--; 
        }

        enemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;

        if (enemyCount < enemyKill)
        {
            st.UpdateScore(100);
        }
        
        enemyKill = enemyCount;

        if (currentPlayerHealth <= 0)
        {
            gm.GameWaveUpdate();
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            Destroy(gameObject);
        }        
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);

        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, false);
        if (jump)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            rb.velocity = Vector2.zero;
        }
        jump = false;
    }

    public void TakeDamage(int damage)
    {
        currentPlayerHealth -= damage;
        healthBar.SetHealth(currentPlayerHealth); 
    }

    public void GunScript()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (rotZ < 89 && rotZ > -89)
        {
            gun.transform.position = new Vector2(transform.position.x + 0.25f, transform.position.y);
        }

        else
        {
            gun.transform.position = new Vector2(transform.position.x - 0.25f, transform.position.y);
        }

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bullet, shotPoint.position, gun.transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

}
