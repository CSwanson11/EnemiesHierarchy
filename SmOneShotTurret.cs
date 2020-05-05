using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmOneShotTurret : TurretTracking
{
    public float fFireRate;

    new void OnBecameVisible()
    {
        base.OnBecameVisible();
        //When turret becomes visible, start firing, begin tracking player
        StartCoroutine(Fire());
    }

    new void OnBecameInvisible()
    {
        base.OnBecameInvisible();
        StopAllCoroutines();
    }
    
    IEnumerator Fire()
    {
        //Create new laser from object pool
        GameObject laser = ObjectPooler.opSharedInstance.GetGreenLasers();
        if (laser != null)
        {
            laser.transform.position = gCannonBase.transform.position;
            laser.transform.rotation = gCannonBase.transform.rotation;
            laser.SetActive(true);
        }
        //wait for time of firerate between shots
        yield return new WaitForSeconds(fFireRate);
        StartCoroutine(Fire());
    }
}
