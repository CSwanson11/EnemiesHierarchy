using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : EnemiesBase
{
    public float fSpeed; // move speed currently set in inspector
    public bool bCanMove; // if movement of the fighter is allowed
    
    void FixedUpdate()
    {
        if (bCanMove)
        {
            // if fighter can move, move down the screen
            transform.Translate(Vector3.down * fSpeed * Time.deltaTime, Space.World);

            // getting the fighter to line up with the player
            float diff = transform.position.x - gPlayer.transform.position.x;

            // using small deadzones to stop jittery movement
            if (diff < -0.1)
            {
                transform.Translate(Vector3.left * Time.deltaTime);
            }
            else if (diff > 0.1)
            {
                transform.Translate(Vector3.right * Time.deltaTime);
            }
        }
    }

    // begins movement when visible on the screen
    new public void OnBecameVisible()
    {
        base.OnBecameVisible();
        bCanMove = true;
    }
}
