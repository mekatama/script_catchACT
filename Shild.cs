﻿using System.Collections;
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
	}
}