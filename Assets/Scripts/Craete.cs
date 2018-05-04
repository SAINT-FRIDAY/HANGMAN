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

public class Craete : MonoBehaviour
{


    public GameObject Blank;
    public GameObject Canvas;
    public List<GameObject> fields;
    private int mistakes_made;
    private int correct_letters;
    private bool[] flag;
    public Sprite[] myTextures = new Sprite[33];
    private string working_object;
    //public Change_viselitsa temp;
    public GameObject ChangeViselitsa;

    public Text text_field;
    public Image image_bacground;
    public Button perehod;
    // Use this for initialization
    void Start()
    {

        //string conn = "URI=file:" + Application.dataPath + "/words.db";
        //IDbConnection dbconn = (IDbConnection)new SqliteConnection(conn);
        //dbconn.Open();
        //IDbCommand dbcmd = dbconn.CreateCommand();
        //string sqlQuery = "SELECT Word FROM AllWords LIMIT 1 OFFSET 19";
        //dbcmd.CommandText = sqlQuery;
        //IDataReader reader = dbcmd.ExecuteReader();
        //Debug.Log(reader.GetString(0));

        mistakes_made = 0;
        correct_letters = 0;
        text_field.enabled = false;
        image_bacground.enabled = false;
        perehod.gameObject.SetActive(false);
        //temp = new Change_viselitsa();
        string working_object2;
        System.Random rnd = new System.Random();
        // int random_word_number = rnd.Next(2, 2263875);  //Стара БД

        int random_word_number = rnd.Next(2, 81733);
        // string _constr = "URI=file:words.db";
        string _constr = "URI=file:" + Application.dataPath + "/words.db"; //Path to database.
        IDbConnection _dbc;
        IDbCommand _dbcm;
        IDataReader _dbr;
        _dbc = new SqliteConnection(_constr);
        _dbc.Open();
        _dbcm = _dbc.CreateCommand();
        _dbcm.CommandText = "SELECT `Word` FROM `AllWords` LIMIT 1 OFFSET " + random_word_number;
        _dbr = _dbcm.ExecuteReader();
        working_object2 = "";
        while (_dbr.Read())
        {
            working_object = _dbr.GetString(0);
        }
        Debug.Log(random_word_number);


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
                GameObject blank = Instantiate(Blank, new Vector3(0 - j * Blank.transform.localScale.x - Blank.transform.localScale.x / 2, 0), Quaternion.identity) as GameObject;
                blank.transform.SetParent(Canvas.transform, false);
                //blank.transform.localScale = GameObject.Find("Button").transform.lossyScale;


                //blank.transform.localScale = GameObject.Find("Button").transform.position;
                fields.Add(blank);
            }
            for (int i = working_object.Length / 2, j = 0; i < working_object.Length; i++, j++)
            {
                // GameObject blank = Instantiate(Blank, new Vector2(0 + j * 50 + (float)50, 0), Quaternion.identity) as GameObject;
                // blank.transform.SetParent(Canvas.transform, false);
                GameObject blank = Instantiate(Blank, new Vector3(0 + j * Blank.transform.localScale.x + Blank.transform.localScale.x / 2, 0), Quaternion.identity) as GameObject;
                blank.transform.SetParent(Canvas.transform, false);
                fields.Add(blank);
            }
        }
        else  //Якщо непарна
        {
            for (int i = 0, j = working_object.Length / 2 - 1; i < working_object.Length / 2; i++, j--)
            {
                GameObject blankleft = Instantiate(Blank, new Vector2(0 - j * Blank.transform.localScale.x - Blank.transform.localScale.x, 0), Quaternion.identity) as GameObject;
                blankleft.transform.SetParent(Canvas.transform, false);
                fields.Add(blankleft);
            }
            GameObject blank = Instantiate(Blank, new Vector2(0, 0), Quaternion.identity) as GameObject;
            blank.transform.SetParent(Canvas.transform, false);
            fields.Add(blank);
            for (int i = working_object.Length / 2 + 1, j = 1; i < working_object.Length; i++, j++)
            {
                GameObject blankright = Instantiate(Blank, new Vector2(0 + j * Blank.transform.localScale.x, 0), Quaternion.identity) as GameObject;
                blankright.transform.SetParent(Canvas.transform, false);
                fields.Add(blankright);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

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
        Debug.Log(text[0]);
        status = check_letter(text[0]);
        if (status) {
            //correct_letters++;
            if (correct_letters == working_object.Length) {
                this.Finish_Line_Correct();
            }
        }
        else if (!status)
        {
            mistakes_made++;
            if (mistakes_made == 1)
            {
                Change_viselitsa temp = ChangeViselitsa.GetComponent<Change_viselitsa>();
                temp.UpdateToOneMistake();
            }
            if (mistakes_made == 2)
            {
                Change_viselitsa temp = ChangeViselitsa.GetComponent<Change_viselitsa>();
                temp.UpdateToTwoMistakes();
            }
            if (mistakes_made == 3)
            {
                Change_viselitsa temp = ChangeViselitsa.GetComponent<Change_viselitsa>();
                temp.UpdateToThreeMistakes();
            }
            if (mistakes_made == 4)
            {
                Change_viselitsa temp = ChangeViselitsa.GetComponent<Change_viselitsa>();
                temp.UpdateToFourMistakes();
            }
            if (mistakes_made == 5)
            {
                Change_viselitsa temp = ChangeViselitsa.GetComponent<Change_viselitsa>();
                temp.UpdateToFiveMistakes();
            }
            if (mistakes_made == 6)
            {
                Change_viselitsa temp = ChangeViselitsa.GetComponent<Change_viselitsa>();
                temp.UpdateToSixMistakes();
                this.Finish_Line_Incorrect();
            }
        }
        Debug.Log("Mistakes:" + mistakes_made.ToString()+" Correct:"+correct_letters.ToString());
    }
    public void set_buttons_uninterectable()
    {
        Button[] buttons = Canvas.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }
    public void Finish_Line_Incorrect()
    {
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
            Destroy(child.gameObject);
        }
        text_field.enabled = true;
        image_bacground.enabled = true;
        perehod.gameObject.SetActive(true);
    }
    public void Finish_Line_Correct() {
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
            Destroy(child.gameObject);
        }
        text_field.text = "Ви виграли";
        text_field.enabled = true;
        image_bacground.enabled = true;
        perehod.gameObject.SetActive(true);
    }

}
