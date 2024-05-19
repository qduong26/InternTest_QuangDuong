using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
using System.ComponentModel;

public class UIJewels : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //Biến lưu lại slot(GameObject cha) hiện tại của đá quý sau khi kéo thả
    [HideInInspector] public Transform parentafterdrag;
    Image image;

    void Start()
    {

        image = GetComponent<Image>();


    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Begin Drag");

        // Lưu lại đối tượng cha hiện tại của đối tượng đang kéo 

        parentafterdrag = transform.parent;

        //Đặt đối tượng đang kéo thành con trực tiếp của đối tượng gốc trong (scene)
        transform.SetParent(transform.root);

        // Đặt đối tượng đang kéo là con cuối cùng trong danh sách các con của đối tượng gốc để đảm bảo chắc chắn rằng nó sẽ hiển thị nằm trên tất cả các đối tượng khác(không bị các đối tượng khác đè lên)
        transform.SetAsLastSibling();

        //Tắt chức năng raycast của đối tượng đang kéo để không bị chạm vào khi kéo

        image.raycastTarget = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");

        //Di chuyển đối tượng theo vị trí của chuột
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End Drag");

        //Đặt lại parent của đối tượng sau khi kéo thành parentafterdrag(trả lại slot hay vị trí trước khi kéo của đá quý-đối tượng)

        transform.SetParent(parentafterdrag);

        //Kích hoạt lại khả năng nhận các tia raycast , giúp đối tượng có thể nhận các sự kiện khác sau khi thả
        image.raycastTarget = true;


    }

}
