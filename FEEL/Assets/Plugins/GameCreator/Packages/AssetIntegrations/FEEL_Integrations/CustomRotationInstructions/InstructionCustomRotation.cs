using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

using GC2_FEEL_Integrations_CustomRotation;

using UnityEngine;

[Category("AssetFEEL/CustomRotation")]
[Keywords("Feel", "FEEL", "Feel Game Creator2", "FEELGC2", 
    "Feedbacks", "Animation", "Effects", "Special Effects",
    "CustomRotation", "Rotation")]
[Dependency("MoreMountains.Feedbacks", 3, 3, 3)]
[Dependency("UIFunctions", 1, 1, 1)]
[Dependency("GC2_FEEL_Integrations_CustomRotation", 1, 1, 1)]
[Parameter("targetObject", "The target object that will have the feedbacks applied to.")]
[Parameter("SecsToLetFeedbacksPlay", "Delay in Seconds of when to destroy the GameObject so you have time for Feedbacks to play.")]
[Serializable]
public class CustomRotation : Instruction
{
    [Header("Target Game Object with Transform")]
    // The target object that will have the feedbacks applied to
    public GameObject targetObject;
    
    [Header("Time to Let Feedbacks Play")]
    // Delay time before destroying the GameObject created here
    //      because the Feedback is applied on a thread.
    public float secsToLetFeedbacksPlay = 1f;
    
    protected override Task Run(Args args)
    {
        CustomRotationTemplate.
            PlayCustomRotationFeedback(targetObject, secsToLetFeedbacksPlay);
        
        return DefaultResult;
    }
}
