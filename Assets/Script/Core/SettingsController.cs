using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider master, music, sfx;

    void Start()
    {
        Init(master, "MasterVol");
        Init(music, "MusicVol");
        Init(sfx, "SFXVol");
    }

    void Init(Slider s, string param)
    {
        float v = PlayerPrefs.GetFloat(param, 1f);
        s.SetValueWithoutNotify(v);
        Apply(param, v);
        s.onValueChanged.AddListener(x =>
        {
            Apply(param, x);
            PlayerPrefs.SetFloat(param, x);
        });
    }

    void Apply(string param, float v) =>
        mixer.SetFloat(param, Mathf.Log10(Mathf.Max(v, 0.0001f)) * 20f);
}