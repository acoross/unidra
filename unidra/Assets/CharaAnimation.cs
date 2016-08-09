using UnityEngine;
using System.Collections;

public class CharaAnimation : MonoBehaviour {

	Animator animator;
	CharacterStatus status;
	Vector3 prePosition;
	bool didAttack = false;
	bool isDown = false;

	public bool DidAttack () {
		return didAttack;
	}

	void StartAttackHit () {
		Debug.Log ("StartAttackHit");
	}

	void EndAttackHit () {
		Debug.Log ("EndAttackHit");
	}

	void EndAttack () {
		didAttack = true;
	}

	void Start () {
		animator = GetComponent<Animator> ();
		status = GetComponent<CharacterStatus> ();
		prePosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		Vector3 delta_position = transform.position - prePosition;
		Debug.Log ((delta_position.magnitude / Time.deltaTime).ToString ());
		animator.SetFloat ("Speed", delta_position.magnitude / Time.deltaTime);

		if (didAttack && !status.attacking) {
			didAttack = false;
		}

		animator.SetBool ("Attacking", (!didAttack && status.attacking));

		if (!isDown && status.died) {
			isDown = true;
			animator.SetTrigger ("Down");
		}

		prePosition = transform.position;
	}
}
