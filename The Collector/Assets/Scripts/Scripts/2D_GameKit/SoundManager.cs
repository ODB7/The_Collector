using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TwoDGameKit
{
    /// <summary>
    /// Sound Manager will manage the registration and playing of
    /// sounds on this object 
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        // Audio Source 
        [SerializeField]private AudioSource soundSource;
        // A list of sound files
        private List<AudioLink> audioLinks = new List<AudioLink>();

        private void Reset()
        {
            soundSource = GetComponent<AudioSource>();
        }

        /// <summary>
        /// Pass in Audio Clip and get a reference ID in return 
        /// </summary>
        /// <param name="clip">Audio Clip</param>
        /// <returns>Reference ID</returns>
        public int RegisterSound(AudioClip clip)
        {
            // Create a new Audio Link 
            AudioLink newLink;
            newLink.audioClip = clip;
            newLink.LinkId = audioLinks.Count;
            if (audioLinks.Contains(newLink))
            {
                // Find where the audio link exist(index)
                int index = audioLinks.IndexOf(newLink);
                // Return the ID
                return audioLinks[index].LinkId;
            }

            // Add newLink to our AudioLinks list
            audioLinks.Add(newLink);
            // Return the Link ID
            return newLink.LinkId;
        }
        public void DeRegisterSound()
        {

        }
        /// <summary>
        /// Play the sound associated with the index
        /// </summary>
        /// <param name="index"> Index to the sound clip</param>
        public void PlaySound(int index)
        {
            // Stop sound Source
            soundSource.Stop();
            // Assigning the audio clip
            soundSource.clip = audioLinks[index].audioClip;
            // Play the audio clip
            soundSource.Play();
        }
    }
    // Audio link will hold the Link ID and the Aduio Clip
    internal struct AudioLink
    {
        public int LinkId;
        public AudioClip audioClip;

        public override bool Equals(object obj)
        {
            // Check for null
            if(obj == null)
            {
                return false;
            }
            // Check for the same run-time type
            else if (!this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                AudioLink al = (AudioLink)obj;
                return audioClip == al.audioClip;
            }
        }
    }
}