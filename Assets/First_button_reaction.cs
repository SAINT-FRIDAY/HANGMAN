using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class First_button_reaction : MonoBehaviour
{
    public Scene Solo_level;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Goto_Solo_game()
    {
        SceneManager.LoadScene("Gaming_Screen");
    }
    public void Goto_Two_Players() {
        SceneManager.LoadScene("Entering_Word_Screen");
    }
}
