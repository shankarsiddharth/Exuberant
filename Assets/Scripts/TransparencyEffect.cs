using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Platform.Samples.VrBoardGame;
using UnityEngine;

public class TransparencyEffect : MonoBehaviour
{
    
    public GameObject CanvasToShow;
    
    public ECollectibles CollectibleType;
    
    
    GameObject CanvasObject;
    
    void Start()
    {
        PopulateCanvasToShow();
    }
    
    void Update()
    {
        OVRGrabbable grabbable = GetComponent<OVRGrabbable>();
        if(grabbable != null)
        {
            if (grabbable.isGrabbed)
            {
                float axisValue = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
                if (Math.Abs(axisValue - 1.0f) < 0.1f)
                {
                    if (gameObject.activeSelf)
                    {
                        CanvasToShow.SetActive(false);
                        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
                        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
                        gameObject.SetActive(false);
                    }
                }
            }
        }
        
    }

    private void PopulateCanvasToShow()
    {
        if (CanvasObject == null)
        {
            CanvasObject = GameObject.FindWithTag("Canvas");
        }

        if (CanvasObject != null)
        {
            foreach (Transform child in CanvasObject.transform)
            {
                PanelType pt = child.GetComponent<PanelType>();
                if (pt != null)
                {
                    if (CollectibleType == pt.CollectibleType)
                    {
                        CanvasToShow = pt.gameObject;
                    }
                }
            }
        }
    }


    public AudioSource babyAudio;
    private bool isBabyLaughing = false;

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("MainCamera"))
        {
            if (CanvasToShow != null)
            {
                if (!CanvasToShow.activeSelf)
                {
                    CanvasToShow.SetActive(true);
                }
            }
            float dis = (transform.position - other.transform.position).magnitude;

            if (this.gameObject.name.Contains("Cradle"))
            {
                if (!isBabyLaughing)
                {
                    if (dis < 2)
                    {
                        isBabyLaughing = true;
                        babyAudio.clip = Resources.Load<AudioClip>("baby laughing");
                        //babyAudio.Stop();
                        babyAudio.Play();
                    }
                }
            }

            if (transform.GetComponent<MeshRenderer>() != null)
            {
                MeshRenderer meshRenderer = transform.gameObject.GetComponent<MeshRenderer>();

                if (meshRenderer != null)
                {
                    foreach (Material m in meshRenderer.materials)
                    {
                        Color co = m.color;
                        if (dis >= 3)//&& co.a != 1)
                        {
                            Debug.Log("greater than 3");
                            m.color = new Color(co.r, co.g, co.b, 1 - dis * 0.10f);
                        }
                        else if (dis < 3)
                        {
                            Debug.Log("less than 3");
                            m.color = new Color(co.r, co.g, co.b, 1);
                        }
                    }
                }
            }
            foreach (Transform child in transform)
            {
                Debug.Log("Child Name: " + child.gameObject.name);
                //child is your child transform
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                {

                    foreach (Material m in meshRenderer.materials)
                    {
                        Color co = m.color;
                        if (dis >= 3)//&& co.a != 1)
                        {
                            Debug.Log("greater than 3");
                            m.color = new Color(co.r, co.g, co.b, 1 - dis * 0.10f);
                        }
                        else if (dis < 3)
                        {
                            Debug.Log("less than 3");
                            m.color = new Color(co.r, co.g, co.b, 1);
                        }
                    }         
                }
            }
        }

        //if (other.tag == "MainCamera")
        //{
        //    Debug.Log("Collision detected....");
        //    float dis = (transform.position - other.transform.position).magnitude;
        //    Debug.Log("dis : " + dis);
        //    Color co = gameObject.GetComponent<MeshRenderer>().material.color;
        //    if (dis >= 3 )//&& co.a != 1)
        //    {
        //        Debug.Log("greater than 3");
        //        gameObject.GetComponent<MeshRenderer>().material.color = new Color(co.r, co.g, co.b, 1 - dis * 0.10f);
        //    }
        //    else if (dis < 3)
        //    {
        //        Debug.Log("less than 3");
        //        gameObject.GetComponent<MeshRenderer>().material.color = new Color(co.r, co.g, co.b, 1);
        //    }
        //}

    }
}