using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBase : EnemiesBase
{
    public bool bDetonating;
    public float fFlashSpeed;
    public bool bDealDmgToPlayer;
    public bool bExplosionTrigger;
    MineFieldDetection mfd;

    new void Start()
    {
        base.Start();
        bDetonating = false;
        mfd = gameObject.GetComponentInChildren<MineFieldDetection>();
    }

    void FixedUpdate()
    {
        if (bDetonating)
        {
            transform.Rotate(0, 0, 240 * Time.deltaTime); //rotates 50 degrees per second around z axis
        }
        
        if (mfd.bPlayerInside)
        {
            if (!bDetonating)
            {
                StartCoroutine(Detonation());
            }
        }
    }

    //Called when player is near mine
    IEnumerator Detonation()
    {
        bDetonating = true; 
        StartCoroutine(ColorSwap());//Begin flashing red

        yield return new WaitForSeconds(2f);//Wait for 2 seconds then detonate mine
        
        bExplosionTrigger = true;
        //if player is inside mine detection radius when it explodes, deal damage to player
        if (mfd.bPlayerInside)
        {
            bDealDmgToPlayer = true;            
        }
    }

    //Flash color red while mine is detonating to warn player
    IEnumerator ColorSwap()
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.color = Color.red;
        yield return new WaitForSeconds(fFlashSpeed);
        rend.color = Color.white;
        yield return new WaitForSeconds(fFlashSpeed);
        rend.color = Color.red;
        yield return new WaitForSeconds(fFlashSpeed);
        rend.color = Color.white;
        yield return new WaitForSeconds(fFlashSpeed);
        rend.color = Color.red;
        yield return new WaitForSeconds(fFlashSpeed);
        rend.color = Color.white;
        yield return new WaitForSeconds(fFlashSpeed);
        rend.color = Color.red;
        yield return new WaitForSeconds(fFlashSpeed);
        rend.color = Color.white;
    }
}
