using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Text;

/// <summary>
/// 리소스 폴더의 경로를 얻어오는 클래스
/// </summary>
public class EditPathClass : MonoBehaviour
{
	public static void CreateMonsterStructure(string monsterName, StringBuilder data)
	{
		string templateFilePath = "Assets/Editor/tempMonster.txt";

		string entityTemplate = File.ReadAllText(templateFilePath);

		entityTemplate = entityTemplate.Replace("$NAME$", monsterName.ToString());

		string folderPath = "Assets/Scripts/Monster/";
		if (Directory.Exists(folderPath) == false)
		{
			Directory.CreateDirectory(folderPath);
		}

		string filePath = folderPath + monsterName + ".cs";

		if (File.Exists(filePath) == true)
		{
			File.Delete(folderPath);
		}

		File.WriteAllText(filePath, entityTemplate);

		AssetDatabase.Refresh();
	}

}
