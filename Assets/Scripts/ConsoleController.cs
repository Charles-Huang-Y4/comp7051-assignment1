using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleController : MonoBehaviour
{
    private InputField inputField = null;
    private Text outputext = null;

    // Start is called before the first frame update
    void Start()
    {
        inputField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        //get input text
        string input = inputField.text;


        //press "enter"
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!input.Equals(""))
            {
                outputext.text += ">>" + input + "\n";
                /*string output = Console.Input(input);
                if (output != null)
                {
                    // clean console
                    if (output.Equals("cls"))
                        outputext.text = "";
                    else
                        outputext.text += output + "\n";
                }
                inputField.text = "";*/
            }

        }

        //go back to last command 
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //inputField.text = Console.Last();
        }

        // go forward to next command
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //inputField.text = Console.Next();
        }
            
        inputField.ActivateInputField();


    }
    
}
