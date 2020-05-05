using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBurst : HeavyMovement
{
    // Getting child objects for cannon placement
    public GameObject gCannon0;
    public GameObject gCannon1;
    public GameObject gCannon2;

    private new void Start()
    {
        base.Start();
        gCannon0 = transform.Find("cannon0").gameObject;
        gCannon1 = transform.Find("cannon1").gameObject;
        gCannon2 = transform.Find("cannon2").gameObject;
    }

    IEnumerator FireBurst()
    {
        //Create new instance of laser from available in object pool
        GameObject laser0 = ObjectPooler.opSharedInstance.GetGreenLasers();
        //if laser available, set start position to gCannon0 position/rotation
        if (laser0 != null)
        {
            laser0.transform.position = gCannon0.transform.position;
            laser0.transform.rotation = gCannon0.transform.rotation;
            laser0.SetActive(true);
        }

        //Create new instance of laser from available in object pool
        GameObject laser1 = ObjectPooler.opSharedInstance.GetGreenLasers();
        //if laser available, set start position to gCannon1 position/rotation
        if (laser1 != null)
        {
            laser1.transform.position = gCannon1.transform.position;
            laser1.transform.rotation = gCannon1.transform.rotation;
            laser1.SetActive(true);
        }

        //Create new instance of laser from available in object pool
        GameObject laser2 = ObjectPooler.opSharedInstance.GetGreenLasers();
        //if laser available, set start position to gCannon2 position/rotation
        if (laser2 != null)
        {
            laser2.transform.position = gCannon2.transform.position;
            laser2.transform.rotation = gCannon2.transform.rotation;
            laser2.SetActive(true);
        }
        //wait 2 seconds in between shots
        yield return new WaitForSeconds(2f);
        StartCoroutine(FireBurst());
    }

    private new void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);

        if (col.name == "Stop")
        {
            bCanMove = true;
        }
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }


    new void OnBecameVisible()
    {
        base.OnBecameVisible();
        //When enemy appears onscreen
        StartCoroutine(FireBurst());
    }

    new void OnBecameInvisible()
    {
        base.OnBecameInvisible();
        StopAllCoroutines();
    }
}
