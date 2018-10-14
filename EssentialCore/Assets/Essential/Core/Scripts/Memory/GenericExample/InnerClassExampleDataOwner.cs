using System.Collections;
using UnityEngine;

namespace Essential.Core.Memory.GenericExample
{
    public class InnerClassExampleDataOwner : MonoBehaviour, IRecoverable<InnerClass>
    {
        private const int SecondsToWait = 1;

        [SerializeField] private InnerClassExampleData _data;
        
        private Coroutine Coroutine { get; set; }
        
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
        
        public void StartUpdatingValues()
        {
            if (Coroutine != null)
            {
                return;
            }
			
            Coroutine = StartCoroutine(UpdateValues());
        }

        public void StopUpdatingValues()
        {
            if (Coroutine == null)
            {
                return;
            }
			
            StopCoroutine(Coroutine);
            Coroutine = null;
        }

        private IEnumerator UpdateValues()
        {
            while (true)
            {
                // Note: OuterClass must initialize InnerClass or InnerClass must be tagged as [Serializable] to prevent NullReferenceException
                Data.State = !Data.State;
                Number++;
                //Debug.Log(Data.State);
                yield return new WaitForSeconds(SecondsToWait);
            }
        }
    }
}
