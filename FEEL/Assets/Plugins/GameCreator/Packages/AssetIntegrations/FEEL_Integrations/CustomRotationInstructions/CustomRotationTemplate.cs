using System.Collections.Generic;
using System.Threading.Tasks;
using MoreMountains.Feedbacks;
using UnityEngine;

using Helpers_GC2AssetIntegrations;
using Helpers_GC2FEELIntegrations;

namespace GC2_FEEL_Integrations_CustomRotation
{
    public static class CustomRotationTemplate 
    {
        // Get the relevant GameObject with the feedback from the "/Asset/Resources" folder
        private static string customRotationName =
            "CustomRotation_c0e9cbd84c755eec540f7fbb12c435fe78f0f333dc951b6af73de1ce898657359c5f4c58cc88ce7e5800052bd2cb0dfb4995a8661042b2be952ca68e3a8b4e65";
        private static GameObject customRotationObject = Resources.Load<GameObject>(customRotationName);
        
        /// <summary>
        /// Play CustomRotation Feedback on the given GameObject.
        /// </summary>
        /// <param name="targetObject">GameObject that will have CustomRotation applied to.</param>
        /// <param name="secsToLetFeedbacksPlay">Float that denotes the delay time before
        /// destroying the object created here.</param>
        /// <returns>Task<int> that represents the `Task.FromResult` of the thread</returns>
        public static async Task<int> PlayCustomRotationFeedback(
            GameObject targetObject, float secsToLetFeedbacksPlay)
        {
            // Get needed variables (MMF Player and the associated Game Object)
            (MMF_Player rotationMMFPlayer, GameObject copyRotationGameObject) = 
                GetRotationMMFPlayer(targetObject);
            
            // Play the Feedback
            GC2FEELHelpers.PlayFeedback(
                rotationMMFPlayer);
            
            // Clean up the Game Object copy
            GC2AssetHelpers.CleanUpObjectInTime(
                copyRotationGameObject, secsToLetFeedbacksPlay);
            
            return await Task.FromResult(1); 
        }

        /// <summary>
        /// Get the MMF_Player that has the relevant feedback(s).
        /// </summary>
        private static (MMF_Player ,GameObject) GetRotationMMFPlayer(GameObject targetObject)
        {
            // Create a copy of the original GameObject to avoid race conditions (will check if it's null also)
            GameObject copyCustomRotation = customRotationObject != null ? Object.Instantiate(customRotationObject) : null;

            // Grab the MMF_Player component from the instantiated prefab
            MMF_Player rotationMMFPlayer = 
                copyCustomRotation?.GetComponent<MMF_Player>();
            
            SetCustomRotationTarget(targetObject, rotationMMFPlayer);

            return (rotationMMFPlayer, copyCustomRotation);
        }
        
        /// <summary>
        /// Set the the feedback animation target for each feedback.
        /// </summary>
        private static void SetCustomRotationTarget(GameObject targetObject, MMF_Player rotationMMFPlayer)
        {
            // Get a list off all `MMF_Rotation` feedbacks
            List<MMF_Rotation> feedbackList = rotationMMFPlayer?.GetFeedbacksOfType<MMF_Rotation>();
            
            if (feedbackList != null)
            {
                // Play each found feedback
                foreach (MMF_Rotation feedback in feedbackList)
                {
                    // Assign the rotation target to the TargetObject's transform
                    feedback.AnimateRotationTarget = targetObject?.transform;
                }
            }
        }

    }
}

