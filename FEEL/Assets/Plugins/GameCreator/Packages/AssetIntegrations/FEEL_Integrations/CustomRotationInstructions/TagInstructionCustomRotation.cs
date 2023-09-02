using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UIFunctions;

using Helpers_GC2FEELIntegrations;
using GC2_FEEL_Integrations_CustomRotation;
using UnityEngine;

[Category("AssetFEEL/CustomRotationOnTag")]
[Keywords("Feel", "FEEL", "Feel Game Creator2", "FEELGC2", 
    "Feedbacks", "Animation", "Effects", "Special Effects",
    "CustomRotation", "Rotation", "Tag")]

[Dependency("MoreMountains.Feedbacks", 3, 3, 3)]
[Dependency("UIFunctions", 1, 1, 1)]
[Dependency("GC2_FEEL_Integrations_CustomRotation", 1, 1, 1)]

[Parameter("targetObject", "The target object that will have the feedbacks applied to.")]
[Parameter("SecsToLetFeedbacksPlay", "Delay in Seconds of when to destroy the GameObject so you have time for Feedbacks to play.")]
[Serializable]
public class TagInstructionCustomRotation : Instruction
{
    [Header("Choose a Tag to Apply Feedbacks")]
    [TagSelector]
    public string tagName = ""; // the name of the Unity Tag
    // Save for later; I can use this when I want to affect multiple tags
    //[TagSelector]
    //public string[] TagFilterArray = new string[] { };
    
    [Header("Choose a Type of Feedback")]
    // `ChosenFeedback` is an enum, so this will give user a drop-down of the enums in the UI
    public ChosenFeedback selectedFeedback;
    
    [Header("Time to Let Feedbacks Play")]
    // Delay time before destroying the GameObject created here
    //      because the Feedback is applied on a thread.
    public float secsToLetFeedbacksPlay = 1f;
    
    protected override Task Run(Args args)
    {
        // Double check that this is null
        if (string.IsNullOrEmpty(tagName)) // Make sure TagName is not null or empty
        {
            Debug.Log($"The GameObject '{args.Self}' initiated this class, " +
                      $"the targeted GameObject is '{args.Target},' " +
                      $"invoked the Game Creator 2 ApplyFeedbacks Instruction.");
            
            // If `TagName` is null, have to return early since it's needed
            return DefaultResult; // `DefaultResult` is from Game Creator 2
        }
        
        /////////////////////////////////////////////////////////////

        GameObject[] objectsInTag = GameObject.FindGameObjectsWithTag(tagName);
        
        // Apply the feedback to each Game Object with the associated tag
        foreach (GameObject tagObject in objectsInTag)
        {
            #pragma warning disable 4014 // disabling warning since this function is not dependent on the async function

            CustomRotationTemplate.
                PlayCustomRotationFeedback(tagObject, secsToLetFeedbacksPlay);
            
            #pragma warning disable 4014 // disabling warning since this function is not dependent on the async function
        }

        // This return result is from Game Creator 2; leave it alone
        return DefaultResult;
    }
}
