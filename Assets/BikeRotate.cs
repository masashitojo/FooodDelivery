using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeRotate : MonoBehaviour {

	private Vector3 normalVector = Vector3.zero;//法線ベクトル



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//衝突検出
	void OnControllerColliderHit(ControllerColliderHit other)
	{
		if (other.gameObject.tag == "BlockTag") {
			float normalAtan = Mathf.Atan (other.normal.z / other.normal.y);
			this.transform.eulerAngles = new Vector3 (Mathf.Rad2Deg * (normalAtan), 0.0f, 0.0f);
		} else if (other.gameObject.tag == "RoadTag") {
			this.transform.eulerAngles = new Vector3 (0.0f, 0.0f, 0.0f);
		}
	}

}
