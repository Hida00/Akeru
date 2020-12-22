using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //時間経過計測用
    private float time;
    //地面についているかの真偽変数
    private bool onGround = false;

    void Start()
    {
        
    }

    void Update()
    {
        //砲弾のy座標が0.55以下になって3秒経過したら消滅
        if(!onGround && this.transform.position.y <= 0.55f)
        {
            //地面についた時間の設定
            time = Time.time;
            onGround = true;
        }
        if(onGround && (Time.time - time) >= 3f)
        {
            //消滅
            Destroy(this.gameObject);
        }
    }
}
