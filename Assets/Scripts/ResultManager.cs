using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResultManager : MonoBehaviour {
  private float timeRemain = 3f;
  void Update() {
    timeRemain -= Time.deltaTime;
  }

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
    GUI.Label(new Rect(x, y - 40, w, h), "今回のスコア", guiStyle);
    GUI.Label(new Rect(x, y, w, h), GameManager.score.ToString("F0"), guiStyle);
    if (timeRemain <= 0 && GUI.Button(new Rect(x, y + 60, w, h), "Title")) {
      SceneManager.LoadScene("Title");
    }
  }
}
