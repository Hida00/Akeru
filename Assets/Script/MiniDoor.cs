using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MiniDoor : MonoBehaviour
{
    //移動速度
    [NonSerialized]
    public float speed;

    //初期のX座標
    [NonSerialized]
    public float Xpos;

    //移動する幅
    [NonSerialized]
    public float width;

    void Start()
    {
    }

    void Update()
    {
		this.transform.position = new Vector3(Xpos + Mathf.Sin(Time.time * speed / 2) * width , this.transform.position.y , this.transform.position.z);
	}
}
