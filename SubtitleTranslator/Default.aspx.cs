using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;

namespace SubtitleTranslator
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           SrtOku(FileUpload1);

        }
        #region Public methods

        /// <summary>
        /// Translates the specified source text. source https://github.com/Airstriker/GoogleTranslator/blob/master/Translator.cs
        /// </summary>
        /// <param name="sourceText">The source text.</param>
        /// <param name="sourceLanguage">The source language.</param>
        /// <param name="targetLanguage">The target language.</param>
        /// <returns>The translation.</returns>
        public string Translate
            (string sourceText,
             string sourceLanguage,
             string targetLanguage)
        {
       

            string translation = string.Empty;

            try
            {
                // Download translation
                string translationFromGoogle = "";

                //Using secret translate.googleapis.com API that is internally used by the Google Translate extension for Chrome and requires no authentication
                string url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
                                            "en","tr" ,
                                            HttpUtility.UrlEncode(sourceText));
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                    wc.Encoding = System.Text.Encoding.UTF8;
                    translationFromGoogle = wc.DownloadString(url);
                }

                // Get translated text
                //https://translate.googleapis.com/translate_a/single?client=gtx&sl=en&tl=tr&dt=t&q=hello%world
                //[[["Selam Dünya","hello world",null,null,1]],null,"en"]
                var json = JsonConvert.DeserializeObject(translationFromGoogle);
                translation = ((((json as JArray).First() as JArray).First() as JArray).First() as JValue).Value.ToString();

                // And translation speech URL

                ////Using secret translate.googleapis.com API that is internally used by the Google Translate extension for Chrome and requires no authentication
                //this.TranslationSpeechUrl = string.Format("https://translate.googleapis.com/translate_tts?ie=UTF-8&q={0}&tl={1}&total=1&idx=0&textlen={2}&client=gtx",
                //                                            HttpUtility.UrlEncode(translation), Translator.LanguageEnumToIdentifier(targetLanguage), translation.Length);
            }
            catch (Exception ex)
            {
                
            }
             
            return translation;
        }

        #endregion
        public void SrtOku(FileUpload fu)
        {

            if (fu.HasFile )
            {
                string all = ""; 
                HttpPostedFile  upload = fu.PostedFile;
            string     FOName = Path.GetFileName(fu.PostedFile.FileName);
            StreamReader Reader = new StreamReader(upload.InputStream);
            {
                string inputLine = "";
                while ((inputLine =  Reader.ReadLine()) != null)
                {
                    string[] values = inputLine.Split(    new[] { Environment.NewLine },    StringSplitOptions.None);
                    foreach (string word in values)
                    {
                        all +=word+"<br>" ;
                    }
                }
                Reader.Close();

                Label1.Text = all;
            }
            
            }
        }
    }
}
