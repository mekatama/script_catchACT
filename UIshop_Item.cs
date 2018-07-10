using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIshop_Item : MonoBehaviour {
	public int tempSave;			//
	public string[] itemName;		//Itemの名前(配列)
	public Text[] itemNameText;		//Textコンポーネント取得用
	public int[] itemPoint;			//Itemの価格
	public Text[] itemPointText;	//Textコンポーネント取得用
	private float savePlayerSpeedItem;	//saveデータ一時保存用
	private int saveKagoScaleItemNum;	//saveデータ一時保存用
	public float itemSpeed;			//アイテムのspeedUp値

	void Start () {
		//saveがなかったら０を入れて初期化
		savePlayerSpeedItem = PlayerPrefs.GetFloat("playerSpeedItem", 0); 	
		saveKagoScaleItemNum = PlayerPrefs.GetInt("kagoScaleItemNum", 0); 
	}

	void Update () {
		//値段表示
		for(int i = 0; i < itemName.Length; i++) {
			itemNameText[i].text = itemName[i];
			itemPointText[i].text = itemPoint[i].ToString("000");
		}
	}

	//speedUp item用のbutton制御関数
	public void ButtonClicked_Item1(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint[0];
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 1 buy : " + itemPoint[0]);
		//強化内容
		savePlayerSpeedItem = savePlayerSpeedItem + itemSpeed;			//加算
		PlayerPrefs.SetFloat("playerSpeedItem", savePlayerSpeedItem);	//save
		Debug.Log("speed item : " + PlayerPrefs.GetFloat("playerSpeedItem"));
	}
	//籠大きくする item用のbutton制御関数
	public void ButtonClicked_Item2(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint[1];
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 2 buy : " + itemPoint[1]);
		//強化内容
		saveKagoScaleItemNum = saveKagoScaleItemNum + 1;				//加算
		PlayerPrefs.SetInt("kagoScaleItemNum", saveKagoScaleItemNum);	//save
		Debug.Log("scale item : " + PlayerPrefs.GetInt("kagoScaleItemNum"));
	}
	//shop item用のbutton制御関数
	public void ButtonClicked_Item3(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint[2];
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 3 buy : " + itemPoint[2]);
	}
	//shop item用のbutton制御関数
	public void ButtonClicked_Item4(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint[3];
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 4 buy : " + itemPoint[3]);
	}
	//shop item用のbutton制御関数
	public void ButtonClicked_Item5(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint[4];
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 5 buy : " + itemPoint[4]);
	}
	//shop item用のbutton制御関数
	public void ButtonClicked_Item6(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint[5];
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 6 buy : " + itemPoint[5]);
	}
}
