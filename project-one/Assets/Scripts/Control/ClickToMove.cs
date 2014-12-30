using UnityEngine;
using System.Collections;


public class ClickToMove : MonoBehaviour {


	public float speed;

	public Character character;

	public AnimationClip run;
	public AnimationClip idle;



	float destinationDistance;
	Vector3 destinationPosition;




	void Start () {
		destinationPosition = transform.position;
		character = GetComponent("Character") as Character;
	}
	
	// Update is called once per frame
	void Update () {


		destinationDistance = Vector3.Distance(destinationPosition, transform.position);
		
		if(destinationDistance < .5f){		// To prevent shakin behavior when near destination
			character.speed = 0;
		}
		else if(destinationDistance > .5f){			// To Reset Speed to default
			character.speed = character.speedDefault;
		}


		if(Input.GetMouseButton(0)){

			locateClickPosition();
		}

		moveToClickPosition();
	}


	void locateClickPosition(){

		Plane playerPlane = new Plane(Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;
		if( Physics.Raycast(ray,out hit) ){
			destinationPosition = hit.point;
			Quaternion targetRotation = Quaternion.LookRotation(hit.point - transform.position);

			targetRotation.x = 0;
			targetRotation.z = 0;

			character.moveDestinationRotation = targetRotation;

		}


//		float hitdist;
//		if (playerPlane.Raycast (ray, out hitdist)) {
//			Vector3 targetPoint = ray.GetPoint(hitdist);
//			destinationPosition = ray.GetPoint(hitdist);
//			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
//			character.moveDestinationRotation = targetRotation;
//
////			transform.rotation = targetRotation;
//		}

	}

	void moveToClickPosition(){


		if(destinationDistance > .5f){

			character.state = CharacterState.CharacterStateRun;
			character.moveDestinationPosition = destinationPosition;
//			transform.position = Vector3.MoveTowards(transform.position, destinationPosition, speed * Time.deltaTime);
//			animation.CrossFade(run.name);
		}else {
			character.state = CharacterState.CharacterStateIdle;
//			animation.CrossFade(idle.name);
		}
	}
}
