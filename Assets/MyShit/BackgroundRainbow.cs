using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRainbow : MonoBehaviour {

	public float RateOfColourChange = 0.25f;

	[RangeAttribute(0, 359)]
	public int StartingHue = 123;

	[RangeAttribute(0, 255)]
	public int Saturation = 128;

	[RangeAttribute(0, 255)]
	public int Value = 217;

	public Camera MainCamera;

	// Use this for initialization
	void Start () {
		MainCamera = gameObject.GetComponent(typeof(Camera)) as Camera;
		float H = -1f;
		float S = -1f;
		float V = -1f;
		Color.RGBToHSV(MainCamera.backgroundColor, out H, out S, out V);

		H = StartingHue / 359f;
		S = Saturation / 255f;
		V = Value / 255f;

		MainCamera.backgroundColor = Color.HSVToRGB(H,S,V);

	}
	
	// Update is called once per frame
	void Update () {

		float H = -1f;
		float S = -1f;
		float V = -1f;
		Color.RGBToHSV(MainCamera.backgroundColor, out H, out S, out V);

		if((H + (RateOfColourChange / 359f)) >= 1)
			H = (H + (RateOfColourChange / 359f)) - 1;
		else
			H += (RateOfColourChange / 359f);

		MainCamera.backgroundColor = Color.Lerp(MainCamera.backgroundColor, Color.HSVToRGB(H,S,V),Mathf.PingPong(Time.time, 1));
	}
}
