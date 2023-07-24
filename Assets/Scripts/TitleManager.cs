using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleManager : MonoBehaviour {
  void OnGUI() {
    float w = 128;
    float h = 32;
    float x = Screen.width / 2 - w / 2;
    float y = Screen.height / 2 - h / 2;
    GUIStyle guiStyle = new GUIStyle();
    guiStyle.font = (Font)Resources.Load("Fonts/uzura");
    guiStyle.fontSize = 32;
    guiStyle.normal.textColor = Color.white;
    guiStyle.alignment = TextAnchor.MiddleCenter;
    GUI.Label(new Rect(x, y - 40, w, h), "Inochi Eye Clicker", guiStyle);
    if (GUI.Button(new Rect(x, y + 60, w, h), "Start")) {
      SceneManager.LoadScene("Main");
    }
  }
}
