using UnityEngine;
using UnityEngine.Video;

public class VideoToGameplay : MonoBehaviour
{
    public VideoPlayer videoPlayer; // مكون VideoPlayer
    MainMenu mainMenu;

    void Start()
    {
        mainMenu = FindObjectOfType<MainMenu>();
        // الاشتراك في حدث انتهاء الفيديو
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // تحميل مشهد اللعب عند انتهاء الفيديو
        mainMenu.PlayGamePlay();
        
    }
}
