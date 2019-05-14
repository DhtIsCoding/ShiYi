using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ButtonInfo : MonoBehaviour ,KinectGestures.GestureListenerInterface
{

    public bool IsClicked { get; set; } = false;

    public int Index { get; set; } = 0;

    public List<Sprite> spriteList = new List<Sprite>();

    public int playerIndex;

    public SpriteRenderer sr;

    public Text tt;

    private int count = 0;

    private void Update()
    {
        if (IsClicked)
        {
            sr.sprite = spriteList[Index];

            if (count == 0)
            {
                sr.SendMessage("SetP", sr.sprite.rect.y);

                count++;
            }
        }
    }

    public void UserDetected(long userId, int userIndex)
    {
        tt.text = "";
        KinectManager manager = KinectManager.Instance;
        if (!manager || (userIndex != playerIndex))
            return;

        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);

    }

    public void UserLost(long userId, int userIndex)
    {
        tt.text = "用户丢失";
    }

    public void GestureInProgress(long userId, int userIndex, KinectGestures.Gestures gesture, float progress, KinectInterop.JointType joint, Vector3 screenPos)
    {
    }

    public bool GestureCompleted(long userId, int userIndex, KinectGestures.Gestures gesture, KinectInterop.JointType joint, Vector3 screenPos)
    {
        if (userIndex != playerIndex)
            return false;
        switch (gesture)
        {
            case KinectGestures.Gestures.SwipeLeft:
                Index++;
                if (Index == spriteList.Count)
                {
                    Index = 0;
                    count = 0;
                }
                break;

            case KinectGestures.Gestures.SwipeRight:
                Index--;
                if (Index < 0)
                {
                    Index = spriteList.Count - 1;
                    count = 0;
                }
                break;
        }
        return true;
    }

    public bool GestureCancelled(long userId, int userIndex, KinectGestures.Gestures gesture, KinectInterop.JointType joint)
    {
        if(userIndex != playerIndex)
        return false;
        return true;
    }
}
