using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;

    GameObject reference = null;
    
    // board positions not world positions
   [SerializeField] int matrixX;
   [SerializeField] int matrixY;

 

    public void Start()
    {
     
            //change to red
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
       

    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");



        controller.GetComponent<Game>().RemoveBlock(matrixX, matrixY);

        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<Chessman>().GetXBoard(),
            reference.GetComponent<Chessman>().GetYBoard());

        reference.GetComponent<Chessman>().SetXBoard(matrixX);
        reference.GetComponent<Chessman>().SetYBoard(matrixY);
        reference.GetComponent<Chessman>().SetCoords();

        controller.GetComponent<Game>().SetPosition(reference);

        reference.GetComponent<Chessman>().DestroyMovePlates();

        controller.GetComponent<Game>().Checkblockwin();
    }

    public void SetCoords(int newX, int newY)
    {
        matrixX = newX;
        matrixY = newY;
        float x = newX;
        float y = newY;

        x *= 1.3f;
        y *= 1.3f;

        x += -1.95f;
        y += -1.95f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }

   
}