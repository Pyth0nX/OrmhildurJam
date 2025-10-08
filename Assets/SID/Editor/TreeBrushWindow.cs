using UnityEngine;
using UnityEditor;

public class TreeBrushWindow : EditorWindow
{
    public GameObject treePrefab;       // Base prefab with SpriteRenderer
    public Sprite[] treeSprites;        // Tree sprites
    public Vector2 scaleRange = new Vector2(0.8f, 1.5f);
    public float brushRadius = 3f;
    public int treesPerClick = 3;

    [MenuItem("Tools/Tree Brush")]
    public static void ShowWindow()
    {
        GetWindow<TreeBrushWindow>("Tree Brush");
    }

    void OnGUI()
    {
        GUILayout.Label("Tree Brush Settings", EditorStyles.boldLabel);

        treePrefab = (GameObject)EditorGUILayout.ObjectField("Tree Prefab", treePrefab, typeof(GameObject), false);
        SerializedObject so = new SerializedObject(this);
        SerializedProperty spritesProp = so.FindProperty("treeSprites");
        EditorGUILayout.PropertyField(spritesProp, true);
        so.ApplyModifiedProperties();

        scaleRange = EditorGUILayout.Vector2Field("Scale Range", scaleRange);
        brushRadius = EditorGUILayout.FloatField("Brush Radius", brushRadius);
        treesPerClick = EditorGUILayout.IntField("Trees Per Click", treesPerClick);

        EditorGUILayout.HelpBox("Hold SHIFT + Left Click in Scene to paint trees.", MessageType.Info);
    }

    void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    void OnSceneGUI(SceneView sceneView)
    {
        Event e = Event.current;
        if (e.shift && e.type == EventType.MouseDown && e.button == 0)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
            Vector2 mousePos = ray.origin;

            for (int i = 0; i < treesPerClick; i++)
            {
                Vector2 pos = mousePos + Random.insideUnitCircle * brushRadius;
                GameObject newTree = (GameObject)PrefabUtility.InstantiatePrefab(treePrefab);

                newTree.transform.position = pos;

                SpriteRenderer sr = newTree.GetComponent<SpriteRenderer>();
                if (treeSprites.Length > 0)
                {
                    sr.sprite = treeSprites[Random.Range(0, treeSprites.Length)];
                }

                float scale = Random.Range(scaleRange.x, scaleRange.y);
                newTree.transform.localScale = new Vector3(scale, scale, 1f);

                Undo.RegisterCreatedObjectUndo(newTree, "Paint Tree");
            }

            e.Use(); // prevent other scene clicks
        }

        // Draw brush circle
        Handles.color = new Color(0, 1, 0, 0.3f);
        Handles.DrawSolidDisc(HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin, Vector3.forward, brushRadius);
    }
}
