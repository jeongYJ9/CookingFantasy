using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class baseSceneManager : MonoBehaviour
{
    //ViewModel로 베이스 씬 담당한다.

    public int RoomType;//(숙소 1, 홀2, 식당3, 숙소4, 룸 타입에 따라 Bottom UI가 교체된다.)
    public int tempRoomType;

    public GameObject Menu_Kitchen;
    public GameObject Menu_Hall;
    public GameObject Menu_Restaurant;
    public GameObject Menu_Hostel;

    public GameObject EventMsg_text;
    public string eventMessage;
    // Start is called before the first frame update
    void Start()
    {
        Menu_Kitchen = GameObject.Find("Menu_Kitchen");
        Menu_Hall = GameObject.Find("Menu_Hall");
        Menu_Restaurant = GameObject.Find("Menu_Restaurant");
        Menu_Hostel = GameObject.Find("Menu_Hostel");
        EventMsg_text = GameObject.Find("EventMsg_text");

        RoomType = 2;
        tempRoomType = RoomType;


        Menu_Kitchen.SetActive(false);
        Menu_Restaurant.SetActive(false);
        Menu_Hostel.SetActive(false);

    }

    public void BtnWorker()
    {
        switch (RoomType)
        {
            case 1:
                EventMsg_text.GetComponent<Text>().text = "주방 영역에서 직원버튼누름";
                break;
            case 2:
                EventMsg_text.GetComponent<Text>().text = "홀 영역에서 직원버튼누름";
                break;
            case 3:
                EventMsg_text.GetComponent<Text>().text = "식당 영역에서 직원버튼누름";
                break;
            case 4:
                EventMsg_text.GetComponent<Text>().text = "숙소 영역에서 직원버튼누름";
                break;
        }
    }
    public void BtnBuild()
    {
        switch (RoomType)
        {
            case 1:
                EventMsg_text.GetComponent<Text>().text = "주방 영역에서 건물버튼누름";
                break;
            case 2:
                EventMsg_text.GetComponent<Text>().text = "홀 영역에서 건물버튼누름";
                break;
            case 3:
                EventMsg_text.GetComponent<Text>().text = "식당 영역에서 건물버튼누름";
                break;
            case 4:
                EventMsg_text.GetComponent<Text>().text = "숙소 영역에서 건물버튼누름";
                break;
        }
    }
    public void BtnGuest()
    {
        switch (RoomType)
        {
            case 1:
                EventMsg_text.GetComponent<Text>().text = "주방 영역에서 손님버튼누름";
                break;
            case 2:
                EventMsg_text.GetComponent<Text>().text = "홀 영역에서 손님버튼누름";
                break;
            case 3:
                EventMsg_text.GetComponent<Text>().text = "식당 영역에서 손님버튼누름";
                break;
            case 4:
                EventMsg_text.GetComponent<Text>().text = "숙소 영역에서 손님버튼누름";
                break;
        }
    }
  
    public int GetRoomType()
    {
        return RoomType;
    }

    public void MenuChanger(int _RoomType)
    {
        RoomType = _RoomType;
        if (tempRoomType != RoomType)
        {
            switch(RoomType)
            {
                case 1:
                    Menu_Kitchen.SetActive(true);
                    break;
                case 2:
                    Menu_Hall.SetActive(true);
                    break;
                case 3:
                    Menu_Restaurant.SetActive(true);
                    break;
                case 4:
                    Menu_Hostel.SetActive(true);
                    break;
            }
            switch (tempRoomType)
            {
                case 1:
                    Menu_Kitchen.SetActive(false);
                    break;
                case 2:
                    Menu_Hall.SetActive(false);
                    break;
                case 3:
                    Menu_Restaurant.SetActive(false);
                    break;
                case 4:
                    Menu_Hostel.SetActive(false);
                    break;
            }
        }
        tempRoomType = RoomType;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }


}
