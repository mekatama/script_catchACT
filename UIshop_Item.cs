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
	public int[] itemNum;			//Itemの所持個数
	public Text[] itemNumText;		//Textコンポーネント取得用
	private float savePlayerSpeedItem;	//saveデータ一時保存用
	private int savePlayerSpeedItemNum;	//saveデータ一時保存用
	private int saveKagoScaleItemNum;	//saveデータ一時保存用
	private int savePointUpItemNum;		//saveデータ一時保存用
	private int saveTimeExtendItemNum;	//saveデータ一時保存用
	private int saveNoOjyamaItemNum;	//saveデータ一時保存用
	public float itemSpeed;				//アイテムのspeedUp値

	public Canvas noPointCamvas;		//UI noPoint
	public float timeOut;				//NoPointを消したい時間間隔
	private float timeElapsed;			//時間を仮に格納する変数
	private bool isNoPoint;				//UI flag

	void Start () {
		//saveがなかったら０を入れて初期化
		savePlayerSpeedItem = PlayerPrefs.GetFloat("playerSpeedItem", 0); 	
		savePlayerSpeedItemNum = PlayerPrefs.GetInt("playerSpeedItemNum", 0); 
		saveKagoScaleItemNum = PlayerPrefs.GetInt("kagoScaleItemNum", 0); 
		savePointUpItemNum = PlayerPrefs.GetInt("pointUpItemNum", 0); 
		saveTimeExtendItemNum = PlayerPrefs.GetInt("timeExtendItemNum", 0); 
		saveNoOjyamaItemNum = PlayerPrefs.GetInt("noOjyamaItemNum", 0); 
		isNoPoint = false;
		noPointCamvas.enabled = false;	//UI非表示
	}

	void Update () {
		//値段表示
		for(int i = 0; i < itemName.Length; i++) {
			itemNameText[i].text = itemName[i];
			itemPointText[i].text = itemPoint[i].ToString("000");
		}
		itemNumText[0].text = savePlayerSpeedItemNum.ToString("000");
		itemNumText[1].text = saveKagoScaleItemNum.ToString("000");
		itemNumText[2].text = savePointUpItemNum.ToString("000");
		itemNumText[3].text = saveTimeExtendItemNum.ToString("000");
		itemNumText[4].text = saveNoOjyamaItemNum.ToString("000");

		//NoPoint用時間チェック
		if(isNoPoint == true){
			timeElapsed += Time.deltaTime;		//経過時間の保存
			if(timeElapsed >= timeOut) {		//指定した経過時間に達したら
				isNoPoint = false;
				timeElapsed = 0;
				NoPoint();
			}
		}
	}

	//speedUp item用のbutton制御関数
	public void ButtonClicked_Item1(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		if(tempSave >= itemPoint[0]){
			tempSave = tempSave - itemPoint[0];
			PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
			//強化内容
			savePlayerSpeedItem = itemSpeed;									//set
			savePlayerSpeedItemNum = savePlayerSpeedItemNum + 1;				//加算
			PlayerPrefs.SetInt("playerSpeedItemNum", savePlayerSpeedItemNum);	//save
			PlayerPrefs.SetFloat("playerSpeedItem", savePlayerSpeedItem);		//save
			Debug.Log("speed item : " + PlayerPrefs.GetInt("playerSpeedItemNum"));
			Debug.Log("item 1 buy : " + itemPoint[0]);
		}else{
			isNoPoint = true;
			NoPoint();
		}
	}
	//籠大きくする item用のbutton制御関数
	public void ButtonClicked_Item2(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		if(tempSave >= itemPoint[1]){
			tempSave = tempSave - itemPoint[1];
			PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
			//強化内容
			saveKagoScaleItemNum = saveKagoScaleItemNum + 1;				//加算
			PlayerPrefs.SetInt("kagoScaleItemNum", saveKagoScaleItemNum);	//save
			Debug.Log("scale item : " + PlayerPrefs.GetInt("kagoScaleItemNum"));
			Debug.Log("item 2 buy : " + itemPoint[1]);
		}else{
			isNoPoint = true;
			NoPoint();
		}
	}
	//pointUp item用のbutton制御関数
	public void ButtonClicked_Item3(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		if(tempSave >= itemPoint[2]){
			tempSave = tempSave - itemPoint[2];
			PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
			//強化内容
			savePointUpItemNum = savePointUpItemNum + 1;				//加算
			PlayerPrefs.SetInt("pointUpItemNum", savePointUpItemNum);	//save
			Debug.Log("point item : " + PlayerPrefs.GetInt("pointUpItemNum"));
			Debug.Log("item 3 buy : " + itemPoint[2]);
		}else{
			isNoPoint = true;
			NoPoint();
		}
	}
	//時間延長 item用のbutton制御関数
	public void ButtonClicked_Item4(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		if(tempSave >= itemPoint[3]){
			tempSave = tempSave - itemPoint[3];
			PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
			//強化内容
			saveTimeExtendItemNum = saveTimeExtendItemNum + 1;				//加算
			PlayerPrefs.SetInt("timeExtendItemNum", saveTimeExtendItemNum);	//save
			Debug.Log("timeextend item : " + PlayerPrefs.GetInt("timeExtendItemNum"));
			Debug.Log("item 4 buy : " + itemPoint[3]);
		}else{
			isNoPoint = true;
			NoPoint();
		}
	}
	//NoOjyama item用のbutton制御関数
	public void ButtonClicked_Item5(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		if(tempSave >= itemPoint[4]){
			tempSave = tempSave - itemPoint[4];
			PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
			//強化内容
			saveNoOjyamaItemNum = saveNoOjyamaItemNum + 1;				//加算
			PlayerPrefs.SetInt("noOjyamaItemNum", saveNoOjyamaItemNum);	//save
			Debug.Log("NoOjyama item : " + PlayerPrefs.GetInt("noOjyamaItemNum"));
			Debug.Log("item 5 buy : " + itemPoint[4]);
		}else{
			isNoPoint = true;
			NoPoint();
		}
	}
	//shop item用のbutton制御関数
	public void ButtonClicked_Item6(){
		tempSave = PlayerPrefs.GetInt("totalOkasi");
		if(tempSave >= itemPoint[5]){
			tempSave = tempSave - itemPoint[5];
			PlayerPrefs.SetInt("totalOkasi", tempSave);	//save
			Debug.Log("item 6 buy : " + itemPoint[5]);
		}else{
			isNoPoint = true;
			NoPoint();
		}
	}

	void NoPoint(){
		if(isNoPoint){
			noPointCamvas.enabled = true;	//UI表示
		}else{
			noPointCamvas.enabled = false;	//UI非表示
		}
	}
}
