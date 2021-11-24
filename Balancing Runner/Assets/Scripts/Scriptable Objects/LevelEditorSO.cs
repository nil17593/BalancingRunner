using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="LevelEditorScriptableObject",fileName ="ScriptableObject/NewLevelEditorSO")]
public class LevelEditorSO : ScriptableObject
{
    public string LevelNumber;
    public DifficultyLevel difficultyLevel;
    public List<GameObject> PlatForms;
    public List<GameObject> Obstacles;
}


