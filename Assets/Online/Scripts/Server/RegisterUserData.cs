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

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(yearText.text);
            sb.Append(monthText.text);
            sb.Append(dayText.text);

            Debug.Log(nameText.text);
            Debug.Log(prefList.value);
            Debug.Log(sb.ToString());
            //StartCoroutine("Push");

        }

        /// <summary>
        /// @brief 入力されたユーザーの情報をPHPに送信する
        /// </summary>
        /// <returns></returns>
        private IEnumerator Push()
        {

            WWWForm form = new WWWForm();

            form.AddField("name", nameText.text);
            form.AddField("pref", prefList.value);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(yearText.text);
            sb.Append(monthText.text);
            sb.Append(dayText.text);
            form.AddField("birthday", sb.ToString());

            UnityWebRequest request = UnityWebRequest.Post(ServerData.RegisterUserData, form);

            request.timeout = ServerData.MaxWaitTime;
            yield return request.SendWebRequest();

        }

    }

}