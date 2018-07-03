using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIshop_Item : MonoBehaviour {
//	public GameObject shopController;	//ShopController取得
	public int tempSave;			//
	public int itemPoint1 = 0;		//Itemの価格
	public int itemPoint2 = 0;		//Itemの価格
	public int itemPoint3 = 0;		//Itemの価格
	public int itemPoint4 = 0;		//Itemの価格
	public int itemPoint5 = 0;		//Itemの価格
	public int itemPoint6 = 0;		//Itemの価格

	void Start () {
	}

	//shop item用のbutton制御関数
	public void ButtonClicked_Item1(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint1;
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 1 buy : " + itemPoint1);
	}
	//shop item用のbutton制御関数
	public void ButtonClicked_Item2(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint2;
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 2 buy : " + itemPoint2);
	}
	//shop item用のbutton制御関数
	public void ButtonClicked_Item3(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint3;
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 3 buy : " + itemPoint3);
	}
	//shop item用のbutton制御関数
	public void ButtonClicked_Item4(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint4;
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 4 buy : " + itemPoint4);
	}
	//shop item用のbutton制御関数
	public void ButtonClicked_Item5(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint5;
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 5 buy : " + itemPoint5);
	}
	//shop item用のbutton制御関数
	public void ButtonClicked_Item6(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		tempSave = tempSave - itemPoint6;
		PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
		Debug.Log("item 6 buy : " + itemPoint6);
	}
}
