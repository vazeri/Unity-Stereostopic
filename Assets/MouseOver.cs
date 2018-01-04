//https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseOver.html

// Debe tener una cámara estereoscópica
    //Listo
// No es necesario que corra en algún visor VR (aunque sería muy bueno)
    //No cuento con un visor VR, pero puedo simularlo
// Debe correr directamente en Unity
    //Listo
// Debe poder usarse el mouse para mover la cámara
    //Listo
// Debe haber un cubo blanco con una textura básica en el centro de la escena
    //Listo, Cubo blanco con textura de cuadricula 
// Al mirar el cubo, este debe cambiar de color y de textura
    //Al centrar la camara se vuelve amarillo y se aplica una textura de tabiques

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moseover : MonoBehaviour
{
    //When the mouse hovers over the GameObject, it turns to this color (red)
    Color m_MouseOverColor = Color.yellow;
    //This stores the GameObject’s original color
    Color m_OriginalColor;
    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    MeshRenderer m_Renderer;
    
    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        m_Renderer = GetComponent<MeshRenderer>();
        //Fetch the original color of the GameObject
        m_OriginalColor = m_Renderer.material.color;
    }

    void OnMouseOver()
    {
        Debug.Log("El color del objeto es amarillo.");
        //Change the color of the GameObject to red when the mouse is over GameObject
        m_Renderer.material.color = m_MouseOverColor;
        //Replace texture

    }

    void OnMouseExit()
    {
        Debug.Log("El color del objeto es blanco.");
        //Reset the color of the GameObject back to normal
        m_Renderer.material.color = m_OriginalColor;
    }
}
