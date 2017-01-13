using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    float health = 4.0f;

    public static int enemiesAlive=0;

    [SerializeField]
    GameObject deathEffect;

    void Start()
    {
        enemiesAlive++;
    }

    void OnCollisionEnter2D(Collision2D collInfo)
    {
        if (collInfo.relativeVelocity.magnitude > health) {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        enemiesAlive--;
        if (enemiesAlive <= 0) {
            Debug.Log("Level Won");
        }
        Destroy(gameObject);
    }
}
