using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{

    public int current_screen_area = 0;
	public int old_screen_area = 0;
	public int mouse_down = 0;
	public int top_l_zone = 1;
	public int top_r_zone = 2;
	public int bot_l_zone = 3;
	public int bot_r_zone = 4;
	public int top_l_state,top_r_state,bot_l_state,bot_r_state;
	public int top_l_state_old,top_r_state_old,bot_l_state_old,bot_r_state_old;
    public int north,south,east,west;
    public int dv,mv;
    public int px,py,pz;
    public int tx,ty,tz,mx,my,mz;
    public GameObject tg;


    int ScreenArea()
    {
        int result = -1;
		if ((Input.mousePosition.x <= Screen.width / 2) && (Input.mousePosition.y >= Screen.height / 2)) {result = 1;}
		if ((Input.mousePosition.x >= Screen.width / 2) && (Input.mousePosition.y >= Screen.height / 2)) {result = 2;}
		if ((Input.mousePosition.x <= Screen.width / 2) && (Input.mousePosition.y <= Screen.height / 2)) {result = 3;}
		if ((Input.mousePosition.x >= Screen.width / 2) && (Input.mousePosition.y <= Screen.height / 2)) {result = 4;}
		return result;
    }

    void ResetCompass()
	{
		north = 0;
		south = 0;
		east = 0;
		west = 0;
	}

    void ResetStates()
	{
		top_l_state = 0;
		top_r_state = 0;
		bot_l_state = 0;
		bot_r_state = 0;
	}

    void ProcessInput()
    {
        current_screen_area = ScreenArea();

        if (Input.GetButtonDown("Fire1"))
		{
			mouse_down = 1;
			if (ScreenArea() == top_l_zone) {top_l_state = 1;}
			if (ScreenArea() == top_r_zone) {top_r_state = 1;}
			if (ScreenArea() == bot_l_zone) {bot_l_state = 1;}
			if (ScreenArea() == bot_r_zone) {bot_r_state = 1;}

		}

		if (Input.GetButtonUp("Fire1"))
		{
			mouse_down = 0;
			if (ScreenArea() == top_l_zone) {ResetStates();}
			if (ScreenArea() == bot_l_zone) {ResetStates();}
			if (ScreenArea() == top_r_zone) {ResetStates();}
			if (ScreenArea() == bot_r_zone) {ResetStates();}
		}

		if ((old_screen_area != current_screen_area) && (mouse_down == 1))
		{
			ResetStates();
			if (current_screen_area == top_l_zone) {top_l_state = 1;}
			if (current_screen_area == top_r_zone) {top_r_state = 1;}
			if (current_screen_area == bot_l_zone) {bot_l_state = 1;}
			if (current_screen_area == bot_r_zone) {bot_r_state = 1;}
		}


		if (top_l_state_old != top_l_state) {if (top_l_state != 1) {west = 2;}}
		top_l_state_old = top_l_state;
		if (top_l_state > 0) {west = 1;}

		if (top_r_state_old != top_r_state) {if (top_r_state != 1) {north = 2;}}
		top_r_state_old = top_r_state;
		if (top_r_state > 0) {north = 1;}

		if (bot_l_state_old != bot_l_state) {if (bot_l_state != 1) {south = 2;}}
		bot_l_state_old = bot_l_state;
		if (bot_l_state > 0) {south = 1;}

		if (bot_r_state_old != bot_r_state) {if (bot_r_state != 1) {east = 2;}}
		bot_r_state_old = bot_r_state;
		if (bot_r_state > 0) {east = 1;}

        //if (north == 1) {dv = 0;}
        //if (south == 1) {dv = 1;}
        //if (east == 1) {dv = 2;}
        //if (west == 1) {dv = 3;}

        if (north == 1 && px < 11) { px = px + 1;}
        if (south == 1 && px > 2) {px = px - 1;}
        if (east == 1 && pz > 2) { pz = pz - 1; }
        if (west == 1 && pz < 11) { pz = pz + 1; }
        
        ResetStates();
    }

    void ProcessMovement()
    {
        //if (dv == 0 & px < 11) {
        //    px = px + 1; dv = -1;
        //}
    }

    void InitVars()
    {
        px = 2;
        py = 1;
        pz = 2;
        tx = px;
        ty = py;
        tz = pz;
        dv = -1;
    }

    void Start()
    {
        InitVars();
        ResetCompass();

    }

    void UpdateModel()
    {
        transform.position = new Vector3(px-6.5f,py+0.5f,pz-6.5f);
        //tg.transform.position = new Vector3(tx-6.5f,ty-0.5f,tz-6.5f);
    }

    void Update()
    {
        ProcessInput();
        ProcessMovement();
        UpdateModel();
        old_screen_area = ScreenArea();
		ResetCompass();
		dv = -1;
    }
}
