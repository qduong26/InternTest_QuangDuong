using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    GetScore getScore;
    public void OnDrop(PointerEventData eventData)
    {
        //Lấy đối tượng được kéo thả (pointerDrag) từ sự kiện kéo thả (eventData).

        GameObject dropped = eventData.pointerDrag;

        UIJewels UIjewels = dropped.GetComponent<UIJewels>();
        getScore = dropped.GetComponent<GetScore>();


        //Nếu slot không có child nào(tức ko có đá quý) 
        if (transform.childCount == 0)
        {
            //Set parent của đối tượng được kéo thả(pointerDrag) thành slot hiện tại, như vậy đá quý sẽ được đặt vào slot đó
            dropped.transform.SetParent(transform);

            //Cập nhật thuộc tính parentafterdrag của UIjewels để lưu lại slot hiện tại
            UIjewels.parentafterdrag = transform;
        }
        //Nếu slot đã có đá quý
        else
        {
            //Trao đổi vị trí 2 viên đá quý

            //Lấy ra đá quý hiện tại(tức đá quý đã có trước đó trong slot đang chỉ đến)
            GameObject current = transform.GetChild(0).gameObject;
            UIJewels currentDraggable = current.GetComponent<UIJewels>();
            GetScore getScore1 = current.GetComponent<GetScore>();


            //Set parent của đá quý hiện tại thành parentafterdrag của đối tượng được kéo thả(pointerDrag)
            currentDraggable.transform.SetParent(UIjewels.parentafterdrag);

            //Set parent của đối tượng được kéo thả(pointerDrag) thành slot hiện tại, như vậy đá quý sẽ được đặt vào slot đó
            dropped.transform.SetParent(transform);
            UIjewels.parentafterdrag = transform;

            //Check điểm số sau khi trao đổi vị trí của đá quý hiện tại(tức đá quý đã có trước đó trong slot đang chỉ đến)
            getScore1.Check();


        }
        //Check điểm số sau khi kéo thả đá quý cảu đá quý được kéo thả
        getScore.Check();

    }
}
