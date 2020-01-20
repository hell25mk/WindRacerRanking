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

        [SerializeField]
        private string id = "000000000";

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

            form.AddField("id", id);
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

            Debug.Log(request.downloadHandler.text);

            ResponseLog(request.responseCode);

            if (request.isHttpError || request.isNetworkError)
            {
                Debug.LogError("http Post NG: " + request.error);
                gameObject.GetComponent<Button>().interactable = true;
                Debug.Log("登録に失敗しました");
                yield break;
            }

            Debug.Log("登録が完了しました");

        }

        /// <summary>
        /// @brief 下記サイトのレスポンス結果をLogに出力する
        /// https://developer.mozilla.org/ja/docs/Web/HTTP/Status
        /// </summary>
        /// <param name="code"></param>
        private void ResponseLog(long code)
        {

            switch (code)
            {
                case 200:
                    Debug.Log("success");
                    break;
                case 404:
                    Debug.LogWarning("not found");
                    break;
                case 500:
                    Debug.LogWarning("server error");
                    break;
                default:
                    break;
            }

        }

    }

}