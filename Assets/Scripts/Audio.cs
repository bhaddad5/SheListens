using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Audio : MonoBehaviour
{
    public static Audio clip;

    [System.Serializable]
    public struct NamedClip
    {
        public string name;
        public AudioClip clip;
    }
    public NamedClip[] clips;

    void Start ()
    {
        clip = this;    
	}

    public static string Convert(string s)
    {
        return s;
    }
}
