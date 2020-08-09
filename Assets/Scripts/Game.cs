using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private int maxBlocks = 16;
    public int round = 1;
    public GameObject chessPiece;

    //positions an team for each chesspiece

    public Block[][] roundPositions = new Block[3][];

    private GameObject[,] positions = new GameObject[4, 4];
    private ArrayList blocks = new ArrayList();
    private GameObject highlightedBlock = new GameObject();


    private bool gameWon = false;

    // Start is called before the first frame update
    void Start()
    {
        roundPositions[0] = new Block[] { new Block("Schaar", 1, 0), new Block("Steen", 1, 1), new Block("Papier", 0, 0), null, null, null, null, null, null, null, null, null, null, null, null, null, };
        roundPositions[1] = new Block[] { new Block("Schaar", 3, 0), new Block("Steen", 3, 1), new Block("Papier", 3, 2), null, null, null, null, null, null, null, null, null, null, null, null, null, };
        roundPositions[2] = new Block[] { new Block("Schaar", 3, 3), new Block("Steen", 0, 3), new Block("Papier", 0, 0), new Block("Papier", 3, 0), null, null, null, null, null, null, null, null, null, null, null, null, };
        //functions (paremetor1, paremetor2)


        ResetPositions();

    }
    public GameObject Create(Block newBlock)
    {
        GameObject obj = Instantiate(chessPiece, new Vector3(0, 0, -1), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>();
        cm.name = newBlock.GetName();
        cm.SetXBoard(newBlock.GetXpos());
        cm.SetYBoard(newBlock.GetYpos());
        cm.Activate(); //
        return obj;

    }

    //highlight method 
    //zet de highlight van de current highlicghted op inactive
    //zet de highlight cvan de parameter block op active
    //zet parameterblock als nieuwe current highlighted

    public void ResetPositions()
    {
        RemoveAllBlocks();
        positions = new GameObject[4, 4];


        for (int i = 0; i < maxBlocks; i++)
        {
            if (i <= 2)
            {
                blocks.Add(Create(roundPositions[round - 1][i])); //basicly loads new blocks
            }


        }


        for (int i = 0; i < blocks.Count; i++)
        {
            SetPosition(blocks[i] as GameObject);
        }

    }

   


    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();

        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }




    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }




    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

    public void Checkblockwin () //checks if position matches coordiantes
    {
      
        if (blocks.Count <= 1)
        {
            gameWon = true;
            round++;
           
            ResetPositions();
            
        }
       
    }
    public void SetRemoveBLocks()
    {
        RemoveAllBlocks();
    }
    private void RemoveAllBlocks()
    {
        foreach (GameObject block in blocks.ToArray())
        {
            RemoveBlock(block.GetComponent<Chessman>().GetXBoard(), block.GetComponent<Chessman>().GetYBoard());
        }
    }

    public void RemoveBlock(int matrixX, int matrixY)
    {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);
        blocks.Remove(cp);
        Destroy(cp);
    }
}

