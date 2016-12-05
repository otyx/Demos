﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

public class Ferr2DT_SceneOverlay {
	static Texture2D ferr2DIcon = Ferr.EditorTools.GetGizmo("2DTerrain/Gizmos/Ferr2DTIconSmall.png");
	
    static bool showTop = true;
    static int  top     = 0;

    public static bool showIndices  = false;
    public static bool showCollider = true;
	public static bool smartSnap    = false;
	
    const float dist = 100;
    public static void OnGUI() {
        Handles.BeginGUI();

	    int size  = 16;
	    int currX = 2;
        if (!showTop) top = (int)Screen.height - size*3 - 8;

	    GUI.Box(new Rect(0, top, Screen.width, size), "", EditorStyles.toolbar);
	    
	    // if it's not the pro skin, the icons are too bright, almost unseeable
	    if (!EditorGUIUtility.isProSkin) {
		    GUI.contentColor = new Color(0,0,0,1);
	    }
	    
	    // Draw the Ferr2D icon
	    GUI.Label(new Rect(currX, 1, size, size), ferr2DIcon);
	    currX += size + 6;
	    
	    // reset the color back to normal
	    GUI.contentColor = Color.white;
	    
	    Ferr2DT_Menu.SnapMode   = (Ferr2DT_Menu.SnapType)EditorGUI.EnumPopup(new Rect(currX, top, size * 6, size), Ferr2DT_Menu.SnapMode, EditorStyles.toolbarPopup);
	    currX += size * 6;
	    smartSnap = GUI.Toggle(new Rect(currX, top, size * 5, size), smartSnap, new GUIContent("Smart Snap", "[Ctrl+R]"), EditorStyles.toolbarButton);
	    currX += size * 5 + 6;
	    
	    Ferr2DT_Menu.HideMeshes = !GUI.Toggle(new Rect(currX, top, size * 5, size), !Ferr2DT_Menu.HideMeshes, "Show Meshes",       EditorStyles.toolbarButton);
	    currX += size * 5;
	    showCollider            =  GUI.Toggle(new Rect(currX, top, size * 6, size), showCollider,             "Show Colliders",    EditorStyles.toolbarButton);
	    currX += size * 6;
	    showIndices             =  GUI.Toggle(new Rect(currX, top, size * 2, size), showIndices,              "123",               EditorStyles.toolbarButton);
	    currX += size * 2;
	    
		if (Event.current.control && Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.R) {
	        smartSnap = !smartSnap;
        }
        Handles.EndGUI();
    }
}
