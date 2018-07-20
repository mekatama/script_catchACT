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
	public Toggle toggleItem0;		//toggle
	public Toggle toggleItem1;		//toggle

	private float savePlayerSpeedItem;		//一時保存用
	private int savePlayerSpeedItemNum;		//一時保存用
	private int saveKagoScaleItemNum;		//一時保存用
	public float playerSpeedItem;			//shopで購入
	public float playerKagoScale;			//shopで購入


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
		//
		isTimeCount = false;	//初期化
		isClear = false;		//初期化

		inGameCamvas.enabled = false;	//UI非表示
		clearCamvas.enabled = false;	//UI非表示
		item0Camvas.enabled = false;	//UI非表示
		item1Camvas.enabled = false;	//UI非表示
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
}
