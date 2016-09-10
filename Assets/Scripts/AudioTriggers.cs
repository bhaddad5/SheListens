using UnityEngine;
using System.Collections;

public class AudioTriggers : MonoBehaviour
{
    public static uint PlayEvent(string s, GameObject g)
    {
        return PostEvent(Audio.Convert(s), g);
    }

    public static uint PostEvent(AudioClip c, GameObject g)
    {
        g.GetComponent<AudioSource>().PlayOneShot(c);
        return 0;
    }

    public static uint PostEvent(string s, GameObject g)
    {
        return AkSoundEngine.PostEvent(s, g);
    }

    public static uint PostEvent(string s, GameObject g, AkCallbackManager.EventCallback callback)
    {
        return PostEvent(s, g, callback, null);
    }
    
    public static uint PostEvent(string s, GameObject g, AkCallbackManager.EventCallback callback, object cookie)
    {
        return AkSoundEngine.PostEvent(s, g, (uint)AkCallbackType.AK_EndOfEvent, callback, cookie);
    }
    
    public static void ExecuteActionOnEvent(string name, AkActionOnEventType action, GameObject g)
    {
        AkSoundEngine.ExecuteActionOnEvent(name, action, g);
    }
    
    public static void SetState(string name, string state)
    {
         AkSoundEngine.SetState(name, state);
    }

    public static void SetSwitch(string name, string state, GameObject g)
    {
        AkSoundEngine.SetSwitch(name, state, g);
    }

    public static void PostTrigger(string s, GameObject g)
    {
         AkSoundEngine.PostTrigger(s, g);
    }

    public static void PauseEvent(string s, GameObject g)
    {
        AkSoundEngine.ExecuteActionOnEvent(s, AkActionOnEventType.AkActionOnEventType_Stop, g);
    }

    public static void SetRTPC(string param, float val)
    {
        AkSoundEngine.SetRTPCValue(param, val);
    }

    public static void SetRTPC(string param, float val, GameObject go)
    {
        AkSoundEngine.SetRTPCValue(param, val, go);
    }
}
