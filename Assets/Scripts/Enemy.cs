
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
  static GameObject _prefab = null;

  bool isEye = false;
  float timeChangeToEye = 0;
  float timeToExplode = 8f;

  public static Enemy Add(float x, float y, float angle, Transform parent) {
    _prefab ??= Resources.Load("Prefabs/Enemy") as GameObject;
    GameObject g = Instantiate(_prefab, parent);
    g.transform.position = new Vector2(x, y);
    g.transform.Rotate(0, 0, -angle, Space.Self);
    return g.GetComponent<Enemy>();
  }

  void Start() {
    float direction = Random.Range(0f, 2.0f * Mathf.PI);
    timeChangeToEye = Random.Range(0f, 8f);
  }

  void Update() {
    timeChangeToEye -= Time.deltaTime;
    timeToExplode -= Time.deltaTime;
    if (!isEye && timeChangeToEye <= 0) {
      isEye = true;
      Sprite sprite = Resources.Load<Sprite>("Sprites/inochi1");
      gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    if (timeToExplode <= 0) {
      Component[] audios = GameObject.Find("SE_Set").GetComponentsInChildren<AudioSource>();
      AudioSource audio = audios[1] as AudioSource;
      AudioSource.PlayClipAtPoint(audio.clip, transform.position);
      for (int i = 0; i < 24; i++) {
        Particle.Add(transform.position.x, transform.position.y);
      }
      Destroy(gameObject);
    }
  }

  public void OnMouseDown() {
    if (!isEye) return;
    Component[] audios = GameObject.Find("SE_Set").GetComponentsInChildren<AudioSource>();
    AudioSource audio = audios[0] as AudioSource;
    AudioSource.PlayClipAtPoint(audio.clip, transform.position);
    GameManager.score++;
    for (int i = 0; i < 24; i++) {
      Particle.Add(transform.position.x, transform.position.y);
    }
    Destroy(gameObject);
  }
}
