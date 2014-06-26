using UnityEngine;
using System.Collections;

public class DistanceBar : MonoBehaviour
{
    public Vector3 StartPosition;
    public Vector3 EndPosition;

    public float barDisplay = 0;
    
    private Vector2 pos;
    private Vector2 size;

    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;
    public Texture2D FlagSign;

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnGUI()
    {
        pos = new Vector2(5f, Screen.height - 25f);
        size = new Vector2(Screen.width - 10f, 20);
        var currentStyle = new GUIStyle(GUI.skin.box);
        currentStyle.normal.background = MakeTex(2, 2, new Color(0f, 0f, 0f, 0.5f));

        var currentStyle2 = new GUIStyle(GUI.skin.box);
        currentStyle2.normal.background = MakeTex(2, 2, new Color(1f, 1f, 0f, 0.5f));

        // draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty, currentStyle);

        // draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull, currentStyle2);
        GUI.EndGroup();

        GUI.DrawTexture(new Rect(size.x - 15f, 2.5f, FlagSign.width, FlagSign.height), FlagSign);
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
