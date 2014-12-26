using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

	public float range;
	public float speed;

	public Transform player;
	public CharacterController controller;

	public AnimationClip run;
	public AnimationClip idle;
	public AnimationClip attack;
	public AnimationClip die;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(!inRange()){
			chase();
			animation.CrossFade(run.name);
		}else{
			animation.CrossFade(idle.name);
		}

	}

	bool inRange(){
		return Vector3.Distance(transform.position, player.position) < range;
	}

	void chase(){
		transform.LookAt(player.position);
		controller.SimpleMove(transform.forward * speed);
	}


	void OnMouseOver(){
		Fighter fighter = player.GetComponent("Fighter") as Fighter;
		fighter.opponent = gameObject;
	}

}
