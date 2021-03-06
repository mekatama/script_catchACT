﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkasiSpawn : MonoBehaviour {
	GameObject gameController;			//検索したオブジェクト入れる用
	public GameObject[] okasiObject;	//okasiのプレハブを配列で管理
	public float timeOut;				//okasiを出現させたい時間間隔
	private float timeElapsed;			//時間を仮に格納する変数
	private int okasiType;				//okasiの種類
	private bool isTime;				//
	public GameObject okasi;

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		okasiType = 0;							//(仮)okasiの種類
		isTime = false;
		okasi = null;
	}

	void Update () {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//10個catch毎にスポーン時間を短くする
		if((gc.totalCatch % 10) == 0){
			if(isTime == false){
				if(timeOut > 0.03f){
					timeOut -= gc.editOkasiSpawn;
					isTime = true;
				}
			}
		}else{
			isTime = false;
		}

		//時間チェック
		timeElapsed += Time.deltaTime;	//経過時間の保存
        if(timeElapsed >= timeOut) {	//指定した経過時間に達したら
			OkasiGo();
		}
	}
	
	public void OkasiGo(){
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//NoOjyama Item分岐
		if(gc.playerNoOjyama){
			okasiType = Random.Range(0, 4);			//(仮)okasiの種類。最終的にgamecontrollで制御
		}else{
			okasiType = Random.Range(0, 5);			//(仮)okasiの種類。最終的にgamecontrollで制御
		}
		float x_pos = Random.Range(-3.5f,3.5f); //ランダムで出現位置を決める

		if(gc.isTimeCount){
			if(!gc.isClear){
				//okasiを生成する
				okasi = (GameObject)Instantiate(
//				GameObject okasi = (GameObject)Instantiate(
					okasiObject[okasiType],						//■仮で0を入れている。0～4を想定
					new Vector3(x_pos, transform.position.y, transform.position.z),
					transform.rotation
				);
			}
		}
		timeElapsed = 0.0f;			//生成時間リセット
	}
}
