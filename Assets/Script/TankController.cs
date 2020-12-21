using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    //砲身
    [NonSerialized]
    public GameObject Barrel;

    //砲弾、Prefabを入れる
    [SerializeField]
    private GameObject bullet;

    //砲弾の発射位置
    private Vector3 point;

    //砲弾の発射の感覚をあけるためのもの
    private float timeBullet;

    void Start()
    {
        //砲身を取得(実際はその土台)
        Barrel = GameObject.Find("Pivot");
        //砲弾の発射位置を取得
        point = Barrel.transform.GetChild(1).transform.position;

        //開始時刻で初期化
        timeBullet = Time.time;
    }

    void Update()
    {
        //上下の入力で砲身を上下させる

        float rotate = Input.GetAxis("Vertical");
        float y = Barrel.transform.localEulerAngles.y;
        if(y > 30f && y < 85f) //30°～85°の範囲で移動させる
        {
            Barrel.transform.Rotate(new Vector3(0 , rotate * 0.1f));
        }
        else if(y >= 85f && rotate <= 0f) //範囲外に行かないようにする
        {
            Barrel.transform.Rotate(new Vector3(0 , rotate * 0.1f));
        }
        else if(y <= 30f && rotate >= 0f) //上に同じ
        {
            Barrel.transform.Rotate(new Vector3(0 , rotate * 0.1f));
        }

        float timedif = Time.time - timeBullet;
        //Space入力で砲弾を発射
        if(Input.GetKeyDown(KeyCode.Space) && timedif >= 0.4f)
		{
            //ベースの1000に時間が空くほど速度が上がるようにする、(三項演算子…使うな！！！)
            float speed = 1000f * ( (timedif > 1.5f ? 1.5f : timedif) + 0.5f );
            //砲身の角度を弧度法で取得
            y = Barrel.transform.localEulerAngles.y * Mathf.Deg2Rad;
            //砲弾を生成、pointの位置に向きはそのまま
            var obj = Instantiate(bullet , point , Quaternion.identity);
            //AddForceで砲弾を飛ばす,
            obj.GetComponent<Rigidbody>().AddForce(0 , Mathf.Cos(y) * speed , Mathf.Sin(y) * -speed);
            //射撃終了時刻で時間をリセット
            timeBullet = Time.time;
		}
    }
}
