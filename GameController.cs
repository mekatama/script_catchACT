using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int totalScore = 0;		//合計スコアを管理
	public int totalCatch = 0;		//合計キャッチ数
	public int highScore;			//ハイスコア
	public float timeCount;	//制限時間
	private bool isTimeCount;
	private bool isClear;

	public Canvas inGameCamvas;		//UI inGame

	//ゲームステート
	enum State{
		Play,		//inGame
		Clear,		//
		Result,		//
		AllClear	//
	}
	State state;

	void Start () {
		//HighScoreがなかったら０を入れて初期化
		highScore =	PlayerPrefs.GetInt("HighScore", 100); 
		isTimeCount = false;	//初期化
		isClear = false;		//初期化
		Play();						//初期ステート
	}

	void LateUpdate () {
		//ステートの制御
		switch(state){
			//
			case State.Play:
				isTimeCount = true;
				break;
			//
			case State.Clear:
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
			if(isClear == false){
				timeCount -= Time.deltaTime;	//play時間の保存
			}
		}
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
}
