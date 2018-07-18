using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kago : MonoBehaviour {
	GameObject gameController;			//検索したオブジェクト入れる用

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		Debug.Log("kago scale : " + gc.playerKagoScale);
		//kagoの大きさ設定
		this.transform.localScale = new Vector3(gc.playerKagoScale, 0.1f, 1);
	}
}
