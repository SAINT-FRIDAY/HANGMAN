using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using System.Media;
using UnityEngine.SceneManagement;



public class Letter_Validation : MonoBehaviour 
{
    public InputField InputField1;
    public InputField InputField2;
    public Button button;
    bool flag1_correct, flag2_correct;
    bool if_is_over_1,if_is_over_2;
	// Use this for initialization
	void Start () {
        flag1_correct = false;
        flag2_correct = false;
        if_is_over_1 = false;
        if_is_over_2 = false;
       
        button.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (flag1_correct && flag2_correct) {
            button.interactable = true;
        }
	}
    public void Check_First_Field() {
        string pattern = @"^[ЯЧСМИТЬБЮЄЖДЛОРПАВІФЙЦУКЕНГШЩЗХЇҐ]+$";
        if (Regex.IsMatch(InputField1.text.ToUpper(), pattern))
        {

            //new Color32(71, 255, 133, 255);
            flag1_correct = true;
            InputField1.GetComponent<Image>().color = new Color32(7, 255, 133, 255);
            Debug.Log("Correct");
        }
        else {
            //InputField1.GetComponent<Image>().color = Color.red;
            flag1_correct = false;
            InputField1.GetComponent<Image>().color = new Color32(158, 17, 21, 255);
            Debug.Log("Incoorect");
        }
    }
    public void Check_Second_Field() {
        string pattern = @"^[ЯЧСМИТЬБЮЄЖДЛОРПАВІФЙЦУКЕНГШЩЗХЇҐ]+$";
        if (Regex.IsMatch(InputField2.text.ToUpper(), pattern))
        {

            //new Color32(71, 255, 133, 255);
            flag2_correct = true;
            InputField2.GetComponent<Image>().color = new Color32(7, 255, 133, 255);
            Debug.Log("Correct");
        }
        else
        {
            //InputField1.GetComponent<Image>().color = Color.red;
            flag2_correct = false;
            InputField2.GetComponent<Image>().color = new Color32(158, 17, 21, 255);
            Debug.Log("Incoorect");
        }
    }
    void SetWordsForBothPlayers() {
        TwoPlayerWords.Firstplayerword = InputField1.text;
        TwoPlayerWords.Secondplayerword = InputField2.text;
    }
    public void GoToTwoPLayersGame() {
        this.SetWordsForBothPlayers();
        SceneManager.LoadScene("Two_players_screen");
    }

}
