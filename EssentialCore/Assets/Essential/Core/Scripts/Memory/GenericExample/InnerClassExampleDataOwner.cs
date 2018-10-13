using UnityEngine;

namespace Essential.Core.Memory.GenericExample
{
    public class InnerClassExampleDataOwner : MonoBehaviour, IRecoverable<InnerClass>
    {
        [SerializeField] private InnerClassExampleData _data; 
        
        public InnerClass Data
        {
            get { return _data.Data; }
            set { _data.Data = value; }
        }

        public int Number
        {
            get { return _data.Number;}
            set { _data.Number = value; }
        }
        
        private void Update()
        {
            // Note: OuterClass must initialize InnerClass or InnerClass must be tagged as [Serializable] to prevent NullReferenceException
            Data.State = !Data.State;
            Number++;
            //Debug.Log(Data.State);
        }
    }
}
