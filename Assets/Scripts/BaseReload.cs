using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class BaseReload : MonoBehaviour
    {
        // WIP DOESNT WORK
        public Image reloadImage;
        [Range(0, 1)]
        public float reloadProgress = 0;
    
        public float timeAmount = 5f;
        private float time;

        public Canvas parent;
    
        
        // Start is called before the first frame update
        void Start()
        {
            reloadImage.transform.SetParent(parent.transform);
            time = timeAmount;
        }

        // Update is called once per frame
        void Update()
        {
        
            if (time > 0)
            {
                time -= Time.deltaTime;
                reloadImage.fillAmount = time / timeAmount;
            }
        }

    }
}