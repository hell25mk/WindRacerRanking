using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Online
{

    public class PushData : MonoBehaviour
    {
       
        public void Push()
        {

            StartCoroutine("PostData");

        }

        private IEnumerator PostData()
        {

            WWWForm form = new WWWForm();

            form.AddField("送りたい変数", 1.ToString());

            UnityWebRequest request = UnityWebRequest.Post(Define.ServerAddress, form);

            request.timeout = 3;
            yield return request.SendWebRequest();
        }

    }

}