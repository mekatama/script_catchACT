using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int totalScore = 0;		//お菓子ポイントを管理
	public int totalCatch = 0;		//合計キャッチ数
	private int saveOkasiPoint;		//save用お菓子ポイント
	public float timeCount;			//制限時間
	public bool isTimeCount;
	public bool isClear;

	public Canvas itemSelectCamvas;	//UI itemSelect
	public Canvas inGameCamvas;		//UI inGame
	public Canvas clearCamvas;		//UI clear
	public Canvas item0Camvas;		//UI item0 speedup
	public Canvas item1Camvas;		//UI item1 speedup
	public Canvas item2Camvas;		//UI item1 speedup
	public Canvas item3Camvas;		//UI item1 speedup
	public Toggle toggleItem0;		//toggle
	public Toggle toggleItem1;		//toggle
	public Toggle toggleItem2;		//toggle
	public Toggle toggleItem3;		//toggle

	private float savePlayerSpeedItem;		//一時保存用
	private int savePlayerSpeedItemNum;		//一時保存用
	private int saveKagoScaleItemNum;		//一時保存用
	private int savePointUpItemNum;			//一時保存用
	private int saveTimeExtendItemNum;		//一時保存用
	public float playerSpeedItem;			//shopで購入
	public float playerKagoScale;			//shopで購入
	public int playerPointUp;				//shopで購入
	public float playerTimeExtend;			//shopで購入


	//ゲームステート
	enum State{
		ItemSelect,	//
		Play,		//inGame
		Clear,		//
		Result,		//
		AllClear	//
	}
	State state;

	void Start () {
		//saveがなかったら０を入れて初期化
		saveOkasiPoint = PlayerPrefs.GetInt("totalOkasi", 0); 
		savePlayerSpeedItemNum = PlayerPrefs.GetInt("playerSpeedItemNum", 0); 
		savePlayerSpeedItem = PlayerPrefs.GetFloat("playerSpeedItem", 0); 
		saveKagoScaleItemNum = PlayerPrefs.GetInt("kagoScaleItemNum", 0); 
		savePointUpItemNum = PlayerPrefs.GetInt("pointUpItemNum", 0); 
		saveTimeExtendItemNum = PlayerPrefs.GetInt("timeExtendItemNum", 0); 
		//
		isTimeCount = false;	//初期化
		isClear = false;		//初期化

		inGameCamvas.enabled = false;	//UI非表示
		clearCamvas.enabled = false;	//UI非表示
		item0Camvas.enabled = false;	//UI非表示
		item1Camvas.enabled = false;	//UI非表示
		item2Camvas.enabled = false;	//UI非表示
		item3Camvas.enabled = false;	//UI非表示
		ItemSelect();							//初期ステート
	}

	void LateUpdate () {
		//ステートの制御
		switch(state){
			case State.ItemSelect:
				break;
			//
			case State.Play:
				inGameCamvas.enabled = true;		//UI表示
				itemSelectCamvas.enabled = false;	//UI非表示
				isTimeCount = true;
			//time判定
			if(timeCount <= 0){
				timeCount = 0;
				isTimeCount = false;
				Clear();							//ステート変更
			}
				break;
			//
			case State.Clear:
				clearCamvas.enabled = true;		//UI表示
				inGameCamvas.enabled = false;	//UI非表示
				//一回だけ処理
				if(!isClear){
					HighScore();
					Debug.Log("clear");
				}
				break;
			//
			case State.Result:
				break;
			//
			case State.AllClear:
				break;
		}
	}
	
	void Update () {
		//timeカウント(clearで停止)
		if(isTimeCount){
			timeCount -= Time.deltaTime;	//play時間の保存
		}
	}

	void ItemSelect(){
		state = State.ItemSelect;
	}
	void Play(){
		timeCount = timeCount + playerTimeExtend;	//item反映
		state = State.Play;
	}
	void Clear(){
		state = State.Clear;
	}
	void Result(){
		state = State.Result;
	}
	void AllClear(){
		state = State.AllClear;
	}

	//shop用ポイントの計算
	void HighScore(){
		saveOkasiPoint = saveOkasiPoint + totalScore;		//shop用point加算
		PlayerPrefs.SetInt("totalOkasi", saveOkasiPoint);	//save
		isClear = true;
		Debug.Log("shop okasi point : " + PlayerPrefs.GetInt("totalOkasi"));
	}

	//okボタン用の制御関数
	public void ButtonClicked_game(){
		Play();							//ステート変更
	}
	//戻るボタン用の制御関数
	public void ButtonClicked_Title(){
		SceneManager.LoadScene("Title");	//シーンのロード
	}

	//アイテムセレクト処理
	//speedup item
	public void ToggleItem0()	{
		if(toggleItem0.isOn){
			savePlayerSpeedItemNum = savePlayerSpeedItemNum - 1;	//使用で減らす
			playerSpeedItem = savePlayerSpeedItem;
			item0Camvas.enabled = true;		//UI表示
		}else{
			savePlayerSpeedItemNum = savePlayerSpeedItemNum + 1;	//戻す
			playerSpeedItem = 0.0f;
			item0Camvas.enabled = false;	//UI非表示
		}
		PlayerPrefs.SetInt("playerSpeedItemNum", savePlayerSpeedItemNum);	//save
		Debug.Log("speed item : " + PlayerPrefs.GetInt("playerSpeedItemNum"));
	}

	//籠大きくitem
	public void ToggleItem1()	{
		if(toggleItem1.isOn){
			saveKagoScaleItemNum = saveKagoScaleItemNum - 1;	//使用で減らす
			playerKagoScale = 2.0f;
			item1Camvas.enabled = true;		//UI表示
		}else{
			saveKagoScaleItemNum = saveKagoScaleItemNum + 1;	//戻す
			playerKagoScale = 1.0f;
			item1Camvas.enabled = false;	//UI非表示
		}
		PlayerPrefs.SetInt("kagoScaleItemNum", saveKagoScaleItemNum);	//save
		Debug.Log("scale item : " + PlayerPrefs.GetInt("kagoScaleItemNum"));
	}

	//point up item
	public void ToggleItem2()	{
		if(toggleItem2.isOn){
			savePointUpItemNum = savePointUpItemNum - 1;	//使用で減らす
			playerPointUp = 2;
			item2Camvas.enabled = true;		//UI表示
		}else{
			savePointUpItemNum = savePointUpItemNum + 1;	//戻す
			playerPointUp = 1;
			item2Camvas.enabled = false;	//UI非表示
		}
		PlayerPrefs.SetInt("pointUpItemNum", savePointUpItemNum);	//save
		Debug.Log("point up item : " + PlayerPrefs.GetInt("pointUpItemNum") + " : " + playerPointUp);
	}

	//time extend item
	public void ToggleItem3()	{
		if(toggleItem3.isOn){
			saveTimeExtendItemNum = saveTimeExtendItemNum - 1;	//使用で減らす
			playerTimeExtend = 10.0f;
			item3Camvas.enabled = true;		//UI表示
		}else{
			saveTimeExtendItemNum = saveTimeExtendItemNum + 1;	//戻す
			playerTimeExtend = 0.0f;
			item3Camvas.enabled = false;	//UI非表示
		}
		PlayerPrefs.SetInt("timeExtendItemNum", saveTimeExtendItemNum);	//save
		Debug.Log("TimeExtend item : " + PlayerPrefs.GetInt("timeExtendItemNum") + " : " + playerTimeExtend);
	}
}
