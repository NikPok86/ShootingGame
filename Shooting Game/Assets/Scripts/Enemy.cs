using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public Transform gun;
    public GameObject bullet;
    public Transform shotPoint;

    public Transform destroyExplosion;

    float timeBtwShots;
    public float startTimeBtwShots;

    public int enemyHealth;
    public float enemySpeed;
    public float stoppingDistance;
    public float retreatDistance;

    public int isPlayerAlive;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gun = transform.GetChild(0);
        shotPoint = gun.transform.GetChild(0);
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        isPlayerAlive = GameObject.FindGameObjectsWithTag("Player").Length;
        if (isPlayerAlive > 0)
        {
            GunScript();

            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                enemySpeed = 1;
                transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
            }

            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }

          /*  else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                enemySpeed = 4f;
                transform.position = Vector2.MoveTowards(transform.position, player.position, -enemySpeed * Time.deltaTime);
            }*/
                
            if (enemyHealth <= 0)
            {
                Transform newDestroyExplosion = Instantiate (destroyExplosion, transform.position, Quaternion.identity);
                Destroy(newDestroyExplosion.gameObject, 1f);
                Destroy(gameObject);
            }
        }
    }

    public void GunScript()
    {
        if (isPlayerAlive > 0)
        {
            Vector3 difference = player.transform.position - transform.position;
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
                Instantiate(bullet, shotPoint.position, gun.transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }

            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
    }
  
}
