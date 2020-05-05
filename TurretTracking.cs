using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTracking : EnemiesBase
{
    public GameObject gCannonBase;//1st cannon
    public bool bCanTrack; //controls whether turret can track player on screen or not

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        gCannonBase = transform.Find("Cannon").gameObject;//Bind cannon to cannon on turret
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        //If turret can track player, calculate player direction and angle and rotate cannon to face player
        if (bCanTrack)
        {
            TrackPlayer();
        }
    }

    private void TrackPlayer()
    {
        Vector3 vVectorToTarget = gPlayer.transform.position - gCannonBase.transform.position;
        float fAngle = Mathf.Atan2(vVectorToTarget.y, vVectorToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion qQ = Quaternion.AngleAxis(fAngle, Vector3.forward);
        gCannonBase.transform.rotation = Quaternion.Slerp(gCannonBase.transform.rotation, qQ, Time.deltaTime * 2f);
    }
    
    public new void OnBecameVisible()
    {
        base.OnBecameVisible();
        //When turret becomes visible, begin tracking player
        bCanTrack = true;
    }

    public new void OnBecameInvisible()
    {
        base.OnBecameInvisible();
        bCanTrack = false;
    }
}
