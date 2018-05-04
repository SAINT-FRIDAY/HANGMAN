using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using System.Text;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class FirstCanvasForm : MonoBehaviour
{

    int mistakes_made;
    int correct_letters;
    private string working_object;
    private bool[] flag;
    public List<GameObject> fields;
    public Sprite[] myTextures = new Sprite[33];
    public GameObject Canvas;
    public GameObject Blank;
    public int player;
    public GameObject ChangeViselitsa;
    public Button Main_menu;
    public GameObject to_locate;


    void Start()
    {
        mistakes_made = 0;
        correct_letters = 0;
        //text_field.enabled = false;
        //image_bacground.enabled = false;
        //perehod.gameObject.SetActive(false);
        //temp = new Change_viselitsa();
        string working_object2;
        //System.Random rnd = new System.Random();
        //int random_word_number = rnd.Next(2, 2263875);
        // string _constr = "URI=file:words.db";
        //string _constr = "URI=file:" + Application.dataPath + "/words.db"; //Path to database.
        //IDbConnection _dbc;
        //IDbCommand _dbcm;
        //IDataReader _dbr;
        //_dbc = new SqliteConnection(_constr);
        //_dbc.Open();
        //_dbcm = _dbc.CreateCommand();
        //_dbcm.CommandText = "SELECT `Word` FROM `AllWords` LIMIT 1 OFFSET " + random_word_number;
        //_dbr = _dbcm.ExecuteReader();
        //working_object2 = "";
        //while (_dbr.Read())
        //{
        //    working_object = _dbr.GetString(0);
        //}
        //Debug.Log(random_word_number);
        //working_object = TwoPlayerWords.firstplayerword;
        //working_object = "корова";
        TwoPlayerWords.flag1 = false;
        TwoPlayerWords.flag2 = false;
        if (player == 1)
        {
             working_object = TwoPlayerWords.firstplayerword;
           // working_object = "Відро";
        }
        if (player == 2)
        {
             working_object = TwoPlayerWords.secondplayerword;
           // working_object = "олександр";
        }

       
        Debug.Log(working_object.Length);
        // working_object = "ВІҐРО";
        working_object = working_object.ToUpper();
        Debug.Log(working_object.ToString());
        flag = new bool[working_object.Length];
        fields = new List<GameObject>();
        for (int i = 0; i < working_object.Length; i++)
        {
            flag[i] = false;
        }
        if (working_object.Length % 2 == 0) //Парна кількість букв 
        {
            for (int i = 0, j = working_object.Length / 2 - 1; i < working_object.Length / 2; i++, j--)
            {
                //GameObject blank = Instantiate(Blank, new Vector2(0 - j - (float)1, 0), Quaternion.identity,Canvas.transform) as GameObject;
                GameObject blank = Instantiate(Blank, new Vector3(0 - j * Blank.transform.localScale.x - Blank.transform.localScale.x / 2, -Blank.transform.localScale.y), Quaternion.identity) as GameObject;
                blank.transform.SetParent(Canvas.transform, false);
                //to_locate.transform.localPosition = new Vector3(to_locate.transform.localPosition.x, to_locate.transform.localPosition.y + blank.transform.localScale.y*2,to_locate.transform.localRotation.z);
                //blank.transform.localScale = GameObject.Find("Button").transform.lossyScale;


                //blank.transform.localScale = GameObject.Find("Button").transform.position;
                fields.Add(blank);
            }
            for (int i = working_object.Length / 2, j = 0; i < working_object.Length; i++, j++)
            {
                // GameObject blank = Instantiate(Blank, new Vector2(0 + j * 50 + (float)50, 0), Quaternion.identity) as GameObject;
                // blank.transform.SetParent(Canvas.transform, false);
                GameObject blank = Instantiate(Blank, new Vector3(0 + j * Blank.transform.localScale.x + Blank.transform.localScale.x / 2, -Blank.transform.localScale.y), Quaternion.identity) as GameObject;
                blank.transform.SetParent(Canvas.transform, false);
               // to_locate.transform.localPosition = new Vector3(to_locate.transform.localPosition.x, to_locate.transform.localPosition.y + blank.transform.localScale.y*2, to_locate.transform.localRotation.z);
                fields.Add(blank);
            }
        }
        else  //Якщо непарна
        {
            for (int i = 0, j = working_object.Length / 2 - 1; i < working_object.Length / 2; i++, j--)
            {
                GameObject blankleft = Instantiate(Blank, new Vector2(0 - j * Blank.transform.localScale.x - Blank.transform.localScale.x, -Blank.transform.localScale.y), Quaternion.identity) as GameObject;
                blankleft.transform.SetParent(Canvas.transform, false);
                fields.Add(blankleft);
            }
            GameObject blank = Instantiate(Blank, new Vector2(0, -Blank.transform.localScale.y), Quaternion.identity) as GameObject;
            blank.transform.SetParent(Canvas.transform, false);
            fields.Add(blank);
            for (int i = working_object.Length / 2 + 1, j = 1; i < working_object.Length; i++, j++)
            {
                GameObject blankright = Instantiate(Blank, new Vector2(0 + j * Blank.transform.localScale.x, -Blank.transform.localScale.y), Quaternion.identity) as GameObject;
                blankright.transform.SetParent(Canvas.transform, false);
                fields.Add(blankright);
            }
        }
        to_locate.transform.localPosition = new Vector3(to_locate.transform.localPosition.x, fields[0].transform.localPosition.y + Math.Abs(fields[0].transform.localScale.y), to_locate.transform.localRotation.z);
    }
    void Update()
    {
        if (TwoPlayerWords.flag1 && TwoPlayerWords.flag2)
        {
            Main_menu.gameObject.SetActive(true);
        }
    }
    private bool check_letter(char letter)
    {
        bool found_letter = false;
        for (int i = 0; i < working_object.Length; i++)
        {
            if (working_object[i] == letter)
            {
                //replacement = fields[i].GetComponent<Transform>();
                for (int j = 0; j < myTextures.Length; j++)
                {
                    if (myTextures[j].name[0] == letter)
                    {
                        fields[i].GetComponent<SpriteRenderer>().sprite = myTextures[j];
                        found_letter = true;
                        correct_letters++;
                        fields[i].layer = 8;
                    }
                }
                flag[i] = true;
            }
        }
        return found_letter;
    }
    public void OnClickA()
    {
        bool status;
        GameObject working_button = EventSystem.current.currentSelectedGameObject;
        char[] text = new char[10];
        text = working_button.GetComponentInChildren<Text>().text.ToCharArray();
        working_button.GetComponent<Button>().interactable = false;
        if (text[0] == ' ')
        {
            text[0] = text[1];
        }
        status = check_letter(text[0]);
        if (status)
        {
            //correct_letters++;
            Debug.Log(correct_letters.ToString());
            if (correct_letters == working_object.Length)
            {
                if (player == 1)
                {
                    TwoPlayerWords.flag1 = true;
                }
                else if (player == 2)
                {
                    TwoPlayerWords.flag2 = true;
                }
                this.DestroyLetters();
            }
        }
        else if (!status) {
            mistakes_made++;
            if (mistakes_made == 1) {
                 ChangeViselitsaByCanvas temp =  ChangeViselitsa.GetComponent<ChangeViselitsaByCanvas>(); ;
                temp.UpdateToOneMistake();
            }
            if (mistakes_made == 2)
            {
                ChangeViselitsaByCanvas temp = ChangeViselitsa.GetComponent<ChangeViselitsaByCanvas>(); ;
                temp.UpdateToTwoMistakes();
            }
            if (mistakes_made == 3)
            {
                ChangeViselitsaByCanvas temp = ChangeViselitsa.GetComponent<ChangeViselitsaByCanvas>(); ;
                temp.UpdateToThreeMistakes();
            }
            if (mistakes_made == 4)
            {
                ChangeViselitsaByCanvas temp = ChangeViselitsa.GetComponent<ChangeViselitsaByCanvas>(); ;
                temp.UpdateToFourMistakes();
            }
            if (mistakes_made == 5)
            {
                ChangeViselitsaByCanvas temp = ChangeViselitsa.GetComponent<ChangeViselitsaByCanvas>(); ;
                temp.UpdateToFiveMistakes();
            }
            if (mistakes_made == 6)
            {
                ChangeViselitsaByCanvas temp = ChangeViselitsa.GetComponent<ChangeViselitsaByCanvas>(); ;
                temp.UpdateToSixMistakes();
                if (player == 1)
                {
                    TwoPlayerWords.flag1 = true;
                }
                else if (player == 2) {
                    TwoPlayerWords.flag2 = true;
                }
                this.DestroyLetters();
            }
        }
    }
    public void DestroyLetters() {
        char[] text = new char[10];
        bool status = false;
        foreach (Button child in Canvas.GetComponentsInChildren<Button>())
        {
            if (child.IsActive() == true)
            {
                text = child.GetComponentInChildren<Text>().text.ToCharArray();
                if (text[0] == ' ')
                {
                    text[0] = text[1];
                }
                status = check_letter(text[0]);
            }
            if (child.name != "Perehod")
            {
                Destroy(child.gameObject);
            }
        }
    }
}