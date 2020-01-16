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
using Online.Define;

namespace Online
{

    public class RegisterUserData : MonoBehaviour
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
        public void Register()
        {

            StartCoroutine("Push");

        }

        /// <summary>
        /// @brief 入力されたユーザーの情報をPHPに送信する
        /// </summary>
        /// <returns></returns>
        private IEnumerator Push()
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

             UnityWebRequest request = UnityWebRequest.Post(ServerData.RegisterRanking, form);

            request.timeout = ServerData.MaxWaitTime;
            yield return request.SendWebRequest();

        }

    }

}