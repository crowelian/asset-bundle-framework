using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{

    public static TextManager Instance;

    [SerializeField] UnityEngine.UI.Text debugText;
    [SerializeField] UnityEngine.UI.Image debugImage;

    void Awake()
    {
        if (Instance != null) { Destroy(this); }
        else Instance = this;
    }

    public void SetText(string msg, bool doNotAdd = false)
    {
        if (debugText == null)
        {
            return;
        }

        if (debugText != null && doNotAdd)
        {
            debugText.text = msg;
            return;
        }

        debugText.text += msg + " ### ";

    }

    public void SetImage(Sprite sprite)
    {
        if (debugImage == null) return;
        debugImage.sprite = sprite;
    }
}
