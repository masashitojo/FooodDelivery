using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour {
        //Bikeのオブジェクト
        private GameObject bike;
		//Bikeとカメラの距離
        private float difference;

        // Use this for initialization
        void Start () {
				//Bikeのオブジェクトを取得
                this.bike = GameObject.Find ("BikePrefab");
				//Bikeとカメラの位置（z座標）の差を求める
				this.difference = bike.transform.position.z - this.transform.position.z;
        
        }
        
        // Update is called once per frame
        void Update () {
				//Bikeの位置に合わせてカメラの位置を移動
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.bike.transform.position.z-difference);
        }
}