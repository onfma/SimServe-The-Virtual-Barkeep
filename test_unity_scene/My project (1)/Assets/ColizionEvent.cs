using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UI;

public class ColizionEvent : MonoBehaviour
{
    public int contor=0;

    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 24;

        GUI.Label(new Rect(Screen.width - 120, 10, 200, 30), "Scor: " + this.contor, style);
    }


    public void Increment()
    {
        this.contor++;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name.StartsWith("Apple"))
        {
            Increment();
            Debug.Log("Collision detected with: " + collision.gameObject.name);
        }
    }
}
