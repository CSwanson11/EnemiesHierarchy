using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMine : MineBase
{
    // bottom
    public float fDetonationDamage;

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        if (bExplosionTrigger)
        {
            MineExplode();
        }
    }

    private void MineExplode()
    {
        if (bDealDmgToPlayer)
        {
            gPlayer.GetComponent<PlayerShields>().TakeDamage(fDetonationDamage);
        }

        Instantiate(gExplosionRed, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private new void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);

        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
