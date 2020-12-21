using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float time;
    private bool onGround = false;

    void Start()
    {
        
    }

    void Update()
    {
        //砲弾のy座標が0.55以下になって3秒経過したら消滅
        if(!onGround && this.transform.position.y <= 0.55f)
        {
            time = Time.time;
            onGround = true;
        }
        if(onGround && (Time.time - time) >= 3f)
        {
            Destroy(this.gameObject);
        }
    }
}
