using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIshop_ItemPoint : MonoBehaviour {
//.	public GameObject shopController;	//ShopController取得
	public Text itemPointText;			//Textコンポーネント取得用

	void Start () {
//		shopController = GameObject.FindWithTag ("UIController");	//ShopControllerオブジェクトを探す
	}
	
	void Update () {
		//scって仮の変数にShopControllerのコンポーネントを入れる
//		ShopController sc = shopController.GetComponent<ShopController>();
		//値段表示
//		itemPointText.text = sc.Item1_Point.ToString("000");
	}
}
