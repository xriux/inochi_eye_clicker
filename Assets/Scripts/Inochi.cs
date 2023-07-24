using UnityEngine;
using System.Collections;

public class Inochi : MonoBehaviour {
  static GameObject _prefab = null;
  float timePassed = 0;

  public static Inochi Add(float _x, float _y) {
    _prefab ??= Resources.Load("Prefabs/Inochi") as GameObject;
    GameObject g = Instantiate(_prefab);

    for (int i = 0; i < 12; i++) {
      float radius = 0.8f;
      float angle = 2f * Mathf.PI * (i / 12f);
      float x = radius * Mathf.Sin(angle);
      float y = radius * Mathf.Cos(angle);
      Enemy enemy = Enemy.Add(x, y, 360f * (i / 12f), g.GetComponent<Inochi>().transform);
    }

    g.transform.position = new Vector2(_x, _y);

    return g.GetComponent<Inochi>();
  }

  void Update() {
    timePassed += Time.deltaTime;
    float angle = timePassed * Mathf.PI;
    transform.Rotate(0, 0, Time.deltaTime * 30f, Space.Self);
    transform.localScale = new Vector3((Mathf.Cos(angle) + 3f) / 4f, (-Mathf.Cos(angle) + 3f) / 4f, 1);
  }
}
