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
	public bool isGameOver;			//GameOver flag
	public int shildHp;				//ShildHP
	public float okasiSpeedMaster;	//全てのお菓子用1秒間に弾が進む距離
	public float editOkasiSpeed;
	private bool isSpeedUp;					//speedUP一回だけ処理

	public Canvas itemSelectCamvas;	//UI itemSelect
	public Canvas inGameCamvas;		//UI inGame
	public Canvas clearCamvas;		//UI clear
	public Canvas gameOverCamvas;	//UI GameOver
	public Canvas item0Camvas;		//UI item0 speedup
	public Canvas item1Camvas;		//UI item1 speedup
	public Canvas item2Camvas;		//UI item2 speedup
	public Canvas item3Camvas;		//UI item3 speedup
	public Canvas item4Camvas;		//UI item4 speedup
	public Canvas item5Camvas;		//UI item5 speedup
	public Toggle toggleItem0;		//toggle
	public Toggle toggleItem1;		//toggle
	public Toggle toggleItem2;		//toggle
	public Toggle toggleItem3;		//toggle
	public Toggle toggleItem4;		//toggle
	public Toggle toggleItem5;		//toggle

	private float savePlayerSpeedItem;		//一時保存用
	private int savePlayerSpeedItemNum;		//一時保存用
	private int saveKagoScaleItemNum;		//一時保存用
	private int savePointUpItemNum;			//一時保存用
	private int saveTimeExtendItemNum;		//一時保存用
	private int saveNoOjyamaItemNum;		//一時保存用
	private int saveShildItemNum;			//一時保存用
	public float playerSpeedItem;			//shopで購入
	public float playerKagoScale;			//shopで購入
	public int playerPointUp;				//shopで購入
	public float playerTimeExtend;			//shopで購入
	public bool playerNoOjyama;				//shopで購入
	public bool playerShild;				//shopで購入
	private bool tempItem0zero;				//一時保存用
	private bool tempItem1zero;				//一時保存用
	private bool tempItem2zero;				//一時保存用
	private bool tempItem3zero;				//一時保存用
	private bool tempItem4zero;				//一時保存用
	private bool tempItem5zero;				//一時保存用

	//ゲームステート
	enum State{
		ItemSelect,	//
		Play,		//inGame
		Clear,		//
		Result,		//
		GameOver,
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
		saveNoOjyamaItemNum = PlayerPrefs.GetInt("noOjyamaItemNum", 0); 
		saveShildItemNum = PlayerPrefs.GetInt("shildItemNum", 0); 
		//
		shildHp = 2;			//初期化
		isTimeCount = false;	//初期化
		isClear = false;		//初期化
		isGameOver = false;		//初期化
		tempItem0zero = false;	//初期化
		tempItem1zero = false;	//初期化
		tempItem2zero = false;	//初期化
		tempItem3zero = false;	//初期化
		tempItem4zero = false;	//初期化
		tempItem5zero = false;	//初期化

		inGameCamvas.enabled = false;	//UI非表示
		clearCamvas.enabled = false;	//UI非表示
		gameOverCamvas.enabled = false;	//UI非表示
		item0Camvas.enabled = false;	//UI非表示
		item1Camvas.enabled = false;	//UI非表示
		item2Camvas.enabled = false;	//UI非表示
		item3Camvas.enabled = false;	//UI非表示
		item4Camvas.enabled = false;	//UI非表示
		item5Camvas.enabled = false;	//UI非表示
		ItemSelect();					//初期ステート
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
//				Debug.Log("isGameOver:" + isGameOver);
				//GameOver判定
				if(isGameOver){
					GameOver();
				}

				//time判定
				if(timeCount <= 0){
					timeCount = 0;
					isTimeCount = false;
//					Clear();							//ステート変更
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
			case State.GameOver:
				gameOverCamvas.enabled = true;	//UI表示
				inGameCamvas.enabled = false;	//UI非表示
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

		//お菓子SpeedUP処理
		//10個catch毎に落下速度が速くなる
		if((totalCatch % 10) == 0 && totalCatch > 0){
			if(isSpeedUp == false){
//				okasiSpeedMaster -= 0.05f;
				okasiSpeedMaster -= editOkasiSpeed;
				isSpeedUp = true;
				Debug.Log("SpeedUp");
			}
		}else{
			isSpeedUp = false;
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
	void GameOver(){
		state = State.GameOver;
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
		if(savePlayerSpeedItemNum >= 1){
			if(toggleItem0.isOn){
				savePlayerSpeedItemNum = savePlayerSpeedItemNum - 1;	//使用で減らす
				playerSpeedItem = savePlayerSpeedItem;
				if(savePlayerSpeedItemNum == 0){
					tempItem0zero = true;	//zero制御用
					item0Camvas.enabled = true;		//UI表示
				}
			}else{
				savePlayerSpeedItemNum = savePlayerSpeedItemNum + 1;	//戻す
				playerSpeedItem = 0.0f;
				item0Camvas.enabled = false;	//UI非表示
			}
		}else if(savePlayerSpeedItemNum == 0 && tempItem0zero == true){
			if(!toggleItem0.isOn){
				savePlayerSpeedItemNum = savePlayerSpeedItemNum + 1;	//戻す
				playerSpeedItem = 0.0f;
				item0Camvas.enabled = false;	//UI非表示
				tempItem0zero = false;			//zero制御用
			}
		}else{
			Debug.Log("No Item");
		}
		PlayerPrefs.SetInt("playerSpeedItemNum", savePlayerSpeedItemNum);	//save
		Debug.Log("speed item : " + PlayerPrefs.GetInt("playerSpeedItemNum"));
	}

	//籠大きくitem
	public void ToggleItem1()	{
		if(saveKagoScaleItemNum >= 1){
			if(toggleItem1.isOn){
				saveKagoScaleItemNum = saveKagoScaleItemNum - 1;	//使用で減らす
				playerKagoScale = 2.0f;
				if(saveKagoScaleItemNum == 0){
					tempItem1zero = true;	//zero制御用
					item1Camvas.enabled = true;		//UI表示
				}
			}else{
				saveKagoScaleItemNum = saveKagoScaleItemNum + 1;	//戻す
				playerKagoScale = 1.0f;
				item1Camvas.enabled = false;	//UI非表示
			}
		}else if(saveKagoScaleItemNum == 0 && tempItem1zero == true){
			if(!toggleItem1.isOn){
				saveKagoScaleItemNum = saveKagoScaleItemNum + 1;	//戻す
				playerKagoScale = 1.0f;
				item1Camvas.enabled = false;	//UI非表示
				tempItem1zero = false;			//zero制御用
			}
		}else{
			Debug.Log("No Item");
		}
		PlayerPrefs.SetInt("kagoScaleItemNum", saveKagoScaleItemNum);	//save
		Debug.Log("scale item : " + PlayerPrefs.GetInt("kagoScaleItemNum"));
	}

	//point up item
	public void ToggleItem2()	{
		if(savePointUpItemNum >= 1){
			if(toggleItem2.isOn){
				savePointUpItemNum = savePointUpItemNum - 1;	//使用で減らす
				playerPointUp = 2;
				if(savePointUpItemNum == 0){
					tempItem2zero = true;	//zero制御用
					item2Camvas.enabled = true;		//UI表示
				}
			}else{
				savePointUpItemNum = savePointUpItemNum + 1;	//戻す
				playerPointUp = 1;
				item2Camvas.enabled = false;	//UI非表示
			}
		}else if(savePointUpItemNum == 0 && tempItem2zero == true){
			if(!toggleItem2.isOn){
				savePointUpItemNum = savePointUpItemNum + 1;	//戻す
				playerPointUp = 1;
				item2Camvas.enabled = false;	//UI非表示
				tempItem2zero = false;			//zero制御用
			}
		}else{
			Debug.Log("No Item");
		}
		PlayerPrefs.SetInt("pointUpItemNum", savePointUpItemNum);	//save
		Debug.Log("point up item : " + PlayerPrefs.GetInt("pointUpItemNum") + " : " + playerPointUp);
	}

	//time extend item
	public void ToggleItem3()	{
		if(saveTimeExtendItemNum >= 1){
			if(toggleItem3.isOn){
				saveTimeExtendItemNum = saveTimeExtendItemNum - 1;	//使用で減らす
				playerTimeExtend = 10.0f;
				if(saveTimeExtendItemNum == 0){
					tempItem3zero = true;	//zero制御用
					item3Camvas.enabled = true;		//UI表示
				}
			}else{
				saveTimeExtendItemNum = saveTimeExtendItemNum + 1;	//戻す
				playerTimeExtend = 0.0f;
				item3Camvas.enabled = false;	//UI非表示
			}
		}else if(saveTimeExtendItemNum == 0 && tempItem3zero == true){
			if(!toggleItem3.isOn){
				saveTimeExtendItemNum = saveTimeExtendItemNum + 1;	//戻す
				playerTimeExtend = 0.0f;
				item3Camvas.enabled = false;	//UI非表示
				tempItem3zero = false;			//zero制御用
			}
		}else{
			Debug.Log("No Item");
		}
		PlayerPrefs.SetInt("timeExtendItemNum", saveTimeExtendItemNum);	//save
		Debug.Log("TimeExtend item : " + PlayerPrefs.GetInt("timeExtendItemNum") + " : " + playerTimeExtend);
	}

	//No Ojyama item
	public void ToggleItem4()	{
		if(saveNoOjyamaItemNum >= 1){
			if(toggleItem4.isOn){
				saveNoOjyamaItemNum = saveNoOjyamaItemNum - 1;	//使用で減らす
				playerNoOjyama = true;
				if(saveNoOjyamaItemNum == 0){
					tempItem4zero = true;	//zero制御用
					item4Camvas.enabled = true;		//UI表示
				}
			}else{
				saveNoOjyamaItemNum = saveNoOjyamaItemNum + 1;	//戻す
				playerNoOjyama = false;
				item4Camvas.enabled = false;	//UI非表示
			}
		}else if(saveNoOjyamaItemNum == 0 && tempItem4zero == true){
			if(!toggleItem4.isOn){
				saveNoOjyamaItemNum = saveNoOjyamaItemNum + 1;	//戻す
				playerNoOjyama = false;
				item4Camvas.enabled = false;	//UI非表示
				tempItem4zero = false;			//zero制御用
			}
		}else{
			Debug.Log("No Item");
		}
		PlayerPrefs.SetInt("noOjyamaItemNum", saveNoOjyamaItemNum);	//save
		Debug.Log("NoOjyama item : " + PlayerPrefs.GetInt("noOjyamaItemNum") + " : " + playerNoOjyama);
	}
	//Shild item
	public void ToggleItem5()	{
		if(saveShildItemNum >= 1){
			if(toggleItem5.isOn){
				saveShildItemNum = saveShildItemNum - 1;	//使用で減らす
				playerShild = true;
				if(saveShildItemNum == 0){
					tempItem5zero = true;	//zero制御用
					item5Camvas.enabled = true;		//UI表示
				}
			}else{
				saveShildItemNum = saveShildItemNum + 1;	//戻す
				playerShild = false;
				item5Camvas.enabled = false;	//UI非表示
			}
		}else if(saveShildItemNum == 0 && tempItem5zero == true){
			if(!toggleItem5.isOn){
				saveShildItemNum = saveShildItemNum + 1;	//戻す
				playerShild = false;
				item5Camvas.enabled = false;	//UI非表示
				tempItem5zero = false;			//zero制御用
			}
		}else{
			Debug.Log("No Item");
		}
		PlayerPrefs.SetInt("shildItemNum", saveShildItemNum);	//save
		Debug.Log("Shild item : " + PlayerPrefs.GetInt("shildItemNum") + " : " + playerShild);
	}
}
