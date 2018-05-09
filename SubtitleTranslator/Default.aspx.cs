using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

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
                        all +=word ;
                    }
                }
                Reader.Close();

                Label1.Text = all;
            }
            
            }
        }
    }
}
