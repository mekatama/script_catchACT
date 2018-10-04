using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkasiSpawn_title : MonoBehaviour {
	public GameObject[] okasiObject;	//okasiのプレハブを配列で管理
	public float timeOut;				//okasiを出現させたい時間間隔
	private float timeElapsed;			//時間を仮に格納する変数
	private int okasiType;				//okasiの種類
	public GameObject okasi;

	void Start () {
		okasiType = 0;							//(仮)okasiの種類
		okasi = null;
	}

	void Update () {
		//時間チェック
		timeElapsed += Time.deltaTime;	//経過時間の保存
        if(timeElapsed >= timeOut) {	//指定した経過時間に達したら
			OkasiGo();
		}
	}
	
	public void OkasiGo(){
		okasiType = Random.Range(0, 5);			//(仮)okasiの種類。最終的にgamecontrollで制御
		float x_pos = Random.Range(-4.0f,4.0f); //ランダムで出現位置を決める

		//okasiを生成する
		okasi = (GameObject)Instantiate(
			okasiObject[okasiType],						//■仮で0を入れている。0～4を想定
			new Vector3(x_pos, transform.position.y, transform.position.z),
			transform.rotation
		);
		timeElapsed = 0.0f;			//生成時間リセット
	}
}
