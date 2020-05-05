using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBase : MonoBehaviour
{
    //variables
    #region base variables
    public float fOffScreenTimer;
    public bool bOffScreenTrigger;
    public float fHealth;
    public float fCollisionDmgToPlayer;
    public GameObject gExplosionRed;
    public GameObject gExplosionYellow;
    public GameObject gCurrencyDrop;
    public GameObject gPlayer;
    #endregion

    // Start is called before the first frame update
    public void Start()
    {
        fOffScreenTimer = 10f;
        bOffScreenTrigger = false;
        gPlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    public void Update()
    {
        //If enemy has went offscreen, begin timer countdown
        if (bOffScreenTrigger)
        {
            OffScreenTimerCountdown();
        }

        if (fHealth <= 0)
        {
            EnemyDeath();
        }
    }

    private void OffScreenTimerCountdown()
    {
        fOffScreenTimer -= Time.deltaTime;
        
        if (fOffScreenTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void EnemyDeath()
    {
        //Create explosion and destroy enemy
        Instantiate(gExplosionYellow, transform.position, transform.rotation);
        float rand = Random.Range(0, 100);
        if (rand < 60f)
        {
            Instantiate(gCurrencyDrop, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        //If enemy is hit by players laser, subtract health from enemy, create explosion and return laser to pool
        if (col.gameObject.tag == "playerlaser")
        {
            CollisionWithPlayerLaser(col);
        }

        // If collision with enemy, take damage, create explosion, and destroy the enemy
        else if (col.gameObject.tag == "Player")
        {
            CollisionWithPlayer(col);
        }
    }
    
    private void CollisionWithPlayerLaser(Collider2D col)
    {
        fHealth -= col.gameObject.GetComponent<PlayerLaserScript>().fModifiedDamage;
        Instantiate(gExplosionRed, col.transform.position, col.transform.rotation);
        col.gameObject.SetActive(false);
    }

    private void CollisionWithPlayer(Collider2D col)
    {
        col.GetComponent<PlayerShields>().TakeDamage(fCollisionDmgToPlayer);
        Instantiate(gExplosionRed, transform.position, transform.rotation);
    }

    public void OnBecameVisible()
    {
        //When enemy appears onscreen reset death variables
        bOffScreenTrigger = false;
        fOffScreenTimer = 10f;
    }

    public void OnBecameInvisible()
    {
        bOffScreenTrigger = true;
    }
}
