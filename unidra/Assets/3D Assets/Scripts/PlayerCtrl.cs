using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {
	const float RayCastMaxDistance = 100.0f;
	CharacterStatus status;
	CharaAnimation charaAnimation;
	public Transform attackTarget;

	InputManager inputManager;
	public float attackRange = 1.5f;

	public enum State {
		Walking,
		Attacking,
		Died
	}

	public State state = State.Walking;
	State nextState = State.Walking;

	// Use this for initialization
	void Start () {
		status = GetComponent<CharacterStatus> ();
		charaAnimation = GetComponent<CharaAnimation> ();
		inputManager = FindObjectOfType<InputManager>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case State.Walking:
			Walking ();
			break;
		case State.Attacking:
			Attacking ();
			break;
		}

		if (state != nextState) {
			state = nextState;
			switch (state) {
			case State.Walking:
				WalkStart ();
				break;
			case State.Attacking:
				AttackStart ();
				break;
			case State.Died:
				Died ();
				break;
			}
		}
	}

	void ChangeState(State nextState) {
		this.nextState = nextState;
	}

	void WalkStart() {
		StateStartCommon ();
	}

	void Walking()
	{
		if (inputManager.Clicked()) {
			// RRayCast로 대상물을 조사한다.
			Vector2 clickPos = inputManager.GetCursorPosition();
			Ray ray = Camera.main.ScreenPointToRay(clickPos);
			RaycastHit hitInfo;

			if(Physics.Raycast(ray,out hitInfo, 
								RayCastMaxDistance,
								(1 << LayerMask.NameToLayer("Ground")) |
								(1 << LayerMask.NameToLayer("EnemyHit")))) {

				// 지면이 클릭
				if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
					SendMessage("SetDestination", hitInfo.point);

				if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer ("EnemyHit")) {
					float distance = Vector3.Distance (hitInfo.point, transform.position);
					if (distance < attackRange) {
						attackTarget = hitInfo.collider.transform;
						ChangeState (State.Attacking);
					} else {
						SendMessage ("SetDestination", hitInfo.point);
					}
				}
			}
		}

	}

	void AttackStart() {
		StateStartCommon ();
		status.attacking = true;

		Vector3 targetDirection = (attackTarget.position - transform.position).normalized;
		SendMessage ("SetDirection", targetDirection);

		SendMessage ("StopMove");
	}

	void Attacking() {
		if (charaAnimation.DidAttack ())
			ChangeState (State.Walking);
	}

	void Died() {
		status.died = true;
	}

	void Damage(AttackArea.AttackInfo attackInfo) {
		status.HP -= attackInfo.attackPower;
		if (status.HP <= 0) {
			status.HP = 0;

			ChangeState (State.Died);
		}
	}

	void StateStartCommon() {
		status.attacking = false;
		status.died = false;
	}
}
