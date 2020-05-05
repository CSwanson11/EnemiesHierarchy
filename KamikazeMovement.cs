using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeMovement : EnemiesBase
{
    public float fSpeed;//Speed of movement
    public bool bCanMove;//Tracks whether ship can move or not

    // Using FixedUpdate() for physics actions
    void FixedUpdate()
    {
        if(bCanMove)
        {
            //Move ship forward by speed
            transform.Translate(Vector3.up * fSpeed * Time.deltaTime, Space.Self);

            //Calculate distance between ship and player
            Vector3 vVectorToTarget = gPlayer.transform.position - transform.position;

            //Calculate angle between ship and player
            float fAngle = Mathf.Atan2(vVectorToTarget.y, vVectorToTarget.x) * Mathf.Rad2Deg - 90;
            Quaternion qQ = Quaternion.AngleAxis(fAngle, Vector3.forward);

            //rotate ship slowly to face player and hone in
            transform.rotation = Quaternion.Slerp(transform.rotation, qQ, Time.deltaTime * 4f);
        }
    }

    public new void OnBecameVisible()
    {
        //When ship appears on scene, begin movement
        base.OnBecameVisible();
        bCanMove = true;
    }

    public new void OnBecameInvisible()
    {
        base.OnBecameInvisible();
    }
}
