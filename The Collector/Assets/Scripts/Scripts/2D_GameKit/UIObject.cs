using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TwoDGameKit
{
    public class UIObject : MonoBehaviour
    {
        // One of the Methods at a minimum must be overridden
        public virtual void UpdateInt(int number)
        {
            ErrorMessage<int>(number);
        }

        public virtual void UpdateFloat(float number)
        {
            ErrorMessage<float>(number);
        }

        public virtual void UpdateString(string message)
        {
            ErrorMessage<string>(message);
        }

        /// <summary>
        /// This method must be overridden
        /// </summary>
        protected virtual void UpdateUI()
        {
            Debug.LogError("This UI Object does not override the UpdateUI Method");
        }

        /// <summary>
        /// This is a templated Method, It allows us to pass in a value and a
        /// Type without knowing what that will be
        /// We use this very cautiosly so that there are no issues
        /// We have marked it as private so that even children of this object cannot see or use it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// param name="value"></param>
        private void ErrorMessage<T>(T value)
        {
            // This creates an error with a custom message for this error
            // It will look like this as an example
            // Could not update the UI on this Object 'Health', with the value 'Hello' of the type 'string'
            Debug.LogErrorFormat("Could not update the UI on this object '{0}, " +
                "with the value '{1}' of type '{2}", gameObject.name, value, typeof(T));

        }
    }
}