using UnityEngine;
using System.Collections;


public class ClickToMove : MonoBehaviour {


	public float speed;
	public CharacterController charCtrl;

	public AnimationClip run;
	public AnimationClip idle;

	public static bool attack;

	Vector3 clickPosition;


	void Start () {
		clickPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButton(0)){

			locateClickPosition();
		}

		moveToClickPosition();
	
		Debug.DrawLine(transform.position, clickPosition, Color.cyan);
	}


	void locateClickPosition(){
		RaycastHit hit;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


		if(Physics.Raycast(ray, out hit, 1000)){
			clickPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			Debug.Log(clickPosition);
		}
	}

	void moveToClickPosition(){

		if(!attack){
			if(Vector3.Distance(transform.position, clickPosition)>1.5)
			{
				Quaternion newRotation = Quaternion.LookRotation(clickPosition-transform.position);
				
				newRotation.x = 0f;
				newRotation.z = 0f;
				
				transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
				charCtrl.SimpleMove(transform.forward * speed);
				
				animation.CrossFade(run.name);
			}else {
				animation.CrossFade(idle.name);
			}
		}
	}
}
