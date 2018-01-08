using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CubeListener : MonoBehaviour 
{
    public Texture TSB1;
    Texture m_OriginalColor;

    void Start()
    {
        m_OriginalColor = GetComponent<Renderer>().material.mainTexture;

    }

    public void MyPointerEnter () 
	{
	    GetComponent<Renderer>().material.color = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), 1.0f);
        GetComponent<Renderer>().material.mainTexture = (Texture)Resources.Load("TSB1");
    }

    public void MyPointerLeave ()
	{
        GetComponent<Renderer>().material.color = Color.white;
        GetComponent<Renderer>().material.mainTexture = m_OriginalColor;

    }
}
