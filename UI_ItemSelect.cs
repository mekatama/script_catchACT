using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ItemSelect : MonoBehaviour {
	public string[] itemName;		//Itemの名前(配列)
	public Text[] itemNameText;		//Textコンポーネント取得用
	public int[] itemNum;			//Itemの価格
	public Text[] itemNumText;	//Textコンポーネント取得用
//	private float savePlayerSpeedItem;	//saveデータ一時保存用
	private int savePlayerSpeedItemNum;	//saveデータ一時保存用
	private int saveKagoScaleItemNum;	//saveデータ一時保存用
	private int savePointUpItemNum;		//saveデータ一時保存用

	void Start () {
		//saveがなかったら０を入れて初期化
//		savePlayerSpeedItem = PlayerPrefs.GetFloat("playerSpeedItem", 0); 	
		savePlayerSpeedItemNum = PlayerPrefs.GetInt("playerSpeedItemNum", 0); 	
		saveKagoScaleItemNum = PlayerPrefs.GetInt("kagoScaleItemNum", 0); 
		savePointUpItemNum = PlayerPrefs.GetInt("pointUpItemNum", 0); 
	}
	
	void Update () {
		savePlayerSpeedItemNum = PlayerPrefs.GetInt("playerSpeedItemNum", 0); 	
		saveKagoScaleItemNum = PlayerPrefs.GetInt("kagoScaleItemNum", 0); 
		savePointUpItemNum = PlayerPrefs.GetInt("pointUpItemNum", 0); 
		//アイテム名と個数の表示
		for(int i = 0; i < itemName.Length; i++) {
			itemNameText[i].text = itemName[i];
			itemNumText[0].text = savePlayerSpeedItemNum.ToString("000");
			itemNumText[1].text = saveKagoScaleItemNum.ToString("000");
			itemNumText[2].text = savePointUpItemNum.ToString("000");
//			itemNumText[i].text = itemNum[i].ToString("000");
		}
	}
}
