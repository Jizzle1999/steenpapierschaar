using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    private string blockName;
    private int Xpos;
    private int Ypos;

    public Block(string name, int Xpos, int Ypos)
    {
        this.blockName = name;
        this.Xpos = Xpos;
        this.Ypos = Ypos;

    }

    public string GetName()
    {
        return blockName;
    }

    public int GetXpos()
    {
        return Xpos;
    }

    public int GetYpos()
    {
        return Ypos;
    }
} 
