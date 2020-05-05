using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOneShot : LightMovement
{
    public GameObject gCannon0;//First cannon for laser firing

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        gCannon0 = transform.Find("Cannon0").gameObject;
    }

    private new void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);

        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Fire()
    {
        //Create new instance of laser from available in object pool
        GameObject laser = ObjectPooler.opSharedInstance.GetGreenLasers();
        //if laser available, set start position to cannon position/rotation
        if (laser != null)
        {
            laser.transform.position = gCannon0.transform.position;
            laser.transform.rotation = gCannon0.transform.rotation;
            laser.SetActive(true);
        }
        //wait 1 second in between shots
        yield return new WaitForSeconds(1f);
        StartCoroutine(Fire());
    }

    new void OnBecameVisible()
    {
        //When enemy appears onscreen        
        base.OnBecameVisible();
        StartCoroutine(Fire());
    }

    new void OnBecameInvisible()
    {
        base.OnBecameInvisible();
        StopAllCoroutines();
    }
}
