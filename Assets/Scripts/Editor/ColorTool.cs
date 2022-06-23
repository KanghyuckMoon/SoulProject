using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System;
using System.IO;
using System.Text;

public class ColorTool : EditorWindow
{
	// Tool Data Start -->
	public const int WidthMiddle = 200;
	public const int WidthLarge = 300;
	public const int WidthXLarge = 450;

	private int selection = 0;
	private string name = "";

	private Vector2 scollerPoint1 = Vector2.zero;
	private Vector2 scollerPoint2 = Vector2.zero;
	// <---End

	[MenuItem("Editor/ColorTool")]
	//gui �ʱ�ȭ
	static void Init()
	{
		ColorTool window = (ColorTool)EditorWindow.GetWindow<ColorTool>(false, "ColorTool");

		window.Show();
	}

	private void OnGUI()
	{
		EditorGUILayout.BeginVertical();
		{
			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button("Convert", GUILayout.Width(WidthLarge)))
			{
				LogColorRGB();
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginVertical();
			name = EditorGUILayout.TextField(name, GUILayout.Width(WidthLarge));
			EditorGUILayout.EndVertical();
		}
		EditorGUILayout.EndVertical();

	}


	public void LogColorRGB()
	{
		//이름 
		string colorName = name;
		if(colorName.Length != 6)
		{
			return;
		}
		float r = 0;
		float g = 0;
		float b = 0;
		r = Convert.ToInt32($"{colorName[0]}{colorName[1]}", 16);
		g = Convert.ToInt32($"{colorName[2]}{colorName[3]}", 16);
		b = Convert.ToInt32($"{colorName[4]}{colorName[5]}", 16);
		b /= 255;
		g /= 255;
		r /= 255;

		Debug.Log(r);
		Debug.Log(g);
		Debug.Log(b);

	}
}
