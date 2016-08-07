using UnityEngine;
using System.Collections;

public class MoveRigitObject : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Vector3 force = new Vector3(-1.0f, 0f, 0f);
            GetComponent<Rigidbody>().AddForce(force);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            Vector3 force = new Vector3(1.0f, 0f, 0f);
            GetComponent<Rigidbody>().AddForce(force);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 force = new Vector3(0.0f, 0f, 100f);
            GetComponent<Rigidbody>().AddForce(force);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            Vector3 force = new Vector3(0.0f, 0f, -1f);
            GetComponent<Rigidbody>().AddForce(force);
        }
    }
}
