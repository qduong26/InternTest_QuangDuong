using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    // Các slot xung quanh theo thứ tự trên,dưới,trái phải của slot hiện tại
    GameObject slotabove;
    GameObject slotbelow;
    GameObject slotright;
    GameObject slotleft;

    //Điểm số
    static int point = 0;

    CheckAndRespawn checkAndRespawnJewels;

    public GameObject coin;
    GameObject canvas;


    //Số lượng child của slot xung quanh(nếu giá trị = 0 tức là slot đang trống không có đá quý nào và ngược lại =1 là đang có 1 đá quý trong đó)
    int slotabovechild;
    int slotbelowchild;
    int slotrightchild;
    int slotleftchild;
    TextMeshProUGUI score;
    private void Start()
    {
        checkAndRespawnJewels = GetComponentInParent<CheckAndRespawn>();
        canvas = checkAndRespawnJewels.canvas;
        score = checkAndRespawnJewels.score;
    }

    public void Check()
    {

        for (int i = 0; i < GetSlot.slot.Length; i++)
        {
            //Duyệt qua GetSlot.slot để xác định slot hiện tại
            if (GetSlot.slot[i] == gameObject.transform.parent.gameObject)
            {


                //Debug.Log("Checking" + GetSlot.slot[i]);
                CheckPosition(i);




            }

        }
        score.text = ("Score: " + point.ToString());


        //Check xem còn đá quý nào không nếu không thì sinh ra đá quý mới
        checkAndRespawnJewels.checkandrespawn();
    }
    void CheckPosition(int i)
    {

        Debug.Log("Checking Position" + "" + i);
        //Xét điều kiện để xác định slot xung quanh và số lượng child của slot đó

        // Xét i>=6(do đây là ma trận 6x6) để tránh trường hợp lỗi out of index
        if (i >= 6)
        {
            slotabove = GetSlot.slot[i - 6];
            slotabovechild = slotabove.transform.childCount;
        }
        //Xét i<=GetSlot.slot.Length - 7(do đây là ma trận 6x6 và i bắt đầu từ 0(i max=35,slot.length=36) nên là GetSlot.slot.Length - 6 - 1) để tránh trường hợp lỗi out of index
        if (i <= GetSlot.slot.Length - 7)
        {
            slotbelow = GetSlot.slot[i + 6];
            slotbelowchild = slotbelow.transform.childCount;

        }
        //Xét i<=GetSlot.slot.Length -2(GetSlot.slot.Length - 1 - 1) để tránh trường hợp lỗi out of index
        if (i <= GetSlot.slot.Length - 2)
        {
            slotright = GetSlot.slot[i + 1];
            slotrightchild = slotright.transform.childCount;
        }
        //Xét i>=1 để tránh trường hợp lỗi out of index
        if (i >= 1)
        {
            slotleft = GetSlot.slot[i - 1];

            slotleftchild = slotleft.transform.childCount;
        }


        //Kiểm tra xem slot xung quanh có đá quý không nếu có thì so sánh với đá quý hiện tại nếu trùng thì xóa cả 2 và tăng điểm


        //Xét điều kiện slot phải không null(tức tồn tại, trường hợp out of index thì slot sẽ null) và điều kiện slot phải có child(nếu không có child tức là slot đó không có đá quý)
        if (slotabove != null && slotabovechild != 0)
        {

            Image jewelabove = slotabove.transform.GetChild(0).gameObject.GetComponent<Image>();
            if (jewelabove.sprite == GetComponent<Image>().sprite)
            {
                Destroy(gameObject);
                Destroy(jewelabove.gameObject);
                point++;

                //Xác định vị trí coin được sinh ra khi ăn điểm bằng cách chuyển đổi vị trí của 2 viên đá quý sang sang không gian màn hình (screen space) và lấý giá trị trung bình của position(vị trí chính giữa) của 2 viên đá quý

                Vector2 coinPosition = (RectTransformUtility.WorldToScreenPoint(Camera.main, gameObject.transform.position) + RectTransformUtility.WorldToScreenPoint(Camera.main, jewelabove.transform.position)) / 2;
                //Chuyển vị trí coin từ screen space sang local space của canvas
                RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
                Vector2 localPosition;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, coinPosition, Camera.main, out localPosition);
                //Sinh ra coin
                GameObject Coin = Instantiate(coin);
                //Set parent cho coin là canvas
                Coin.transform.SetParent(canvas.transform, false);
                Coin.GetComponent<RectTransform>().localPosition = localPosition;
            }
        }
        //tương tự
        if (slotbelow != null && slotbelowchild != 0)
        {

            Image jewelbelow = slotbelow.transform.GetChild(0).gameObject.GetComponent<Image>();
            if (jewelbelow.sprite == this.gameObject.GetComponent<Image>().sprite)
            {
                Destroy(gameObject);
                Destroy(jewelbelow.gameObject);
                point++;
                Vector2 coinPosition = (RectTransformUtility.WorldToScreenPoint(Camera.main, gameObject.transform.position) + RectTransformUtility.WorldToScreenPoint(Camera.main, jewelbelow.transform.position)) / 2;
                RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
                Vector2 localPosition;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, coinPosition, Camera.main, out localPosition);
                GameObject Coin = Instantiate(coin);
                Coin.transform.SetParent(canvas.transform, false);
                Coin.GetComponent<RectTransform>().localPosition = localPosition;

            }
        }
        //tương tự
        if (slotright != null && slotrightchild != 0)
        {

            Image jewelright = slotright.transform.GetChild(0).gameObject.GetComponent<Image>();
            if (jewelright.sprite == GetComponent<Image>().sprite)
            {

                Destroy(gameObject);
                Destroy(jewelright.gameObject);
                point++;
                Vector2 coinPosition = (RectTransformUtility.WorldToScreenPoint(Camera.main, gameObject.transform.position) + RectTransformUtility.WorldToScreenPoint(Camera.main, jewelright.transform.position)) / 2;
                RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
                Vector2 localPosition;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, coinPosition, Camera.main, out localPosition);
                GameObject Coin = Instantiate(coin);
                Coin.transform.SetParent(canvas.transform, false);
                Coin.GetComponent<RectTransform>().localPosition = localPosition;

            }
        }
        //tương tự
        if (slotleft != null && slotleftchild != 0)
        {

            Image jewelleft = slotleft.transform.GetChild(0).gameObject.GetComponent<Image>();
            if (jewelleft.sprite == GetComponent<Image>().sprite)
            {

                Destroy(gameObject);
                Destroy(jewelleft.gameObject);
                point++;
                Vector2 coinPosition = (RectTransformUtility.WorldToScreenPoint(Camera.main, gameObject.transform.position) + RectTransformUtility.WorldToScreenPoint(Camera.main, jewelleft.transform.position)) / 2;
                RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
                Vector2 localPosition;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, coinPosition, Camera.main, out localPosition);
                GameObject Coin = Instantiate(coin);
                Coin.transform.SetParent(canvas.transform, false);
                Coin.GetComponent<RectTransform>().localPosition = localPosition;
            }
        }
    }

}
