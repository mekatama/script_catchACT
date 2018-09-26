using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shild : MonoBehaviour {
	public int shildDel;
	GameObject gameController;			//検索したオブジェクト入れる用

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}
	
	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		if(gc.shildHp == shildDel){
				Destroy(gameObject);	//shild obj消す
		}

		//表示on/off
		if(gc.playerShild){
			this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}else{
			this.transform.localScale = new Vector3(0, 0, 0);
		}
	}
}
