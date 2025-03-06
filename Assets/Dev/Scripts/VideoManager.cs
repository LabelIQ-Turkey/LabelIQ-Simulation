using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    public static bool En
    {
      get{
        if(Instance==null)
           Instance=FindObjectOfType<VideoManager>();
        return Instance.Engilsh;
      }
    }

    public static VideoManager Instance;
    public bool Engilsh;

    private AudioSource AudioSource;
    public List<AudioClip> SceneVoices;


    void Awake()
    {
        TryGetComponent(out AudioSource);
        Instance=this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.pitch=Time.timeScale;
    }

    public void PlayVoice(int index,float delay=0)
    {
       AudioSource.clip=SceneVoices[index];
       AudioSource.time=delay;
        AudioSource.Play();
    }


   
}
