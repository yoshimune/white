using UnityEngine;
using System.Collections;

public class SpriteFadeIn : MonoBehaviour {

	public float fadeTime = 1f;
 
	private float currentRemainTime;
	private SpriteRenderer spRenderer;
	private bool fadeInFlg;
	public bool FadeInFlg
	{
		set { this.fadeInFlg = value; }
	}
	// Use this for initialization
	void Start () {
		// 初期化
		currentRemainTime = 0;
		spRenderer = GetComponent<SpriteRenderer>();
		fadeInFlg = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.fadeInFlg) fadeIn();
	}
	
	private void fadeIn(){
		// 残り時間を更新
		currentRemainTime += Time.deltaTime;
 
		if ( currentRemainTime > 1f ) {
			// 残り時間が無くなったらフラグを折る
			updateAlpha(1f);
			fadeInFlg = false;
			return;
		}
 
		// フェードアウト
		updateAlpha(currentRemainTime / fadeTime);
	}
	
	private void updateAlpha(float alpha) {
		var color = spRenderer.color;
		color.a = alpha;
		spRenderer.color = color;
	}
}
