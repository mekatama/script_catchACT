using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Okasi : MonoBehaviour {
	public int okasiScore;				//okasiスコア
	public float okasiSpeed = -0.05f;	//1秒間に弾が進む距離
	GameObject gameController;			//検索したオブジェクト入れる用
//	GameObject player;					//検索したオブジェクト入れる用

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}

	void Update() {
		//移動量
		this.transform.position += new Vector3 (0, okasiSpeed, 0);
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter(Collider other) {
		if(other.tag == "ground"){
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
		if(other.tag == "kago"){
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();
			gc.totalScore = gc.totalScore + (okasiScore * gc.playerPointUp);	//スコア加算/point up値
			gc.totalCatch += 1;							//キャッチ数加算
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
	}
}
