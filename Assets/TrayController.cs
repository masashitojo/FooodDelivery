using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayController : MonoBehaviour {
	//bike オブジェクト
	private GameObject bike;

	// Use this for initialization
	void Start () {
		//
		this.bike = GameObject.Find("BikePrefab");
	}
	
	// Update is called once per frame
	void Update () {
		float xPos = bike.transform.position.x -3.5f;
		float yPos = bike.transform.position.y + 4.0f;
		float zPos = bike.transform.position.z -1.0f;
		float xRot = bike.transform.eulerAngles.x;
		this.transform.position = new Vector3(xPos,yPos,zPos);
		this.transform.eulerAngles = new Vector3(xRot,0.0f,0.0f);
	}


	////トリガーモードで他のオブジェクトと接触した場合の処理（追加）
	//void OnCollisionStay(Collision other) {
	////void OnCollisionEnter(Collision other) {
	//	Rigidbody rb = other.collider.attachedRigidbody;
	//	rb.velocity = this.transform.forward * speed;
	//	Debug.Log ("0n");
	//
	//}
}
