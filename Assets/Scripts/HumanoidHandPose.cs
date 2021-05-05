using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HumanoidHandPose : MonoBehaviour{
    [SerializeField] private Animator _HumanoidAnim;

    public enum HandPose{ Neutral = 0,
                              FingerPoint = 1,
                              Fist = 2,
                              HandGun = 3,
                              HandOpen = 4,
                              ThumbUp = 5,
                              Victory = 6 };
    public HandPose _RightShape = 0;
    public HandPose _LeftShape = 0;
    [SerializeField] float _FingerSpeed = 0.4f;
    [SerializeField] private static string[] sLeftBoneName = {
                                        "Left Index 1 Stretched","Left Index 2 Stretched","Left Index 3 Stretched","Left Index Spread",
                                        "Left Little 1 Stretched","Left Little 2 Stretched","Left Little 3 Stretched","Left Little Spread",
                                        "Left Middle 1 Stretched","Left Middle 2 Stretched","Left Middle 3 Stretched","Left Middle Spread",
                                        "Left Ring 1 Stretched","Left Ring 2 Stretched","Left Ring 3 Stretched","Left Ring Spread",
                                        "Left Thumb 1 Stretched","Left Thumb 2 Stretched","Left Thumb 3 Stretched","Left Thumb Spread",};
    [SerializeField] private static string[] sRightBoneName = {
                                        "Right Index 1 Stretched","Right Index 2 Stretched","Right Index 3 Stretched","Right Index Spread",
                                        "Right Little 1 Stretched","Right Little 2 Stretched","Right Little 3 Stretched","Right Little Spread",
                                        "Right Middle 1 Stretched","Right Middle 2 Stretched","Right Middle 3 Stretched","Right Middle Spread",
                                        "Right Ring 1 Stretched","Right Ring 2 Stretched","Right Ring 3 Stretched","Right Ring Spread",
                                        "Right Thumb 1 Stretched","Right Thumb 2 Stretched","Right Thumb 3 Stretched","Right Thumb Spread",};
    [SerializeField] private float[] nowLeftWeight = new float[20]{0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f};
    [SerializeField] private float[] nowRightWeight = new float[20]{0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f};
    [SerializeField] private static float[,] sHandWeight = new float[7,20]{{0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f,0f},
                                                                           {0.8f,0.8f,0.8f,-0.5f,-1f,-1f,-1f,-0.5f,-1f,-1f,-1f,-0.5f,-1f,-1f,-1f,-0.2f,-1f,-1f,-1f,0f},
                                                                           {-1f,-1f,-1f,-0.5f,-1f,-1f,-1f,-0.5f,-1f,-1f,-1f,-0.5f,-1f,-1f,-1f,-0.2f,-1f,-1f,-1f,0f},
                                                                           {0.8f,0.8f,0.8f,-0.5f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,1f,1f,0.5f},
                                                                           {0.6f,1f,1f,0.5f,0.6f,1f,1f,0.5f,0.6f,1f,1f,0.5f,0.6f,1f,1f,0f,-1f,1f,1f,0.5f},
                                                                           {-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,-1f,1f,1f,0.5f},
                                                                           {0.6f,1f,1f,0.2f,-0.8f,-0.8f,-0.8f,1f,0.6f,1f,1f,-1f,-0.8f,-0.8f,-0.8f,1f,-1f,-1f,-1f,0f}};
    private int[] sLeftBoneIndex = new int[20];
    private int[] sRightBoneIndex = new int[20];
    void Start(){
        SetupBoneList();
    }

    void Update(){
        nowLeftWeight = UpdateHandShape(nowLeftWeight,sHandWeight,(int)_LeftShape);
        nowRightWeight = UpdateHandShape(nowRightWeight,sHandWeight,(int)_RightShape);
        RotFinger(nowLeftWeight,nowRightWeight);
    }

    private void SetupBoneList(){
        if(_HumanoidAnim == null) _HumanoidAnim = transform.GetComponentInChildren<Animator>();
        if(_HumanoidAnim == null || !_HumanoidAnim.isHuman){
            return;
        }
        string[] muscleName = HumanTrait.MuscleName;
        for(int i=0; i<sLeftBoneName.Length; i++){
            sLeftBoneIndex[i] = Array.IndexOf(muscleName,sLeftBoneName[i]);
        }
        for(int i=0; i<sRightBoneName.Length; i++){
            sRightBoneIndex[i] = Array.IndexOf(muscleName,sRightBoneName[i]);
        }
        return;
    }
    private float[] UpdateHandShape(float[] nowShapes,float[,] newShapesList,int shape){
        for(int i=0; i<nowShapes.Length; i++){
            nowShapes[i] = Mathf.Clamp(newShapesList[shape,i],nowShapes[i]-_FingerSpeed,nowShapes[i]+_FingerSpeed);
        }
        return nowShapes;
    }

    private void RotFinger(float[] leftHandShape,float[] rightHandShape){
        HumanPose targetHumanPose = new HumanPose();
        var handler = new HumanPoseHandler(_HumanoidAnim.avatar, _HumanoidAnim.transform);
        handler.GetHumanPose(ref targetHumanPose);
        for(int i=0; i<sLeftBoneIndex.Length; i++){
            targetHumanPose.muscles[sLeftBoneIndex[i]] = leftHandShape[i];
            targetHumanPose.muscles[sRightBoneIndex[i]] = rightHandShape[i];
        }
        handler.SetHumanPose(ref targetHumanPose);
    }
}