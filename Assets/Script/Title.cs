using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(change) , 1.5f);
    }
    public void change()
	{
        SceneManager.LoadScene("Select");
	}
}
