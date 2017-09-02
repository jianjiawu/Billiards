using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlatzierenBall : MonoBehaviour {

    public GameObject WhiteBall;
    public Transform Table;
    public Transform Left;
    public Transform Top;
    public Transform Down;
    Vector3 TablePos;
    Vector3 TableLeftPos;
    Vector3 TableTopPos;
    Vector3 TableDownPos;
    bool bIsFirstPlatzieren = true;

    private void Start()
    {
        TablePos = Camera.main.WorldToScreenPoint(Table.position);
        //Vector3 pos = Left.TransformPoint(Left.position);
        TableLeftPos = Camera.main.WorldToScreenPoint(Left.position);
        TableTopPos = Camera.main.WorldToScreenPoint(Top.position);
        TableDownPos = Camera.main.WorldToScreenPoint(Down.position);
    }
    // Update is called once per frame
    void Update () {
        if(bIsFirstPlatzieren)
        {
            MouseController();
        }
	}

    void MouseController()
    { 
        if(Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x<(TablePos.x+TableLeftPos.x)/2 
                &&Input.mousePosition.x>TableLeftPos.x 
                &&Input.mousePosition.y>TableDownPos.y
                &&Input.mousePosition.y<TableTopPos.y)
            {
                WhiteBall.SetActive(true);
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                WhiteBall.transform.position = new Vector3(pos.x,0.5f,pos.z);
            }
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.mousePosition.x < (TablePos.x + TableLeftPos.x) / 2
                 && Input.mousePosition.x > TableLeftPos.x
                 && Input.mousePosition.y > TableDownPos.y
                && Input.mousePosition.y < TableTopPos.y)
            {
                WhiteBall.transform.position = new Vector3(pos.x, 0.5f, pos.z);
            }
            if (Input.mousePosition.x > (TablePos.x + TableLeftPos.x) / 2 
                && Input.mousePosition.y > TableDownPos.y
                && Input.mousePosition.y < TableTopPos.y)
            {
                WhiteBall.transform.position = new Vector3((Table.transform.position.x + Left.transform.position.x) / 2, 0.5f, pos.z);
            }
            if(Input.mousePosition.x < TableLeftPos.x
               && Input.mousePosition.y > TableDownPos.y
               && Input.mousePosition.y < TableTopPos.y)
            {
                WhiteBall.transform.position = new Vector3(Left.transform.position.x, 0.5f, pos.z);
            }
            if(Input.mousePosition.y < TableDownPos.y
                && Input.mousePosition.x < (TablePos.x + TableLeftPos.x) / 2
                && Input.mousePosition.x > TableLeftPos.x)
            {
                WhiteBall.transform.position = new Vector3(pos.x, 0.5f, Down.transform.position.z);
            }
            if(Input.mousePosition.y > TableTopPos.y
                && Input.mousePosition.x < (TablePos.x + TableLeftPos.x) / 2
                && Input.mousePosition.x > TableLeftPos.x)
            {
                WhiteBall.transform.position = new Vector3(pos.x, 0.5f, Top.transform.position.z);
            }
            Debug.Log(WhiteBall.transform.position);
        }
        if(Input.GetMouseButtonUp(0))
        {
            bIsFirstPlatzieren = false;
        }
    }
}
