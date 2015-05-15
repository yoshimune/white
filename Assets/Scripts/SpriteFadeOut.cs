using UnityEngine;
using System.Collections;

public class SpriteFadeOut : MonoBehaviour {
	public float fadeTime = 1f;
 
	private float currentRemainTime;
	private SpriteRenderer spRenderer;
	private bool fadeOutFlg;
	public bool FadeOutFlg
	{
		set { this.fadeOutFlg = value; }
	}
	// Use this for initialization
	void Start () {
		// 初期化
		currentRemainTime = fadeTime;
		spRenderer = GetComponent<SpriteRenderer>();
		fadeOutFlg = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.fadeOutFlg) fadeOut();
	}
	
	private void fadeOut(){
		// 残り時間を更新
		currentRemainTime -= Time.deltaTime;
 
		if ( currentRemainTime <= 0f ) {
			// 残り時間が無くなったら自分自身を消滅
			GameObject.Destroy(gameObject);
			return;
		}
 
		// フェードアウト
		float alpha = currentRemainTime / fadeTime;
		var color = spRenderer.color;
		color.a = alpha;
		spRenderer.color = color;
	}
}
