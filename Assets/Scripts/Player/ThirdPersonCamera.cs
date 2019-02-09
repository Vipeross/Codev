using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float damping;
    public Transform crosshair;
    Transform cameraLookTarget;
    private Player player;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        cameraLookTarget = player.transform.Find("cameraLookTarget");

        if (cameraLookTarget == null)
        {
            cameraLookTarget = player.transform;
        }
    }

	
	// Update is called once per frame
	void Update () {
        Vector3 targetposition = cameraLookTarget.position + player.transform.forward * cameraOffset.z + new Vector3(0,-crosshair.position.y,0) * cameraOffset.y + player.transform.right * cameraOffset.x;
        
        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetposition, Vector3.up);

        transform.position = targetposition;
        transform.LookAt(crosshair);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);

    }
}
