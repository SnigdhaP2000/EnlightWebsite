using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntroEnlight
{
    public partial class EnlightDesktop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //File to be downloaded.
            string fileName = "EnlightDesktopApplication.zip";

            //Path of the File to be downloaded.
            string filePath = Server.MapPath(string.Format("~/Software/{0}", fileName));

            //Content Type and Header.
            Response.ContentType = "application/zip";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);

            //Writing the File to Response Stream.
            Response.WriteFile(filePath);

            //Flushing the Response.
            Response.Flush();
            Response.End();
        }
    }
}