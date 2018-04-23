using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    // キューブの移動速度
    private float speed = -0.2f;
    // 消滅位置
    private float deadLine = -10;
	// 地面に着いた時の音
	private AudioSource sound01;

    // Use this for initialization
    void Start () {
		// AudioSourceコンポーネントを取得し、変数に格納
		sound01 = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }

    }

	void OnCollisionEnter2D (Collision2D other)
	{
		// キューブが落ちた時に音を鳴らす。ただし、UnityChanがぶつかったときには音を鳴らさない
		if (other.gameObject.tag != "UnityChan") {
			sound01.PlayOneShot (sound01.clip);
		}
	}
}
