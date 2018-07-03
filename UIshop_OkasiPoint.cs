using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIshop_OkasiPoint : MonoBehaviour {
	public Text okasiPointText;			//Textコンポーネント取得用
	
	void Update () {
		//ショップ用okasipoint表示
		okasiPointText.text = PlayerPrefs.GetInt("totalOkasi").ToString("000000");
	}
}
