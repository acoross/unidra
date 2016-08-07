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


        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
