using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	CharacterController characterController;//コンポーネントを入れる用
//	Animator animator;
	public float graviy;					//重力値
	private Vector3 velocity;				//最終的な速度
	private float moveX = 0f;				//x方向移動用
	public float speedX = 1.5f;				//x方向速度用

	void Start () {
		characterController = GetComponent<CharacterController>();	//コンポーネントを取得
//		animator = GetComponent<Animator>();	//コンポーネントを取得
		velocity = Vector3.zero;				//0ベクトル
	}
	
	void Update () {
		//地上にいる時の処理
		if(characterController.isGrounded){
			 moveX = Input.GetAxis ("Horizontal") * speedX;	//左右入力でx方向のベクトル出す
			 velocity.x = moveX;							//最終的な速度ベクトルに代入
/*
			//デバッグ用
			if(Input.GetKeyDown("left")){
				Debug.Log("go left");
			}
			if(Input.GetKeyDown("right")){
				Debug.Log("go right");
			}
*/
		}
		//地上にいない時
		else{
			velocity.y -= graviy * Time.deltaTime;	//重力の加算
		}

		//移動実行
		characterController.Move(velocity * Time.deltaTime);
	}
}
