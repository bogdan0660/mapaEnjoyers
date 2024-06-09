using UnityEngine;
using System.Collections;

public class CursorChanger : MonoBehaviour
{
    public Texture2D cursorTexture; // Przeciągnij tutaj swój obrazek PNG kursora w inspektorze Unity
    public Vector2 hotspot = Vector2.zero;

    private bool cursorHidden = false;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
        StartCoroutine(HideCursorAfterDelay(10f));
    }

    IEnumerator HideCursorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        cursorHidden = true;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f)
        {
            if (cursorHidden)
            {
                cursorHidden = false;
                Cursor.visible = true;
                StartCoroutine(HideCursorAfterDelay(10f));
            }
        }
    }
}
