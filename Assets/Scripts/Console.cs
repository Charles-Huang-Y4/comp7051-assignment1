using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    //command list
    private static readonly string[] command =
    {
        "help",
        "cls",
        "test"
    };


    private static int position = -1;

    //console history
    private static List<string> consoleHistory = new List<string>();

    

}
