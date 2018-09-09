using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kago : MonoBehaviour {
	GameObject gameController;			//検索したオブジェクト入れる用
	private bool isScale;
	AudioSource audioSource;				//AudioSourceコンポーネント取得用
	public AudioClip audioClipShildBreake;	//ShildBreake SE

	void Start () {
		isScale = false;
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		audioSource = gameObject.GetComponent<AudioSource>();		//AudioSourceコンポーネント取得
	}
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		if(gc.playerKagoScale > 1.0f){
		if(isScale == false){
			Debug.Log("kago scale : " + gc.playerKagoScale);
			//kagoの大きさ設定
			this.transform.localScale = new Vector3(gc.playerKagoScale, 0.1f, 1);
			isScale = true;
		}
		}
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter(Collider other) {
		if(other.tag == "okasi_toge"){
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();
			if(gc.playerShild){
				if(gc.shildHp > 0){
					gc.shildHp -= 1;
					//SE再生
					audioSource.clip = audioClipShildBreake;	//SE決定
					audioSource.Play ();				//SE再生
				}else if(gc.shildHp == 0){
					gc.isGameOver = true;			
					//このGameObjectを［Hierrchy］ビューから削除する
					Destroy(gameObject);
				}
			}else{
				gc.isGameOver = true;			
				//このGameObjectを［Hierrchy］ビューから削除する
				Destroy(gameObject);
			}
//			Debug.Log("shildHP = " + gc.shildHp);
		}
	}
}
