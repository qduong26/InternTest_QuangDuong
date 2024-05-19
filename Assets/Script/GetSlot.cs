using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSlot : MonoBehaviour
{
    GameObject parentObject;


    //List các slot trên grid
    public static GameObject[] slot;



    void Start()
    {
        parentObject = this.gameObject;
        slot = getSlot(parentObject);

    }



    //Trả về list các slot(child object) trên grid
    GameObject[] getSlot(GameObject parent)
    {
        int childCount = parent.transform.childCount;
        GameObject[] children = new GameObject[childCount];


        for (int i = 0; i < childCount; i++)
        {
            children[i] = parent.transform.GetChild(i).gameObject;
        }

        return children;
    }
}
