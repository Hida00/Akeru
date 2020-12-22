using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //ドアを開けるアニメーション用
    private Animator doorAnimator;

    //ドアが開いているかどうかの真偽変数
    private bool isOpen = true;

    void Start()
    {
        //ドアのアニメーター取得
        doorAnimator = this.GetComponent<Animator>();
    }

    void Update()
    {

    }
    public void DoorAnimation()
    {
        //ドアが開いていたら閉め、閉じていたら開ける
        isOpen = !isOpen;
        doorAnimator.SetBool("isOpen" , isOpen);
    }
}
