using UnityEngine;

namespace Script.View
{
    public class Common : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        } 
        
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
        
    }
}