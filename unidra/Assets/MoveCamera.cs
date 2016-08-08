using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

    float speedH = 3f;
    float speedV = 3f;

    float yaw = 0f;
    float pitch = 0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        //if (Input.GetKey(KeyCode.LeftArrow)) {
        //    transform.Translate(new Vector3(-1.0f, 0f, 0f));
        //}
        //if (Input.GetKey(KeyCode.RightArrow)) {
        //    transform.Translate(new Vector3(1.0f, 0f, 0f));
        //}
        //if (Input.GetKey(KeyCode.UpArrow)) {
        //    transform.Translate(new Vector3(0.0f, 0f, 1f));
        //}
        //if (Input.GetKey(KeyCode.DownArrow)) {
        //    transform.Translate(new Vector3(0.0f, 0f, -1f));
        //}

//        yaw += speedH * Input.GetAxis("Mouse X");
//        pitch -= speedV * Input.GetAxis("Mouse Y");
//        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
