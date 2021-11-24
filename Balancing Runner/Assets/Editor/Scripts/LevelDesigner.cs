using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelDesigner : EditorWindow
{
    public GameObject player;
    float lengthOfPlatform;
    Color color;
    float spawnRadius=5f;
    int objectID;
    float objectScale;

    public GameObject[] platForms;

    float scale = 1.0f;


    public static List<GameObject> objs = new List<GameObject>();
    private static List<float> floats = new List<float>();
    private static Vector2 v = Vector2.zero;

    [MenuItem("Window/Level Designer")]


    //static void Init()
    //{
    //    var window = GetWindowWithRect<LevelDesigner>(new Rect(0, 0, 600, 500));
    //    window.Show();
    //}
    static void OpenWindow()
    {
        LevelDesigner window = (LevelDesigner)GetWindow(typeof(LevelDesigner));
        window.minSize = new Vector2(200, 300);
        window.Show();
    }

    private void OnGUI()
    {
        ScaleGameObject();

        GUILayout.Label("Colour the selected objects!", EditorStyles.boldLabel);
        color = EditorGUILayout.ColorField("Color", color);
        if (GUILayout.Button("COLORIZE!"))
        {
            Colorize();
        }

        //character creation
        GUILayout.Label("Set The Character!", EditorStyles.boldLabel);
        //speedOfCharacter = EditorGUILayout.IntField("Speed of character", speedOfCharacter);
        //playerName = EditorGUILayout.TextField("Player Name", playerName);
        player = EditorGUILayout.ObjectField("player prefab",player, typeof(GameObject),false)as GameObject;
        if (GUILayout.Button("CreatePlayer"))
        {
            SpawnPlayer();
        }
    }

    private void Colorize()
    {
        foreach(GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }

    void SpawnPlayer()
    {
        if (player == null)
        {
            Debug.LogError("Error: Please assign Player Character prefab");
            return;
        }

        Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(spawnCircle.x, 1.5f, spawnCircle.y);
        Debug.Log("spawncircle"+spawnCircle);

        GameObject newGO = Instantiate(player, spawnPos, Quaternion.identity);
        newGO.transform.localScale = Vector3.one * objectScale;
    }

    void SpawnObstacles()
    {

        Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(spawnCircle.x, 1.5f, spawnCircle.y);
        Debug.Log("spawncircle" + spawnCircle);

        GameObject newGO = Instantiate(player, spawnPos, Quaternion.identity);
        newGO.transform.localScale = Vector3.one * objectScale;
    }

    void ScaleGameObject()
    {
        var style = new GUIStyle(GUI.skin.label);
        style.alignment = TextAnchor.MiddleCenter;
        style.fontStyle = FontStyle.Bold;
        EditorGUILayout.LabelField("Customize Game Objects", style, GUILayout.ExpandWidth(true));

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Scale: ");
        scale = EditorGUILayout.FloatField(scale);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Apply"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }
}
