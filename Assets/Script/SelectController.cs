using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SelectController : MonoBehaviour
{
    //UI生成時の親オブジェクト
    public GameObject canvas;
    
    //ヒント
    public GameObject hint;

    //ステージ選択
    public Image mark;

    //生成場所を入れるファイルのパス
    private string path = @"Data/select";

    void Start()
    {
        ReadData();
    }

    void Update()
    {
        
    }

    void ReadData()
	{
        int i = 1;
        var csv = Resources.Load<TextAsset>(path);
        StringReader st = new StringReader(csv.text);

        while(st.Peek() > -1)
		{
            string[] values = st.ReadLine().Split(',');

            var obj = Instantiate(mark , canvas.transform);
            obj.rectTransform.anchoredPosition = new Vector2(float.Parse(values[0]) , float.Parse(values[1]));
            obj.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
            obj.GetComponent<Mark>().num = i;
            i++;
		}
    }
    //ヒントの表示・非表示
    public void ShowHint()
    {
        hint.SetActive(true);
    }
    public void HideHint()
    {
        hint.SetActive(false);
    }
}
