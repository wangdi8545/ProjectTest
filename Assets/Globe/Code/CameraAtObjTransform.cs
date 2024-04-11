using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAtObjTransform : MonoBehaviour
{

    public Transform target;

    public float rotaSpeed = 5;
    public float sizeOff = 5f;

    public float dis = 1.5f;
    public float minDis, maxDis;



    void Start()
    {
        
    }


    Vector3 upMousePos;
    Vector3 mousePos;
    Vector3 endPos;
    void Update()
    {
        if (target)
        {
            if (Input.GetMouseButtonDown(0))
            {
                upMousePos = Input.mousePosition;
            }else if (Input.GetMouseButton(0))
            {
                mousePos = Input.mousePosition;
                endPos = mousePos - upMousePos;
                upMousePos = mousePos;

                if (endPos.magnitude > 0)
                {
                    Vector3 posDis = endPos / endPos.magnitude;
                    endPos = posDis * -1;
                    endPos = endPos / endPos.magnitude * Time.deltaTime * rotaSpeed;


                    transform.Translate(endPos);
                }
            }



            #region æ‡¿Î
            


            Vector3 objPos = transform.position;

            this.dis += Input.mouseScrollDelta.y*-sizeOff*Time.deltaTime;
            this.dis = Mathf.Clamp(this.dis, minDis, maxDis);
            
            Vector3 dis = objPos-target.position;
            dis = dis.normalized*this.dis;
            transform.position = target.position + dis;
            
            transform.LookAt(target, transform.up);
            #endregion
        }
    }
}
