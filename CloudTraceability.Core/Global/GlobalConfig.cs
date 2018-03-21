using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DBI.SaaS.Setting
{
    /// <summary>
    /// 全局配置,请将非密码类敏感信息配置到ServerConfig.json中，
    /// </summary>
    public class GlobalConfig
    {
        /// <summary>
        /// 是否初始化
        /// </summary>
        private static bool hasInit=false;

        private static string hostUrl;

        /// <summary>
        /// The _settings
        /// </summary>
        private static Dictionary<string, string> _settings=new Dictionary<string, string>();

        /// <summary>
        /// The _message
        /// </summary>
        private static Dictionary<string, string> _message = new Dictionary<string, string>();

        /// <summary>
        /// 站点配置
        /// </summary>
        private static Dictionary<string, string> _webSiteInfos = new Dictionary<string, string>();

        /// <summary>
        /// 配置列表
        /// </summary>
        public static Dictionary<string, string> Settings { get { return _settings; } }

        /// <summary>
        /// 配置消息
        /// </summary>
        /// <value>The messages.</value>
        public static Dictionary<string,string> Messages { get { return _message; } }

        /// <summary>
        /// 站点配置
        /// </summary>
        public static Dictionary<string, string> WebSiteInfos { get { return _webSiteInfos; } }

        /// <summary>
        /// 初始化方法
        /// </summary>
        /// <param name="url">The URL.</param>
        public static void Init(string url=null)
        {
            hostUrl = url;
            if (hasInit)
            {
                return;
            }
            string configStr = string.Empty;
            string messageStr = string.Empty;
            var webSiteInfoStr = string.Empty;
            if (string.IsNullOrWhiteSpace(url))
            {
                string path = string.Format("{0}/config", AppDomain.CurrentDomain.BaseDirectory.TrimEnd("/\\".ToCharArray()));
                configStr = File.ReadAllText(string.Format("{0}/{1}", path, "ServerConfig.json"));
                //messageStr = File.ReadAllText(string.Format("{0}/{1}", path, "Message.json"));
                //webSiteInfoStr = File.ReadAllText(string.Format("{0}/{1}", path, "WebSiteInfo.json"));
            }
            else
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("key", "saas.server.web");
                    client.Headers.Add("token", "saas.inner");
                    string address = string.Format("{0}/config/ServerConfig.json", url.TrimEnd("/\\".ToCharArray()));
                    configStr = client.DownloadString(address);
                    //string address2 = string.Format("{0}/config/Message.json", url.TrimEnd("/\\".ToCharArray()));
                    //messageStr = client.DownloadString(address2);
                    //string addressWebSiteInfo = string.Format("{0}/config/WebSiteInfo.json", url.TrimEnd("/\\".ToCharArray()));
                    //webSiteInfoStr = client.DownloadString(addressWebSiteInfo);
                }
            }
        
            _settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(configStr);
            //_message = JsonConvert.DeserializeObject<Dictionary<string, string>>(messageStr);
            //_webSiteInfos = JsonConvert.DeserializeObject<Dictionary<string, string>>(webSiteInfoStr);

            //var messageKeys = new string[_message.Keys.Count];
            //_message.Keys.CopyTo(messageKeys, 0);
            //foreach (var key in messageKeys)
            //{
            //    _message[key] = _message[key].Replace("<%SystemName%>", _webSiteInfos["SystemName"]);
            //}

            hasInit = true;
        }

        public static void Refresh()
        {
            hasInit = false;
            Init(hostUrl);   
        }
    }
}
