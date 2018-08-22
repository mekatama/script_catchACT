using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Okasi : MonoBehaviour {
	public int okasiScore;				//okasiスコア
	public float okasiSpeed = -0.05f;	//1秒間に弾が進む距離
	GameObject gameController;			//検索したオブジェクト入れる用
//	GameObject player;					//検索したオブジェクト入れる用
	public Rigidbody rb;
	private bool hasiR;
	private bool hasiL;
	private float yForce;				//y軸の力


	void Start(){
		hasiR = false;
		hasiL = false;
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
		if(hasiR){
			rb.AddForce(100 , yForce , 0 );
		}

		if(hasiL){
			rb.AddForce(-100 , yForce , 0 );
		}
	}

	void Update() {
		if(!hasiR || !hasiL){
			//移動量
			this.transform.position += new Vector3 (0, okasiSpeed, 0);
		}
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
			if(gc.totalScore < 0){
				gc.totalScore = 0;
			}
			gc.totalCatch += 1;							//キャッチ数加算
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
		if(other.tag == "okasi_toge"){
			//このGameObjectを［Hierrchy］ビューから削除する
			Destroy(gameObject);
		}
		if(other.tag == "kago_hasi"){
			yForce = Random.Range(30, 40);	//randomで軌道に変化出したい
			Debug.Log("hasiR : " + yForce);
			hasiR = true;
		}
		if(other.tag == "kago_hasi2"){
			yForce = Random.Range(30, 40);	//randomで軌道に変化出したい
			Debug.Log("hasiL : " + yForce);
			hasiL = true;
		}
	}
}
