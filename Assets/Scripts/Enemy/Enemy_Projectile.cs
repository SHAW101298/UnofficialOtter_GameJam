using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour
{
    public float speed;
    public Vector3 flyDirection;
    public Rigidbody2D rb;
    public float damage;

    public float stopTimerAt;
    float deathTimer;

    void Start()
    {
        Vector2 dir = transform.position + flyDirection;
        Vector2 pos = transform.position;

        Vector2 offset = (dir - pos).normalized;
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle-90);
    }

    void Update()
    {
        deathTimer += Time.deltaTime;
        if (deathTimer >= stopTimerAt)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
