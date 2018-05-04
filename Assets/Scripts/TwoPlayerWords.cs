using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerWords  {

    public static string firstplayerword { get; set; }
    public static string secondplayerword { get; set; }
    public static bool flag1 { get; set; }
    public static bool flag2 { get; set; }


    //public void setfirstplayerword(string s) {
    //    firstplayerword = s;
    //}
    //public void setsecondplayerword(string s) {
    //    secondplayerword = s;
    //}
    public static string Firstplayerword
    {
        get
        {
            return firstplayerword;
        }
        set
        {
            firstplayerword = value;
        }
    }
    public static string Secondplayerword
    {
        get
        {
            return secondplayerword;
        }
        set
        {
            secondplayerword = value;
        }
    }
    public static bool Flag1
    {
        get
        {
            return flag1;
        }
        set
        {
            flag1 = value;
        }
    }
    public static bool Flag2
    {
        get
        {
            return flag2;
        }
        set
        {
            flag2 = value;
        }
    }
}
