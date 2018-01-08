using UnityEngine;
using System.Collections;

public class StereoCamera : MonoBehaviour {
	public int camera_mode=0;
	public int stereo_mode=1;
	public Transform target;
	public float displacement=17;
	public bool stereo=true;
	public Camera cameraL;
	public float distance=10;
	public float height=5;
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;
	public bool showInfo=true;
	private Quaternion saveRot;
	private Vector3 savePos;

	// Use this for initialization
	void Start () {
		saveRot=transform.rotation;
		savePos=transform.position;
		Invoke ("HideText",20);

		TextEditor te = new TextEditor();
		te.SelectAll();
		te.Copy();
	}
	void HideText(){
		showInfo=false;
	}

	void OnGUI(){
 

	}

	void LateUpdate() {

		if (Input.GetKey("f1") && displacement>-200) 
			displacement-=0.01f;
		if (Input.GetKey("f2") && displacement<200) 
			displacement+=0.01f;
		if (Input.GetKeyDown("escape")) 
			Application.LoadLevel(Application.loadedLevel);
		
		if (Input.GetKeyUp(KeyCode.C)){
			if(camera_mode==0){
				saveRot=transform.rotation;
				savePos=transform.position;
				camera_mode=1;
			} else
				camera_mode=0;
		} 
		if (Input.GetKeyUp(KeyCode.X)){
			Camera c=transform.GetComponent<Camera>();
			if(c.rect.width==0.5f)
				c.rect=new Rect(0,0,1,1);
			else
				c.rect=new Rect(0,0,0.5f,1);
		} 
		if (Input.GetKeyUp(KeyCode.H)){
			showInfo=!showInfo;
		} 
	
		switch (camera_mode){
		case 0:simpleFollow();break;
		case 1:smoothFollow();break;
		}

	}

	void simpleFollow() {
	
		transform.position =  target.position;
		transform.position -= Vector3.forward * distance;
		
		Vector3 h=transform.position;
		h.y+=height;
		transform.position= h;

		transform.LookAt (target);
		
		
		if(stereo){
			cameraL.transform.position=transform.position;
			cameraL.transform.rotation=transform.rotation;
			Camera.main.transform.RotateAround(target.position, Vector3.up, -displacement*2);
			cameraL.transform.RotateAround(target.position, Vector3.up, displacement*2);
			cameraL.transform.LookAt (target);
			
		}
		
		
	}
	void smoothFollow() {
		transform.rotation=saveRot;
		transform.position=savePos;

		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;
		
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;
		
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		Quaternion	currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
		Vector3 h=transform.position;
		h.y=currentHeight;
		transform.position=h;
		transform.LookAt (target);
		saveRot=transform.rotation;
		savePos=transform.position;

		if(stereo){
			cameraL.transform.position=transform.position;
			cameraL.transform.rotation=transform.rotation;
			transform.RotateAround(target.position, Vector3.up, -displacement);
			cameraL.transform.RotateAround(target.position, Vector3.up, displacement);
			cameraL.transform.LookAt (target);
			
		}
		
		
		
		
	}

}

