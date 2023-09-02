using UnityEngine;

namespace Helpers_GC2AssetIntegrations
{
    public static class GC2AssetHelpers
    {
        /// <summary>
        /// Destroys the given GameObject in 1 second.
        /// </summary>
        /// <param name="gameObject">GameObject to be destroyed in 1 second.</param>
        public static void CleanUpObjectInOneSec(
            GameObject gameObject)
        {
            GameObject.Destroy(gameObject, 1f); // no error if gameObject is null
        }
        
        /// <summary>
        /// Destroys the given Game Object in the given timeframe 
        /// (if less that 1s, it will be changed to 1s).
        /// </summary>
        /// <param name="gameObject">GameObject to be destroyed in the given time..</param>
        /// <param name="secsToLetFeedbacksPlay">Float that denotes the delay time before
        /// destroying the object created here.</param>
        public static void CleanUpObjectInTime(
            GameObject gameObject, float secsToLetFeedbacksPlay)
        {
            // Destroy the GameObject with a delay
            if (secsToLetFeedbacksPlay < 1f)
            {
                secsToLetFeedbacksPlay = 1f;
                //Debug.Log("ApplyFeedbacks: delay cannot be less than 1, setting delay ton 1");
            }
            // Destroys the gameObject in after a delay of value `secsToLetFeedbacksPlay`
            GameObject.Destroy(gameObject, secsToLetFeedbacksPlay); // no error if `mmfPlayerObject` is null
        }
    }
}
