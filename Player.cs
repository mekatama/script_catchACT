using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	GameObject gameController;			//検索したオブジェクト入れる用
	CharacterController characterController;//コンポーネントを入れる用
//	Animator animator;
	public float graviy;					//重力値
	public Vector3 velocity;				//最終的な速度
	public float moveX = 0f;				//x方向移動用
	public float speedX = 1.5f;				//x方向速度用

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		characterController = GetComponent<CharacterController>();	//コンポーネントを取得
//		animator = GetComponent<Animator>();	//コンポーネントを取得
		velocity = Vector3.zero;				//0ベクトル
	}
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//地上にいる時の処理
		if(characterController.isGrounded){
			//【ボタン移動したい時は、コメントアウトする】
			 moveX = Input.GetAxis ("Horizontal") * (speedX + gc.playerSpeedItem);	//左右入力でx方向のベクトル出す
			 velocity.x = moveX;							//最終的な速度ベクトルに代入
		}
		//地上にいない時
		else{
			velocity.y -= graviy * Time.deltaTime;	//重力の加算
		}

		if(!gc.isClear){
//			Debug.Log(velocity.x);
			characterController.Move(velocity * Time.deltaTime);
		}
	}

	public void moveLeft(){
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		velocity.x = (speedX + gc.playerSpeedItem) * -1;	//最終的な速度ベクトルに代入
	}

	public void moveRight(){
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		velocity.x = (speedX + gc.playerSpeedItem);			//最終的な速度ベクトルに代入
	}

	public void moveStop(){
		velocity = Vector3.zero;							//最終的な速度ベクトルに代入
	}
}
