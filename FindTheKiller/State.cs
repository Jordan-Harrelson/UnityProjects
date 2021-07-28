using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject                           //able to make objects out of this class
{

    [TextArea(10, 14)] [SerializeField] string storyText;       //create a textbox that you can put custom text into
    [SerializeField] State[] nextStates;                        //an array of states connected to this object
    [SerializeField] bool hasCheck;                             //has next state check
    [SerializeField] string condition;                          //item needed for progression
    [SerializeField] bool hasItem;                              //check if the room has an item
    [SerializeField] string item;                               //return said item if so
    [SerializeField] bool reset;                                //I don't remember what this does...
    [SerializeField] int fontsize;                              //set the fontsize

    public string GetStateStory()
    {
        return storyText;                                       //return textbox text
    }

    public State[] GetNextStates()
    {
        return nextStates;                                      //return array of states
    }

    public bool HasCheck()
    {
        return hasCheck;                                        //return hascheck
    }

    public string GetCondition()
    {
        return condition;                                       //return room condition
    }

    public bool HasItem()
    {
        return hasItem;                                         //check if room has item
    }

    public string GetItem()                                     //get item from room
    {
        return item;
    }

    public void SetItemCheck(bool set)
    {
        hasItem = set;                                         //set item in room to false once taken
    }

    public bool GetReset()
    {
        return reset;                                          //return reset
    }

    public int GetFontSize()
    {
        return fontsize;                                       //return fontsize
    }
}
