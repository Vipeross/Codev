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

    public PlayerAim playerAim;

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

        Vector3 targetDir = crosshair.transform.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        //playerAim.SetRotation(mouseInput.y * mouseControl.sensitivity.y);
        playerAim.SetRotation(angle, crosshair.transform.position.y);



        //crosshair.LookHeight(mouseInput.y * mouseControl.sensitivity.y);
        crosshair.transform.Translate(new Vector3(0, mouseInput.y, 0));
        
        //Mathf.Clamp(crosshair.transform.position.y, -40, 40);
        //crosshair.transform.Translate(new Vector3(0, crosshair.LookHeight(mouseInput.y), 0));
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
