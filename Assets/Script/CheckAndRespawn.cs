using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckAndRespawn : MonoBehaviour
{
    [SerializeField] private GameObject[] jewels;
    public GameObject canvas;

    public TextMeshProUGUI score;
    void Start()
    {

    }


    void Update()
    {

    }
    public void checkandrespawn()
    {
        //Kiểm tra xem nếu không có viên đá nào(tức childcount =0) thì sẽ duyệt list prefebs jewels và sinh ra 1 cặp viên đá cùng loại mỗi lần duyệt
        if (gameObject.transform.childCount == 0)
        {
            Debug.Log("Respawning Jewels");
            for (int i = 0; i < jewels.Length; i++)
            {
                Instantiate(jewels[i], transform.position, Quaternion.identity).transform.SetParent(gameObject.transform, false);

                Instantiate(jewels[i], transform.position, Quaternion.identity).transform.SetParent(gameObject.transform, false);
            }
        }
    }

}
