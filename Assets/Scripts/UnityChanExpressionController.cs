using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UnityChanExpressionController : MonoBehaviour
{
    UnityChanExpression uce;
    UnityChanBlink ucb;

    public SteamVR_Action_Boolean Trigger;
    public SteamVR_Action_Vector2 Pos;

    Dictionary<string, float> weights = new Dictionary<string, float>();

    string[] exps = { "WeiXiao", "FaNu", "DaXiao", "ChiJing" };

    // Use this for initialization
    void Start()
    {
        uce = GetComponent<UnityChanExpression>();
        ucb = GetComponent<UnityChanBlink>();

        foreach (string exp in exps)
        {
            weights.Add(exp, 0f);
        }
    }

    float minimum = 0F;
    float maximum = 1.0F;

    void Update()
    {
        if (uce && uce.enabled && !ucb.isBlinking)
        {
            if ((Trigger != null) && Trigger.GetState(SteamVR_Input_Sources.LeftHand))
            {
                ucb.enabled = false;
                var po = Pos.GetAxis(SteamVR_Input_Sources.RightHand);

                if (po.x != 0)
                {
                    if (!HasExpressionBesides("DaXiao"))
                    {
                        weights["DaXiao"] = IncreaseBlendShapeValue(weights["DaXiao"], "DaXiao");
                    }
                }
                else
                {
                    if (!HasExpressionBesides("WeiXiao"))
                    {
                        weights["WeiXiao"] = IncreaseBlendShapeValue(weights["WeiXiao"], "WeiXiao");
                    }
                }
            }
            else if ((Trigger != null) && Trigger.GetState(SteamVR_Input_Sources.RightHand))
            {
                ucb.enabled = false;
                var po = Pos.GetAxis(SteamVR_Input_Sources.LeftHand);

                if (po.x != 0)
                {
                    if (!HasExpressionBesides("ChiJing"))
                    {
                        weights["ChiJing"] = IncreaseBlendShapeValue(weights["ChiJing"], "ChiJing");
                    }
                }
                else
                {
                    if (!HasExpressionBesides("FaNu"))
                    {
                        weights["FaNu"] = IncreaseBlendShapeValue(weights["FaNu"], "FaNu");
                    }
                }
            }
            else
            {
                if (!ucb.enabled)
                {
                    if (ZeroAllBlendShapes())
                    {
                        uce.SetExpression("");
                        if (!ucb.enabled)
                        {
                            ucb.enabled = true;
                        }
                    }
                }
            }
        }
    }

    float IncreaseBlendShapeValue(float t, string bs)
    {
        if (t <= 1)
            t += 10f * Time.deltaTime;
        float v = Mathf.Lerp(minimum, maximum, t);
        uce.SetExpression(bs, v);
        return t;
    }

    float DecreaseBlendShapeValue(float t, string bs)
    {
        t -= 10f * Time.deltaTime;
        float v = Mathf.Lerp(minimum, maximum, t);
        uce.SetExpression(bs, v);
        return t;
    }

    bool HasExpressionBesides(string exp)
    {
        foreach (var item in weights)
        {
            if (!item.Key.Equals(exp))
            {
                if (item.Value > 0)
                    return true;
            }
        }
        return false;
    }

    bool ZeroAllBlendShapes()
    {
        bool allBlendShapeZeroed = true;

        foreach (string exp in exps)
        {
            if (weights[exp] > 0)
            {
                weights[exp] = DecreaseBlendShapeValue(weights[exp], exp);
                allBlendShapeZeroed = false;
            }
        }
        return allBlendShapeZeroed;
    }
}
