using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour {

    InputController playerInput;
    Vector2 mouseInput;
    [System.Serializable]
    public class MouseInput
    {
        public Vector2 damping;
        public Vector2 sensitivity;
        public bool lockMouse;
        
    }

    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] MouseInput mouseControl;

    private MoveController m_moveController;
    public MoveController moveController
    {
        get
        {
            if(m_moveController == null)
            {
                m_moveController = GetComponent<MoveController>();
            }
            return m_moveController;
            
        }
    }

    private Crosshair m_Crosshair;
    private Crosshair crosshair
    {
        get
        {
            if(m_Crosshair == null)
            {
                m_Crosshair = GetComponentInChildren<Crosshair>();
                
            }
            return m_Crosshair;
        }
    }


	void Awake () {
        playerInput = GameManagerTPS.instance.inputController;

        if(mouseControl.lockMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
	}

	void Update ()
    {
        Move();
        LookAround();
    }

    private void LookAround()
    {
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.mouseInput.x, 1f / mouseControl.damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.mouseInput.y, 1f / mouseControl.damping.y);
        transform.Rotate(Vector3.up * mouseInput.x * mouseControl.sensitivity.x);

        crosshair.LookHeight(mouseInput.y * mouseControl.sensitivity.y);
    }

    void Move()
    {
        float moveSpeed = walkSpeed;

        if (playerInput.isRunning)
            moveSpeed = runSpeed;

        Vector2 direction = new Vector2(playerInput.vertical * moveSpeed, playerInput.horizontal * moveSpeed);
        moveController.Move(direction);
    }
}
