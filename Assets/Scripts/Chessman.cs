using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    //References
    public GameObject controller;
    public GameObject movePlate;

    //Positions
    private int xBoard = -1;
    private int yBoard = -1;

    //Variable
    private string player;

    //References
    public Sprite Schaar;
    public Sprite Steen;
    public Sprite Papier;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag ("GameController");
        
        //take the initiated location and adjust the transform
        SetCoords();

        switch (this.name)
        {
            case "Steen": this.GetComponent<SpriteRenderer>().sprite = Steen; break;
            case "Papier": this.GetComponent<SpriteRenderer>().sprite = Papier; break;
            case "Schaar": this.GetComponent<SpriteRenderer>().sprite = Schaar; break;

        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 1.3f;
        y *= 1.3f;

        x += -1.95f;
        y += -1.95f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }
    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard( int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    private void OnMouseUp()
    {
        DestroyMovePlates();
        InitiateMovePlates();
        //call highlight method in game
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for(int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void InitiateMovePlates()
    {
        LineMovePlate(1, 0);
        LineMovePlate(0, 1);
        LineMovePlate(-1, 0);
        LineMovePlate(0, -1);
    }

    public void LineMovePlate(int xIncrement, int yIncrement)
    {
        Game sc = controller.GetComponent<Game>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

         while(sc.PositionOnBoard(x,y) &&sc.GetPosition(x,y) == null)
         {
             x += xIncrement;
             y += yIncrement;
            
        }

        if (sc.PositionOnBoard(x, y) && CanTake(sc.GetPosition(x, y).GetComponent<Chessman>()))
        {
           
            MovePlateAttackSpawn(x, y);
        }
    }

    void MovePlateAttackSpawn(int x, int y)
    {
        GameObject obj = Instantiate(movePlate, new Vector3(0, 0, -1), Quaternion.identity);
        MovePlate mp = obj.GetComponent<MovePlate>();
        mp.SetCoords(x, y);
        mp.SetReference(this.gameObject);
    }

    private bool CanTake(Chessman otherBlock)
    {
        if (this.name == otherBlock.name)
        {
            return false;
        }
        else if(this.name == "Steen" && otherBlock.name == "Schaar")
        {
            return true;
        }
        else if (this.name == "Papier" && otherBlock.name == "Steen")
        {
            return true;
        }
        else if (this.name == "Schaar" && otherBlock.name == "Papier")
        {
            return true;
        }
        return false;
    }
 }
