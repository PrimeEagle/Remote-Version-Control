using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SourceSafeTypeLib;
using System.Diagnostics;
using System.Web.Security;

namespace RVC
{
	/// <summary>
	/// Summary description for VSSLogin.
	/// </summary>
	public class VSSLogin : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Username;
		protected System.Web.UI.WebControls.TextBox Password;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button bLogin;
		protected System.Web.UI.WebControls.Label Status;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox DefaultProject;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox srcSafeINI;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void bLogin_Click(object sender, System.EventArgs e)
		{
			VSSDatabaseClass vssDB = new VSSDatabaseClass();
	
			try 
			{
				Status.Visible=false;
				vssDB.Open(srcSafeINI.Text,Username.Text,Password.Text);

                HttpCookie c = new HttpCookie(".VSSUSERINFO",Username.Text);
				string valName;
				string valData;
				FormsAuthenticationTicket tkt;

				valName = "INI";
				valData = srcSafeINI.Text;
				tkt = new FormsAuthenticationTicket(1, valName, DateTime.Now, DateTime.Now.AddDays(100), false, valData);
				c.Values.Add(valName, FormsAuthentication.Encrypt(tkt));
                
				valName = "Username";
                valData = Username.Text;
                tkt = new FormsAuthenticationTicket(1, valName, DateTime.Now, DateTime.Now.AddDays(100), false, valData);
                c.Values.Add(valName, FormsAuthentication.Encrypt(tkt));

                valName = "Password";
                valData = Password.Text;
                tkt = new FormsAuthenticationTicket(1, valName, DateTime.Now, DateTime.Now.AddDays(100), false, valData);
                c.Values.Add(valName, FormsAuthentication.Encrypt(tkt));

                valName = "DefaultProject";
                valData = DefaultProject.Text;
                tkt = new FormsAuthenticationTicket(1, valName, DateTime.Now, DateTime.Now.AddDays(100), false, valData);
                c.Values.Add(valName, FormsAuthentication.Encrypt(tkt));

                c.Expires = DateTime.MaxValue;
                c.Path = "/";
                c.Secure = false;
                Response.AppendCookie(c);
				Response.Redirect("Main.aspx");
			} 
			catch(Exception exc){
				Status.Visible=true;
				Status.Text=exc.Message;
            }
		}

	}
}
