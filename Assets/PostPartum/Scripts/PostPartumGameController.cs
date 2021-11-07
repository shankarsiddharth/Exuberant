using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PostPartumGameController : MonoBehaviour
{
    public GameObject CanvasObject;
    
    // Start is called before the first frame update
    void Start()
    {
        if (CanvasObject == null)
        {
            CanvasObject = GameObject.FindWithTag("Canvas");
        }
        if (CanvasObject != null)
        {
            CanvasObject.GetComponent<PostPartum.Scripts.CanvasController>().HideAllCanvasImages();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Test");
    }
}
