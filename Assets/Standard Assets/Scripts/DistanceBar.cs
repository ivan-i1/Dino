using UnityEngine;
using System.Collections;

public class DistanceBar : MonoBehaviour
{
    public Vector3 StartPosition;
    public Vector3 EndPosition;

    public float barDisplay = 0;
    
    public Vector2 pos = new Vector2(200, 40);
    public Vector2 size = new Vector2(20, 150);

    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnGUI()
    {
        var currentStyle = new GUIStyle(GUI.skin.box);
        currentStyle.normal.background = MakeTex(2, 2, new Color(0f, 0f, 0f, 0.5f));

        var currentStyle2 = new GUIStyle(GUI.skin.box);
        currentStyle2.normal.background = MakeTex(2, 2, new Color(0f, 0f, 1f, 0.5f));

        // draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty, currentStyle);

        // draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull, currentStyle2);
        GUI.EndGroup();

        GUI.EndGroup();
    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        barDisplay = 1f - (EndPosition.x - player.transform.position.x) / (EndPosition.x - StartPosition.x);
    }
}
