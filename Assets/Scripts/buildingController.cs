using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class buildingController : MonoBehaviour
{
    GameObject Manager;
    
    private int RoomType;
    private int tempRoomType;

    const float minMoveDist = 3;
    const float xFlipSnap = 30;

    private bool TouchLock = false;
    private float TouchLockTime;
    public float XmoveSpeed;
    public float YmoveSpeed;

    Vector3 inputStartPos;
    int isXrot;
    bool startTouch;
    float dragStartRotY;
    Vector3 dragStartPos;


    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("Manager");
        RoomType = Manager.GetComponent<baseSceneManager>().GetRoomType();
        tempRoomType = RoomType;
    }

    void StartDrag(){
        startTouch = true;
        dragStartRotY = transform.eulerAngles.y;
        dragStartPos = transform.position;
        isXrot = 0;
        inputStartPos = Input.mousePosition;
    }

    void EndDrag(){
        // inputStartPos = new Vector3(0);
        startTouch = false;
        float moveDist = Vector3.Distance( inputStartPos , Input.mousePosition);
        isXrot = 0;
        if( moveDist < minMoveDist) {
            Debug.Log("TOUCH EVENT");
           
        }

        if (RoomType == tempRoomType)
        {
            dragStartRotY = transform.eulerAngles.y;
            if (45 <= dragStartRotY && dragStartRotY < 135)
                dragStartRotY = 90;
            else if (135 <= dragStartRotY && dragStartRotY < 225)
                dragStartRotY = 180;
            else if (225 <= dragStartRotY && dragStartRotY < 315)
                dragStartRotY = 270;
            else if (315 <= dragStartRotY && dragStartRotY < 405)
                dragStartRotY = 0;
            else if (-45 <= dragStartRotY && dragStartRotY < 45)
                dragStartRotY = 0;
            transform.DORotate(new Vector3(0, dragStartRotY, 0), XmoveSpeed);
        }
        tempRoomType = RoomType;

        TouchLock = true;

    }

    void CheckMouseEvent(){
        if (Input.GetMouseButtonDown(0)){
            StartDrag();
        }


        if (Input.GetMouseButtonUp(0)){
            EndDrag();
        }


        if ( startTouch == false ){
            return;
        }

        if (Input.GetMouseButton(0))
        {
            float moveDist = Vector3.Distance( inputStartPos , Input.mousePosition);
            float moveX = inputStartPos.x - Input.mousePosition.x;
            float moveY = inputStartPos.y - Input.mousePosition.y;
            if( moveDist < minMoveDist) {
                // Debug.Log("TOUCH EVENT");
                
                return;
            }

            if( isXrot == 0 ) {
                if( Mathf.Abs(moveX) > Mathf.Abs(moveY))
                    isXrot = 1;
                else 
                isXrot = 2;
            }




            if( isXrot == 1 ){
                Debug.Log( moveDist );
                transform.rotation = Quaternion.Euler (new Vector3 (0, dragStartRotY + moveX / 4, 0));
                if( Mathf.Abs(moveX / 4) > xFlipSnap) {
                   
                    if (moveX > 0&& RoomType <4)
                    {
                        transform.DORotate(new Vector3(0, dragStartRotY + 90, 0), XmoveSpeed);
                        RoomType++;
                        MenuChanger();
                    }
                        
                    else if(moveX < 0 && RoomType >1)
                    {
                        transform.DORotate(new Vector3(0, dragStartRotY - 90, 0), XmoveSpeed);
                        RoomType--;
                        MenuChanger();
                    }
                    else
                    {
                        transform.DORotate(new Vector3(0, dragStartRotY, 0), XmoveSpeed);
                    }
                    EndDrag();

                    
                }
            }
            else {
                float movePosY = dragStartPos.y - moveY / YmoveSpeed;
                if ( movePosY > 0 )
                    movePosY = 0;
                transform.position = new Vector3( dragStartPos.x , movePosY, dragStartPos.z);
            }
        }
    }

    void MenuChanger()
    {
        if (RoomType < 1)
            RoomType = 1;
        else if (RoomType > 4)
            RoomType = 4;
        Manager.GetComponent<baseSceneManager>().MenuChanger(RoomType);
    }

    // Update is called once per frame
    void Update(){
        if(TouchLock == false)
        {
            CheckMouseEvent();
        }
        else if (TouchLock ==true)
        {
            TouchLockTime += Time.deltaTime;

        }
       
        if(TouchLockTime > XmoveSpeed)
        {
            TouchLockTime = 0;
            TouchLock = false;
        }

        
       

    }





}
