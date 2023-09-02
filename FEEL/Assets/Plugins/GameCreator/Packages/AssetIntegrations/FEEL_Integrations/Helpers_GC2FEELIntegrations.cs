using System.ComponentModel;
using MoreMountains.Feedbacks;

namespace Helpers_GC2FEELIntegrations
{
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //      !!!!!!!!!!!!!!!!!!!!!!!!! WARNING, DO NOT CHANGE THE NAME OF THE ENUMS !!!!!!!!!!!!!!!!!!!!!!!!!
    //              (critical functionality assumes files/objects/classes match the enum name)
    /// <summary>
    /// Enums that will give the user options of `MMF_Feedback`s.
    /// </summary>
    public enum ChosenFeedback
    {
        [Description("CustomRotation")] // This description will be 
        CustomRotation, // name you'll see in the drop down and the name of the associated C# file/class
        
        // TODO: ADD MORE
    }
    
    public static class GC2FEELHelpers
    {
        /// <summary>
        /// Play CustomRotation Feedback in a given timespan (must have at least 1 second).
        /// </summary>
        /// <param name="mmfPlayer">MMF_Player that should already be targeting `targetObject`.</param>
        /// <returns>Task<int> that represents the `Task.FromResult` of the thread</returns>
        public static void PlayFeedback(
            MMF_Player mmfPlayer)
        {
            mmfPlayer?.Initialization(); // Initialize MMF_Player
            mmfPlayer?.PlayFeedbacks();  // Play the Feedbacks
        }
    }
}

