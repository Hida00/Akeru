using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimator;

    [SerializeField]
    private KeyCode key;

    private bool isOpen = true;

    void Start()
    {
        doorAnimator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            isOpen = !isOpen;
            doorAnimator.SetBool("isOpen" , isOpen);
        }
    }
}
