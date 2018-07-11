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
	public Canvas clearCamvas;		//UI inGame

	private float savePlayerSpeedItem;	//
	private int saveKagoScaleItemNum;	//
	public float playerSpeedItem;	//shopで購入
	public float playerKagoScale;	//shopで購入

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
		savePlayerSpeedItem = PlayerPrefs.GetFloat("playerSpeedItem", 0); 
		saveKagoScaleItemNum = PlayerPrefs.GetInt("kagoScaleItemNum", 0); 
		//
		isTimeCount = false;	//初期化
		isClear = false;		//初期化
		//itemパラメーター反映
		playerSpeedItem = savePlayerSpeedItem;

		inGameCamvas.enabled = false;	//UI非表示
		clearCamvas.enabled = false;	//UI非表示
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
}
