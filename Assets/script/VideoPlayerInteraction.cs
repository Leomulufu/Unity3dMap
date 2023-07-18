using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerInteraction : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // 视频播放器组件
    private bool isVideoPlaying;     // 视频播放状态
    private Renderer objectRenderer; // 声明一个 Renderer 变量用于获取游戏对象的渲染器组件
    private bool isVisible = false; // 初始状态为不可见


    void Start()
    {
        SetObjectVisibility(isVisible); // 将游戏对象设置为初始状态的可见性
    }

    void Update()
    {
        // 检测鼠标左键按下事件
        if (Input.GetMouseButtonDown(0))
        {
            // 从屏幕中心发射一条射线
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            // 检测射线是否与平面碰撞
            if (Physics.Raycast(ray, out hit))
            {
                // 如果碰撞的对象是当前平面对象
                if (hit.collider.gameObject == gameObject)
                {
                    // 播放或暂停视频
                    if (isVideoPlaying)
                    {
                        videoPlayer.Pause();
                    }
                    else
                    {
                        videoPlayer.Play();
                    }

                    // 切换视频播放状态
                    isVideoPlaying = !isVideoPlaying;

                    isVisible = !isVisible; // 切换可见性状态
                    SetObjectVisibility(isVisible); // 设置游戏对象的可见性
                }
            }
        }
    }

    private void SetObjectVisibility(bool isVisible)
    {
        Renderer renderer = GetComponent<Renderer>(); // 获取游戏对象上的渲染器组件

        if (renderer != null)
        {
            renderer.enabled = isVisible; // 设置游戏对象的渲染器可见性
        }
        else
        {
            Debug.LogWarning("Renderer component not found on the game object.");
        }
    }
}
