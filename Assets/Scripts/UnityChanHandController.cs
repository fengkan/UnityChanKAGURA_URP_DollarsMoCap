using UnityEngine;
using Valve.VR;

public class UnityChanHandController : MonoBehaviour
{
    HumanoidHandPose hh;

    bool HandposeChanged;
    public SteamVR_Action_Boolean Trigger;
    public SteamVR_Action_Vector2 Pos;

    // Use this for initialization
    void Start()
    {
        hh = GetComponent<HumanoidHandPose>();
        HandposeChanged = false;
    }
    void Update()
    {
        if (hh && hh.enabled)
        {
            bool pressed = false;

            if ((Trigger != null) && Trigger.GetState(SteamVR_Input_Sources.RightHand))
            {
                pressed = true;
                var po = Pos.GetAxis(SteamVR_Input_Sources.RightHand);

                if ((Mathf.Abs(po.x) <= 0.5) && (po.y > 0.5))
                {
                    hh._RightShape = HumanoidHandPose.HandPose.FingerPoint;
                }
                else if (po.x < 0) // 左
                {
                    if (po.y > 0) // 左上
                    {
                        hh._RightShape = HumanoidHandPose.HandPose.Fist;
                    }
                    else if (po.y < 0) // 左下
                    {
                        hh._RightShape = HumanoidHandPose.HandPose.HandOpen;
                    }
                }
                else if (po.x > 0) // 右
                {
                    if (po.y > 0) // 右上
                    {
                        hh._RightShape = HumanoidHandPose.HandPose.Victory;
                    }
                    else if (po.y < 0) // 右下
                    {
                        hh._RightShape = HumanoidHandPose.HandPose.ThumbUp;
                    }
                }
                HandposeChanged = true;
            }

            if ((Trigger != null) && Trigger.GetState(SteamVR_Input_Sources.LeftHand))
            {
                pressed = true;
                var po = Pos.GetAxis(SteamVR_Input_Sources.LeftHand);

                if ((Mathf.Abs(po.x) <= 0.5) && (po.y > 0.5))
                {
                    hh._LeftShape = HumanoidHandPose.HandPose.FingerPoint;
                }
                else if (po.x < 0) // 左
                {
                    if (po.y > 0) // 左上
                    {
                        hh._LeftShape = HumanoidHandPose.HandPose.Fist;
                    }
                    else if (po.y < 0) // 左下
                    {
                        hh._LeftShape = HumanoidHandPose.HandPose.HandOpen;
                    }
                }
                else if (po.x > 0) // 右
                {
                    if (po.y > 0) // 右上
                    {
                        hh._LeftShape = HumanoidHandPose.HandPose.Victory;
                    }
                    else if (po.y < 0) // 右下
                    {
                        hh._LeftShape = HumanoidHandPose.HandPose.ThumbUp;
                    }
                }
                HandposeChanged = true;
            }
            if (!pressed && HandposeChanged)
            {
                hh._RightShape = HumanoidHandPose.HandPose.Neutral;
                hh._LeftShape = HumanoidHandPose.HandPose.Neutral;
                HandposeChanged = false;
            }
        }

    }
}
