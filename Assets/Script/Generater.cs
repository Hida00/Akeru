using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Generater : MonoBehaviour
{
    //的となるミニドア
    public GameObject[] Mini;

    //ドアの親オブジェクト
    public GameObject Doors;

    //終了時に表示するテキスト
    public Text result;
    public Text Score;

    //経過時間と現在のスコアを表示する
    public Text Timer;
    public Text nowScore;

    //落ちたドア個数
    [NonSerialized]
    public int DoorFallCount = 0;

    //スコア
    [NonSerialized]
    public int score = 0;

    //落とすドアの個数
    private int MaxCount = 0;

    //ステージデータのファイル名の設定
    string path = "First";

    //開始時刻と終了時刻
    private float startTime;
    private float endTime;

    //ドアを倒した時間
    [NonSerialized]
    public float fallTime;

    void Start()
    {
        Time.timeScale = 2;
        ReadStageData();
        startTime = Time.time;
        fallTime = startTime;
    }

    void Update()
    {
        if(DoorFallCount >= MaxCount)
        {
            Destroy(Doors.gameObject);

            GameObject.Find("Tank").GetComponent<TankController>().GoTank();

            result.gameObject.SetActive(true); 
            result.text = "Clear";
            result.color = Color.yellow;
            result.gameObject.SetActive(true);

            Score.gameObject.SetActive(true);
            Score.text = score.ToString() + "点";

            Destroy(this.gameObject);
		}
        if((Time.time - startTime) >= endTime * 2)
        {
            Destroy(Doors.gameObject);

            GameObject.Find("Tank").GetComponent<TankController>().GoTank();

            result.gameObject.SetActive(true);
            result.text = "Finish";
            result.color = Color.blue;
            result.gameObject.SetActive(true);

            Score.gameObject.SetActive(true);
            Score.text = score.ToString() + "点";

            Destroy(this.gameObject);
        }
        float now = Time.time;
        Timer.text = ((int)(now - startTime) / 120 ).ToString() + ":" + ((int)((now - startTime) /2) % 60).ToString();
        nowScore.text = score.ToString();
    }

    void ReadStageData()
	{
        var csv = Resources.Load<TextAsset>("StageData/" + path);
        StringReader st = new StringReader(csv.text);

        string[] info = st.ReadLine().Split(',');
        MaxCount = int.Parse(info[0]);
        endTime = float.Parse(info[1]);

        while(st.Peek() > -1)
		{
            //一行ずつ読み込む
            string[] values = st.ReadLine().Split(',');
            //0:X座標,1:Y座標,2:Z座標,3:Speed,4:移動幅,5:スコア
            Vector3 pos = new Vector3(float.Parse(values[1]) , float.Parse(values[2]) , float.Parse(values[3]));
            int num = int.Parse(values[0]) - 1;
            var obj = Instantiate(Mini[num] , pos , Quaternion.identity , Doors.transform);
            obj.GetComponent<MiniDoor>().speed = float.Parse(values[4]);
            obj.GetComponent<MiniDoor>().Xpos  = float.Parse(values[1]);
            obj.GetComponent<MiniDoor>().width = float.Parse(values[5]);
            obj.GetComponent<MiniDoor>().transform.GetChild(0).GetComponent<DoorFall>().score = (num + 1) * 100;
		}
	}
}
