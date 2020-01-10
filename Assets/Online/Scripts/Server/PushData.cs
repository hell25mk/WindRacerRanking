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
        private Dropdown prefList;
        [SerializeField]
        private Text yearText;
        [SerializeField]
        private Text monthText;
        [SerializeField]
        private Text dayText;

        public void Push()
        {

            StartCoroutine("PostData");

        }

        private IEnumerator PostData()
        {

            WWWForm form = new WWWForm();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            form.AddField("id", idText.text);
            form.AddField("name", nameText.text);
            form.AddField("pref", prefList.value);

            sb.Append(yearText.text);
            sb.Append("-");
            sb.Append(monthText.text);
            sb.Append("-");
            sb.Append(dayText.text);
            form.AddField("birthday", sb.ToString());

             UnityWebRequest request = UnityWebRequest.Post(ServerAddress.RegisterRanking, form);

            request.timeout = 3;
            yield return request.SendWebRequest();

        }

    }

}