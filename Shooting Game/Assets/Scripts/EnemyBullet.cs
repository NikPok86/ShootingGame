using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform player;
    public float bulletSpeed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    void Start()
    {
        Invoke ("DestroyBullet", lifeTime);
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, player.position, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<Player>().TakeDamage(damage);
            }

            DestroyBullet();
        }

        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);        
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

