using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScript : MonoBehaviour
{
    private bool selected = false;

    LoadSaveData ls;

    private void Start()
    {
        ls = GameObject.FindObjectOfType<LoadSaveData>();
    }

    void Update()
    {
        if (selected)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }
    }

    void OnMouseDown() {
        selected = true;
    }

    void OnMouseUp() {
        selected = false;

        GetComponent<RemoveScript>().DestroyIfNear();

        ls.OnApplicationQuit();
    }
}
