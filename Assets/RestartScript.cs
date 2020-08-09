using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject controller;

    // Update is called once per frame
    public void restartlevel()
    {
        controller.GetComponent<Game>().ResetPositions();
    }
}
