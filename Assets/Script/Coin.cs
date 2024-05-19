using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //di chuyển coin lên trên
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, transform.position + transform.up * 2, 85 * Time.deltaTime);
    }
    public void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
