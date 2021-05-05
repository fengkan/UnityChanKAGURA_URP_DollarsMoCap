using UnityEngine;

public class UnityChanExpression : MonoBehaviour {

    SkinnedMeshRenderer bodySkinnedMeshRenderer;

    // Use this for initialization
    void Start () {
        init();
    }

    void init()
    {
        GameObject body = DollarsSample.getChildGameObject(gameObject, "head_Def");
        bodySkinnedMeshRenderer = body.GetComponent<SkinnedMeshRenderer>();
    }

    public void SetExpression(string expression, float value = 1)
    {
        if (bodySkinnedMeshRenderer == null)
            init();

        switch (expression)
        {
            case "WeiXiao":
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("EYE_UP_L"), value * 100);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("EYE_UP_R"), value * 100);
                break;
            case "DaXiao":
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("EYE_SMILE_L"), value * 100);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("EYE_SMILE_R"), value * 100);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("MTH_SMILE"), value * 65);
                break;
            case "FaNu":
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("MTH_HE"), value * 70);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("BRW_ANG_L"), value * 100);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("BRW_ANG_R"), value * 100);
                break;
            case "MiYan":
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("EYE_DOWN_L"), value * 100);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("EYE_DOWN_R"), value * 100);
                break;
            case "ChiJing":
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("BRW_SUP_L"), value * 100);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("BRW_SUP_R"), value * 100);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("MTH_Short"), value * 100);
                break;

            default:
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("EYE_UP_L"), 0);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("EYE_UP_R"), 0);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("MTH_SMILE"), 0);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("MTH_HE"), 0);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("BRW_ANG_L"), 0);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("BRW_ANG_R"), 0);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("EYE_DOWN_L"), 0);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("EYE_DOWN_R"), 0);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("EYE_SMILE_L"), 0);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("EYE_SMILE_R"), 0);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("BRW_SUP_L"), 0);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("BRW_SUP_R"), 0);
                bodySkinnedMeshRenderer.SetBlendShapeWeight(bodySkinnedMeshRenderer.sharedMesh.GetBlendShapeIndex("MTH_Short"), 0);
                break;
        }

    }
}
