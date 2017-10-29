using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    private Map map;
    private States state;
    public Text CongradMessage;
    int last_player;

	void Start () {
        map = new Map();
        state = States.FirstPlayerTurn;
        CongradMessage.enabled = false;
	}

    public void MakeMove(Button button){
        string[] pos_string = EventSystem.current.currentSelectedGameObject.name.Split(' ');
        int[] pos = new int[2] { int.Parse(pos_string[0]), int.Parse(pos_string[1])};

        if (state == States.FirstPlayerTurn)
        {
            map.UpdateMap(pos, Moves.X);
            button.GetComponentInChildren<Text>().text = "X";

            if (map.IsGameFinished())
            {
                last_player = 0;
                state = States.Celebrate;
            }
            else
                state = States.SecondPlayerTurn;
        }

        else if (state == States.SecondPlayerTurn)
        {
            map.UpdateMap(pos, Moves.O);
            button.GetComponentInChildren<Text>().text = "O";

            if (map.IsGameFinished())
            {
                last_player = 1;
                state = States.Celebrate;
            }
            else
                state = States.FirstPlayerTurn;
        }
        if (state == States.Celebrate)
        {
            if (last_player == 0)
            {
                CongradMessage.text = "First Player Win";
                CongradMessage.enabled = true;
            }
            if (last_player == 1)
            {
                CongradMessage.text = "Second Player Win";
                CongradMessage.enabled = true;
            }
        }
    }

    public void loadMenu()
    {
        
    }
}
