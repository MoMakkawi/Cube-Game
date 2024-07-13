using UnityEngine;
using UnityEngine.Video;

public class VideoToGameplay : MonoBehaviour
{
    public VideoPlayer videoPlayer; // مكون VideoPlayer


    void Start()
    {
        // الاشتراك في حدث انتهاء الفيديو
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // تحميل مشهد اللعب عند انتهاء الفيديو
        MainMenu.StartGame();
    }
}
