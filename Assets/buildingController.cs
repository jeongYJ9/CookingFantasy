using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class buildingController : MonoBehaviour
{

    const float minMoveDist = 3;
    const float xFlipSnap = 30;

    public float YmoveSpeed;

    Vector3 inputStartPos;
    int isXrot;
    bool startTouch;
    float dragStartRotY;
    Vector3 dragStartPos;


    // Start is called before the first frame update
    void Start()
    {
        YmoveSpeed = 8.0f;
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
                    //todo 여기서 tween 으로 90도의 배수가 되도록 회전시켜야함
                    if (moveX > 0)
                        transform.DORotate(new Vector3(0, dragStartRotY+90,0),0.5f);
                        //transform.rotation = Quaternion.Euler (new Vector3 (0, dragStartRotY + 90, 0));
                    else
                        transform.DORotate(new Vector3(0, dragStartRotY - 90, 0), 0.5f);
                        //transform.rotation = Quaternion.Euler (new Vector3 (0, dragStartRotY - 90, 0));
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

    // Update is called once per frame
    void Update(){
        CheckMouseEvent();

       

    }





}
