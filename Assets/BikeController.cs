using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BikeController : MonoBehaviour
{
	//private Rigidbody myRigidbody;//Bikeを移動させるコンポーネントを入れる
	//private float forwardForce = 300.0f;//前進するための力
	//private Vector3 normalVector = Vector3.zero;//法線ベクトル
	private Vector3 bikeVector = new Vector3(0.0f, 0.0f, 0.01f);//bikeの移動方向ベクトル
	private CharacterController charaCon;// キャラクターコンポーネント用の変数
	public float idoSpeed = 0.05f;         // 移動速度（Public＝インスペクタで調整可能）
	public float rotateSpeed = 3.0F;     // 向きを変える速度（Public＝インスペクタで調整可能）
	public float kaitenSpeed = 1200.0f;   // プレイヤーの回転速度（Public＝インスペクタで調整可能）
	public float gravity = 1.0F;   //重力の強さ（Public＝インスペクタで調整可能）
	private float sum=0.01f;


	// Use this for initialization
	void Start()
	{
		Input.gyro.enabled = true;//ジャイロセンサーを有効化
		this.charaCon = GetComponent<CharacterController>(); // キャラクターコントローラーのコンポーネントを参照する
	}

	// Update is called once per frame
	void Update()
	{
		//ジャイロ更新
		UpdateGyro();
		//落下処理
		if (charaCon.isGrounded)    //CharacterControllerの付いているこのオブジェクトが接地している場合の処理
		{
			bikeVector.y = 0f;  //Y方向への速度をゼロにする
			bikeVector = bikeVector;  //移動スピードを向いている方向に与える
		}
		else  //CharacterControllerの付いているこのオブジェクトが接地していない場合の処理
		{
			bikeVector.y -= gravity;  //マイナスのY方向（下向き）に重力を与える
		}
		//移動
		//charaCon.Move(bikeVector * Time.deltaTime);  //CharacterControllerの付いているこのオブジェクトを移動させる処理
		charaCon.Move(bikeVector);  //CharacterControllerの付いているこのオブジェクトを移動させる処理


		//this.myRigidbody.AddForce (this.bikeVector * this.forwardForce);
		//if (Input.GetKeyDown (KeyCode.LeftArrow)) {
		//	this.myRigidbody.AddForce (this.bikeVector * this.forwardForce,ForceMode.Impulse);
		//}	else if (Input.GetKeyDown(KeyCode.RightArrow)){
		//	this.myRigidbody.AddForce (this.bikeVector * (-this.forwardForce),ForceMode.Impulse);
		//}
		////UpdateGyroData();	
		////this.myRigidbody.AddForce (this.bikeVector* this.forwardForce);
		//Debug.Log (this.bikeVector* this.forwardForce);
		//
		////Bikeに前方向の力を加える
		////this.myRigidbody.AddForce (this.transform.forward * this.forwardForce);
		////this.transform.DOLocalJump(endValue: new Vector3(0, 0.1f, 0),jumpPower: 0.1f,numJumps: 2,duration: 2.0f)
	}

	//ジャイロ取得
	private void UpdateGyro(){
		//Debug.Log("force="+(-Input.gyro.attitude.z-0.2f)*0.3f);
		//this.sum = this.sum +((-Input.gyro.attitude.z-0.2f)*0.1f);
		float gyroForce = (-Input.gyro.attitude.z-0.23f)*0.5f;
		//速度制限
		if (gyroForce <= 0.0f) {
			this.sum += gyroForce;
			if (this.sum <= -0.09f) {
				this.sum = -0.1f;
			}
		} else {
			this.sum += gyroForce*0.1f;
			if (this.sum >= 0.99f) {
				this.sum = 1.0f;
			}
		}
		this.bikeVector.z = this.sum;
		//Debug.Log ("sum="+sum);
	}


}