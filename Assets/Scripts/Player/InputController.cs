using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public float vertical;
    public float horizontal;
    public Vector2 mouseInput;
    public bool fire1;
    public bool reload;
    public bool isRunning;

    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        fire1 = Input.GetButton("Fire1");
        reload = Input.GetKey(KeyCode.R);
        isRunning = Input.GetKey(KeyCode.LeftShift);
    }
}
