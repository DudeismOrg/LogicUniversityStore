using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversityStore.View
{
    public class Popup
    {
        public static void Show(System.Web.UI.Page context, String page)

        {

            context.Response.Write("  <script language='javascript'> window.open('" + page + "'" + ",'','width=820,Height=520,fullscreen=0,location=1,scrollbars=1,menubar=1,toolbar=1'); </script>");
            //context.Response.Write("  <script language='javascript'  type='text/javascript' src='/View/Resources/plugins/jQuery/jquery-2.2.3.min.js' >  $('#divPopup').load('" + page + "'" + ").dialog({autoOpen:false,show:'blind'}); $('#divPopup').dialog('open');" + " </script>");

        }
    }
}