using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
  private float nextInochi = 0;
  private float timeRemain = 30f;

  public static int score = 0;

  [SerializeField]
  Text remainTimeText;

  [SerializeField]
  Text scoreText;

  void Start() {
    score = 0;
  }

  void Update() {
    timeRemain -= Time.deltaTime;
    nextInochi -= Time.deltaTime;

    remainTimeText.text = timeRemain.ToString("F0");
    scoreText.text = score.ToString("F0");

    if (nextInochi <= 0) {
      Inochi.Add(Random.Range(-2f, 2f), Random.Range(-1.5f, 1.5f));
      nextInochi = 3;
    }

    if (timeRemain <= 0) {
      GameEnd();
    }
  }


  void GameEnd() {
    SceneManager.LoadScene("Result");
  }
}

