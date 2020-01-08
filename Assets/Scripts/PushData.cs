using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Online
{

    public class PushData : MonoBehaviour
    {

        [SerializeField]
        private Text idText;
        [SerializeField]
        private Text  nameText;
        [SerializeField]
        private Text pointText;
        [SerializeField]
        private Text timeText;

        public void Push()
        {

            StartCoroutine("PostData");

        }

        private IEnumerator PostData()
        {

            WWWForm form = new WWWForm();

            form.AddField("id", idText.text);
            form.AddField("name", nameText.text);
            form.AddField("point", pointText.text);
            form.AddField("best_time", timeText.text);

            UnityWebRequest request = UnityWebRequest.Post(ServerAddress.RegisterRanking, form);

            request.timeout = 3;
            yield return request.SendWebRequest();

        }

    }

}