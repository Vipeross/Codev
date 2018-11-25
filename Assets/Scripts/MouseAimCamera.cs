using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimCamera : MonoBehaviour {
    public GameObject player;
    public float rotateSpeed = 5;
    public float verticalOffset = 1;
    private Vector3 standardOffsetAngle;
    private Vector3 aimOffsetAngle;
    private Vector3 standardOffset;
    private Vector3 aimOffset;
    private Vector3 currentAngleOffset;
    private Vector3 currentOffset;
	// Use this for initialization
	void Start () {
        standardOffset = player.transform.position - transform.position;
        aimOffset = standardOffset + new Vector3(0,0,-3);
        standardOffsetAngle = new Vector3(0, verticalOffset, 0);
        aimOffsetAngle = standardOffsetAngle + new Vector3(0, 0.8f, 0);
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        player.transform.Rotate(0, horizontal, 0);

        float desiredAngle = player.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);

        if (Input.GetMouseButton(1))
        {
            currentOffset = aimOffset;
            currentAngleOffset = aimOffsetAngle;
        }
        else
        {
            
            currentOffset = standardOffset;
            currentAngleOffset = standardOffsetAngle;
            
        }


        transform.position = player.transform.position - (rotation * currentOffset);
        transform.LookAt(player.transform.position + currentAngleOffset);
       
	}
}
