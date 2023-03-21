using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioTest : MonoBehaviour
{
	public Transform Group;
	public GameObject PlayBtnGo;
	public Button StopBtn;
	public Text AudioName;
	public AudioClip[] MyAudioClips;
	public AudioSource MyAudioSource;

	List<Button> Btns = new List<Button>();


	// Start is called before the first frame update
	void Awake()
    {
		StopBtn.onClick.AddListener(OnClickStopBtn);
		for(int i = 0; i < MyAudioClips.Length; ++i)
		{
			GameObject go = Instantiate(PlayBtnGo);
			go.SetActive(true);
			go.transform.SetParent(Group);
			go.transform.localScale = Vector3.one;
			Text txt = go.transform.Find("Text").GetComponent<Text>();
			Button btn = go.GetComponent<Button>();
			AudioClip clip = MyAudioClips[i];
			txt.text = clip.name;
			btn.onClick.AddListener(delegate { OnClickPlayBtn(clip); });
			Btns.Add(btn);
		}
	}

	private void OnClickPlayBtn(AudioClip clip)
    {
		MyAudioSource.Stop();
		MyAudioSource.clip = clip;
		MyAudioSource.Play();
		AudioName.text = clip.name;
	}

	private void OnClickStopBtn()
	{
		MyAudioSource.Stop();
	}
}
