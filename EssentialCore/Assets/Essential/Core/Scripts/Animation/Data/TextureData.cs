using UnityEngine;

namespace Essential.Core.Animation.Data
{
    [CreateAssetMenu(fileName = "TextureData_", menuName = "Animation/TextureData", order = 1)]
    public class TextureData : MainTextureData {
        /// <summary>
        /// Specifies which texture bound in shadder is affected by scale changes.
        /// </summary>
        [SerializeField] private string _shaderVariable = "_MainTex";
        
        /// <summary>
        /// Get or set the affected Material.
        /// </summary>
        public string ShaderVariable
        {
            get { return _shaderVariable; }
            set { _shaderVariable = value; }
        }
    }
}
