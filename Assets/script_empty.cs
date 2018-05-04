using System.Collections;
using System.Collections.Generic;
//using System.Media;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class script_empty : MonoBehaviour {
    public Canvas firstplayer;
    public Canvas secondplayer;
	// Use this for initialization
	void Start () {
       // Debug.Log(TwoPlayerWords.firstplayerword.ToString());
       // Debug.Log(TwoPlayerWords.secondplayerword.ToString());
        firstplayer.gameObject.SetActive(true);
        secondplayer.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
       
	}
    public void GoToFirstCanvas() {
        firstplayer.gameObject.SetActive(true);
        secondplayer.gameObject.SetActive(false);
    }
    public void GoToSecondCanvas() {
        firstplayer.gameObject.SetActive(false);
        secondplayer.gameObject.SetActive(true);
    }
}
