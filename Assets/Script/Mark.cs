using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Mark : MonoBehaviour
{
    //このマーカーの番号
    [NonSerialized]
    public int num;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ThisClick()
	{
        Generater.StagePath = num.ToString();
        SceneManager.LoadScene("DoorScene");
	}
}
