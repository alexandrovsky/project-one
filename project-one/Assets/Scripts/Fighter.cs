using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {

	public AnimationClip attack;

	public GameObject opponent;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.Space)){

			transform.LookAt(opponent.transform.position);

			animation.Play(attack.name);
			ClickToMove.attack = true;
		}else if(!animation.IsPlaying(attack.name)){
			ClickToMove.attack = false;
		}
	}
}
