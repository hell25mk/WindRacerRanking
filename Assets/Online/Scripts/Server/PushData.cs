/*
 * 
 * 長嶋
 * 
 */

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

        /// <summary>
        /// @brief PostDataコルーチンを開始する
        /// </summary>
        public void Push()
        {

            StartCoroutine("PostData");

        }

        /// <summary>
        /// @brief ランキングに登録するデータをPHPに送信する
        /// </summary>
        /// <returns></returns>
        private IEnumerator PostData()
        {

            WWWForm form = new WWWForm();

            form.AddField("id", idText.text);
            form.AddField("name", nameText.text);
            form.AddField("pref", prefList.value);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(yearText.text);
            sb.Append(monthText.text);
            sb.Append(dayText.text);
            form.AddField("birthday", sb.ToString());

             UnityWebRequest request = UnityWebRequest.Post(ServerAddress.RegisterRanking, form);

            request.timeout = 3;
            yield return request.SendWebRequest();

        }

    }

}