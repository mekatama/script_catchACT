using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int totalScore = 0;		//合計スコアを管理
	public int totalCatch = 0;		//合計キャッチ数
	public int highScore;			//ハイスコア

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

		Play();						//初期ステート
	}

	void LateUpdate () {
		//ステートの制御
		switch(state){
			//
			case State.Play:
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
		Debug.Log("totalScore:" + totalScore + "   totalCatch:" + totalCatch);
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
