using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerController : Updateable
{
    public CinemachineVirtualCamera virtualCamera;
    public Transform cameraLookAtTarget;
    public float moveSpeed = 50f;
    public float rotateSpeed = 150f;
    public float dragPanSpeed = 2f;
    public float zoomSpeed = 20f;
    public Vector2 followOffsetMinMax = new Vector2(5f, 50f);
    public Vector2 rotateMinMaxAngle = new Vector2(15f, 80f);

    private bool dragPanMoveActive;
    private bool dragRotateActive;
    private Vector2 lastMousePosition;
    private Vector3 followOffset;

    private GameController gameController;
    private float mainCameraXRotOffset = 0;

    private SelectController selectController;

    private bool isShiftDown = false;

    private void Awake()
    {
        followOffset = virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
    }
    
    new void Start()
    {
        mainCameraXRotOffset = Camera.main.transform.eulerAngles.x;
        base.Start();
        gameController = getGameController();
        GameObject selectcontrollerGo = GameObject.Find("SelectController");
        selectController = selectcontrollerGo.GetComponent<SelectController>();
        addToTimeController();
    }

    new void Update()
    {
        base.Update();
    }

    /// <summary>
    /// Pause/Unpause the game
    /// </summary>
    public void Pause()
    {
        gameController.TogglePause();
    }

    public override void update()
    {
        // Sets the mouse cursor to the correct icon
        selectController.Hover(Input.mousePosition);

        MoveCamera();
        MoveCameraDragPan();
        RotateCamera();
        ZoomCamera();
        
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isShiftDown = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            isShiftDown = false;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(isShiftDown)
            {
                // Shift select
                selectController.Click(Input.mousePosition, SelectController.ClickType.ShiftLeftClick);
            }
            else
            {
                // Normal Select
                selectController.Click(Input.mousePosition, SelectController.ClickType.LeftClick);
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            selectController.Click(Input.mousePosition, SelectController.ClickType.RightClick);
        }
    }

    public void MoveCamera()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) inputDir.z = +1;
        if (Input.GetKey(KeyCode.S)) inputDir.z = -1;
        if (Input.GetKey(KeyCode.A)) inputDir.x = -1;
        if (Input.GetKey(KeyCode.D)) inputDir.x = +1;

        Vector3 moveDir = cameraLookAtTarget.transform.forward * inputDir.z + cameraLookAtTarget.transform.right * inputDir.x;
        cameraLookAtTarget.transform.position += moveDir * moveSpeed * followOffset.y * Time.deltaTime;
    }

    private void MoveCameraDragPan()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);

        if (Input.GetMouseButtonDown(1))
        {
            dragPanMoveActive = true;
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1))
        {
            dragPanMoveActive = false;
        }

        if (dragPanMoveActive)
        {
            Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - lastMousePosition;

            inputDir.x = mouseMovementDelta.x * dragPanSpeed;
            inputDir.z = mouseMovementDelta.y * dragPanSpeed;

            lastMousePosition = Input.mousePosition;
        }

        Vector3 moveDir = cameraLookAtTarget.transform.forward * inputDir.z + cameraLookAtTarget.transform.right * inputDir.x;
        cameraLookAtTarget.transform.position += moveDir * moveSpeed * followOffset.y * Time.deltaTime;
    }

    private void RotateCamera()
    {
        float rotateDir = 0f;
        if(Input.GetKey(KeyCode.Q)) rotateDir = +1f;
        if(Input.GetKey(KeyCode.E)) rotateDir = -1f;


        Vector2 dragRotateDir = new Vector2(0, 0);
        if (Input.GetMouseButtonDown(2))
        {
            dragRotateActive = true;
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(2))
        {
            dragRotateActive = false;
        }
        if (dragRotateActive)
        {
            Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - lastMousePosition;

            dragRotateDir.x = mouseMovementDelta.x;
            dragRotateDir.y = mouseMovementDelta.y;

            lastMousePosition = Input.mousePosition;
        }
        Vector3 newEulerAngles = cameraLookAtTarget.eulerAngles + new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0) + new Vector3(-dragRotateDir.y * rotateSpeed * Time.deltaTime, dragRotateDir.x * rotateSpeed * Time.deltaTime, 0);

        float xAngle = (newEulerAngles.x + mainCameraXRotOffset) % 360f;
        if (xAngle >= rotateMinMaxAngle.x && xAngle <= rotateMinMaxAngle.y) 
        {
            // TODO: maybe use Mathf.Clamp here
            cameraLookAtTarget.eulerAngles = new Vector3(newEulerAngles.x,newEulerAngles.y,newEulerAngles.z);
        }
    }

    private void ZoomCamera()
    {
        Vector3 zoomDir = followOffset.normalized;
        if(Input.mouseScrollDelta.y > 0)
        {
            followOffset -= zoomDir;
        }
        if(Input.mouseScrollDelta.y < 0)
        {
            followOffset += zoomDir;
        }

        if(followOffset.magnitude < followOffsetMinMax.x)
        {
            followOffset = zoomDir * followOffsetMinMax.x;
        }
        if(followOffset.magnitude > followOffsetMinMax.y)
        {
            followOffset = zoomDir * followOffsetMinMax.y;
        }

        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = 
            Vector3.Lerp(virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, followOffset, zoomSpeed * Time.deltaTime);
    }
}
