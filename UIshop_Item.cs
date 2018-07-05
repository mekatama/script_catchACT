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

	void Start () {
	}

	void Update () {
		//値段表示
		for(int i = 0; i < itemName.Length; i++) {
			itemNameText[i].text = itemName[i];
			itemPointText[i].text = itemPoint[i].ToString("000");
		}
	}

	//shop item用のbutton制御関数
	public void ButtonClicked_Item1(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint[0];
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 1 buy : " + itemPoint[0]);
	}
	//shop item用のbutton制御関数
	public void ButtonClicked_Item2(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint[1];
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 2 buy : " + itemPoint[1]);
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
