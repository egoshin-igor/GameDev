using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public GameObject hoverButton;

    private void Start()
    {
        hoverButton.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
        hoverButton.GetComponent<Renderer>().material.color = Color.black;
    }

    void OnMouseEnter()
    {
        hoverButton.GetComponent<Renderer>().material.color = Color.red;
    }

    void OnMouseExit()
    {
        hoverButton.GetComponent<Renderer>().material.color = Color.black;
    }
}
