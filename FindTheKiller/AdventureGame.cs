using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                           //user interface
using UnityEngine.SceneManagement;                              //used for getting active scenes

public class AdventureGame : MonoBehaviour {

    [SerializeField] Text textComponent;                        //text box to fill from states
    [SerializeField] State startingState;                       //starting state room specific

     State state;                                               //create public blank state assignable from inspector
     List<string> items = new List<string>();                   //create a list of items for the room if necessary

	// Use this for initialization
	void Start () {
        state = startingState;                                  //set state to starting state
        textComponent.text = state.GetStateStory();             //call the get story method of the state object
	}
	
	// Update is called once per frame
	void Update () {
        ManageState();                                          //call manage frame each state
	}

    private void ManageState()
    {
        var nextStates = state.GetNextStates();                 //call get next states from the state objects
        textComponent.text = state.GetStateStory();             //set out text components text to the state story of the state object
        textComponent.fontSize = state.GetFontSize();           //set the font size from the state object
        if (Input.GetKeyDown(KeyCode.Alpha1))                   //if the input key is 1
        {
            if (state.GetReset())                               //if our current state is a reset scene
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload the current scene
            }
            state = nextStates[0];                              //get the next state at state 0
            if (state.HasCheck())                               //see if there is a condition to progress down choice 1
            {
                string item = state.GetCondition();             //get the item necessary to progress
                if (items.Contains(item))                       //see if the player has foudn the item in question
                    {
                        nextStates = state.GetNextStates();     //if so, call get next state
                        state = nextStates[1];                  //and progress
                    }
                else{                                           //otherwise we don't have that object
                    nextStates = state.GetNextStates();         //pull in the array of scenes 
                    state = nextStates[0];                      //load the reject message
                }
            }
            if (state.HasItem())                                //if there is an item in the room
            {
                items.Add(state.GetItem());                     //add that item to our inventory
            }
            textComponent.text = state.GetStateStory();         //set our text component to the current state story
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))              //if key input was 2
        {
            try                                                 //try to see if 2 is an available index
            {
                textComponent.text = state.GetStateStory();     //try to get the state
                state = nextStates[1];                          //if it works load in the state 
            }
            catch (IndexOutOfRangeException e)                  //else, catch indexoutofboundsexception
            {
                return;                                         //return without doing anything
            }
        }   
        else if (Input.GetKeyDown(KeyCode.Alpha3))              //if key input was 3
        {
            try                                                 //try to bring in selected state
            {
                textComponent.text = state.GetStateStory();     //get array of states
                state = nextStates[2];                          //get state 3
            }
            catch (IndexOutOfRangeException e)                  //catch indexoutofboundsexception if it's not possible
            {
                return;                                         //return without doing anything
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))              //if key input was 4
        {
            try                                                 //try to retrieve state 4
            {
                textComponent.text = state.GetStateStory();     //pull in array of states
                state = nextStates[3];                          //try to get state 4
            }
            catch (IndexOutOfRangeException e)                  //catch index out of bounds if 4 is not available
            {
                return;                                         //return
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))              //lastely if key input was 5
        {
            try                                                 //try to pull in state 5
            {
                textComponent.text = state.GetStateStory();     //pull in array on states
                state = nextStates[4];                          //pull in state 5
            }
            catch (IndexOutOfRangeException e)                  //catch index out of bounds exception if it's not possible
            {
                return;                                         //return
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))              //if the player chose to quit
        {
            Application.Quit();                                 //quit the game 
        }
    }
}
