using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float walkingSpeed = 3f;
    public float runningSpeed = 6f;
    public float jumpSpeed = 5f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    private QTEManager _qteManager;
    private bool isQTEActive = false;
    bool isLookingAtObject = false;

    public static int matches = 0;
    public int Matches { 
        get { return matches; } 
        set { matches = value; }
    }

    public CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;


    public static event Action<bool> isLookingAtInteractiveObj; // ������� ��� ���������
    private LayerMask rayMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        rayMask = LayerMask.GetMask("Interactable");

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void FindQTE() 
    {
        _qteManager = GameObject.FindWithTag("QTEManager").GetComponent<QTEManager>();
        if (_qteManager != null)
        {
            _qteManager.StartQTEEvent += StartQTE;
            _qteManager.EndQTEEvent += StopQTE;
            Debug.Log("������� �������");
        }
    }

    void Update()
    {
            
        if (_qteManager == null)
        {
            FindQTE();
            Debug.Log("������ ���");
        }
        if (isQTEActive)
        {
            return; // ����� �� ����� ��������� ��� ������� ������
        }
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        RaycastingToObjects();
            
    }
    void StartQTE()
    {
        isQTEActive = true;
        Debug.Log("������� ��������");
    }
    void StopQTE()
    {
        isQTEActive = false;
        Debug.Log("������� �����������");
    }

    void RaycastingToObjects()
    {
        //�������� �� ��������� �� ������
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        TogglePointLight lightCol = null;
        MatchBox _matchBox = null;
        DoorController _door = null;
        Debug.Log(isLookingAtObject);
        if (Physics.Raycast(ray, out hit, 0.6f, rayMask))
        {
            Debug.Log(hit.transform.name);
            //Debug.Log("��� �������: " + hit.transform.name);
            if (hit.transform.name == "Point Light")
            {
                lightCol = hit.transform.GetComponent<TogglePointLight>();
                isLookingAtObject = true;
                isLookingAtInteractiveObj?.Invoke(true);
            }
            if(hit.transform.name == "Matchbox_01")
            {
                _matchBox = hit.transform.GetComponent<MatchBox>();
                isLookingAtObject = true;
                isLookingAtInteractiveObj?.Invoke(true);
            }
            if (hit.transform.name == "Door")
            {
                _door = hit.transform.GetComponent<DoorController>();
                isLookingAtObject = true;
                isLookingAtInteractiveObj?.Invoke(true);
            }
            //else
            //{
            //    isLookingAtObject = false;
            //    isLookingAtInteractiveObj?.Invoke(false);
            //}
        }
        else
        {
            isLookingAtObject = false;
            isLookingAtInteractiveObj?.Invoke(false);
        }

        if (isLookingAtObject && Input.GetKeyDown(KeyCode.E))
        {
            if (hit.transform.name == "Matchbox_01")
            {
                matches += _matchBox.MatchesInBox;

                Destroy(hit.transform.gameObject);

                _matchBox.soundManager.PlayRandomMatchPickUp();
            }
            if (hit.transform.name == "Point Light")
            {
                if (lightCol.Condition == false)
                {
                    if (matches >= 1)
                    {
                        lightCol.ToggleLightOn();
                        matches -= 1;
                        //Debug.Log(PlayerController.matches);
                    }
                }
                else
                {
                    lightCol.ToggleLightOff();
                }
            }
            if (hit.transform.name == "Door")
            {
                _door.ToggleDoor();
            }

        }
    }

}
    

