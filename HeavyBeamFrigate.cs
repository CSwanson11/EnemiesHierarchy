using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBeamFrigate : HeavyMovement
{

    public GameObject gBeam;
    public GameObject gCannon;

    public float fFireDelay;
    public bool bCanShoot;
    public bool bIsFiring;


    private void Awake()
    {
        // finding shortcut variables in awake
        gCannon = gameObject.transform.Find("cannon0").gameObject;
    }

    new void Update()
    {
        base.Update();
        // canShoot being set to true in HeavyAlienFighter script
        if (bCanShoot && !bIsFiring)
        {
            StartCoroutine(Firing());
        }
    }

    public IEnumerator Firing()
    {
        // start the beam firing.  Beam obj scales up once instantiated
        bIsFiring = true;
        Instantiate(gBeam, gCannon.transform.position, gCannon.transform.rotation);
        // delay next firing until after the beam is gone
        yield return new WaitForSeconds(fFireDelay);
        bIsFiring = false;
    }

    new void OnBecameInvisible()
    {
        base.OnBecameInvisible();
        StopAllCoroutines();
    }

    new void OnBecameVisible()
    {
        base.OnBecameVisible();
    }

    private new void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
    }
}
