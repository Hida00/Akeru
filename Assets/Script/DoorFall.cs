using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorFall : MonoBehaviour
{
    //落とすと手に入るスコア
    [NonSerialized]
    public int score;

    void Start()
    {
        
    }

    void Update()
    {
        float distance = Vector3.Distance(this.transform.position , this.transform.parent.transform.position);
        if(distance >= 7.5f || (this.transform.eulerAngles.y >= 50f && this.transform.eulerAngles.y <= 90f))
		{
            var gene = GameObject.Find("Generater").GetComponent<Generater>();
            gene.DoorFallCount++;
            gene.score += score * (int)(Time.time - gene.fallTime) / 20;
            gene.fallTime = Time.time;
            Destroy(this.gameObject);
		}
    }
}
