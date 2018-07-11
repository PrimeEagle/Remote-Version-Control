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

namespace RVC {
	public class Main : System.Web.UI.Page {
		protected System.Web.UI.WebControls.DropDownList ddlProject;
		protected System.Web.UI.WebControls.ListBox lbFiles;
		protected System.Web.UI.WebControls.ListBox lbCheckedOutFiles;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button bChangeProject;
		protected System.Web.UI.WebControls.Button bUp;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button bCheckOut;
		protected System.Web.UI.WebControls.Button bGetLatest;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button bCheckIn;
		protected System.Web.UI.WebControls.Button bUndoCheckout;
		protected System.Web.UI.WebControls.Label Status;
		protected System.Web.UI.WebControls.Label lblCurrentProject;		
		protected VSSDatabaseClass vssDB = new VSSDatabaseClass();
		protected System.Web.UI.WebControls.Label lblUsername;
		protected System.Web.UI.WebControls.Label lblPassword;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox tbCheckInComments;
		protected System.Web.UI.WebControls.TextBox tbWorkingFolder;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Button bChangeWorkingFolder;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label lblSrcSafeINI;
		
		private void Page_Load(object sender, System.EventArgs e) {
			if (!Page.IsPostBack) 
			{
				// Put user code to initialize the page here
				HttpCookie c = Request.Cookies.Get(".VSSUSERINFO");

				lblUsername.Text = FormsAuthentication.Decrypt(c.Values.Get("Username").ToString()).UserData.ToString();
				lblPassword.Text = FormsAuthentication.Decrypt(c.Values.Get("Password").ToString()).UserData.ToString();
				lblCurrentProject.Text = FormsAuthentication.Decrypt(c.Values.Get("DefaultProject").ToString()).UserData.ToString();
				lblSrcSafeINI.Text = FormsAuthentication.Decrypt(c.Values.Get("INI").ToString()).UserData.ToString();
			} 

			try 
			{
				vssDB.Open(lblSrcSafeINI.Text,lblUsername.Text,lblPassword.Text);
				Status.Text="";
			}
			catch(Exception exc)
			{
				Status.Text=exc.Message;
			}

			if (!Page.IsPostBack) 
			{
				RefreshData();
			}
		}

		public void RefreshData() {
			ddlProject.ClearSelection();
			ddlProject.Items.Clear();
			lbFiles.Items.Clear();
			lbFiles.ClearSelection();
			lbCheckedOutFiles.Items.Clear();
			lbCheckedOutFiles.ClearSelection();

			IVSSItems items;
			IVSSItem item;
			System.Collections.IEnumerator en;
			
			try {
				tbWorkingFolder.Text = vssDB.get_VSSItem(lblCurrentProject.Text, false).LocalSpec;
				
				items = vssDB.get_VSSItem(lblCurrentProject.Text,false).get_Items(false);
				en = items.GetEnumerator();
				en.Reset();

				for (int i=1; i<=items.Count; i++) 
				{
					en.MoveNext();
					item = (IVSSItem)en.Current;

					if (item.Type == 1) // File
					{
						if (item.IsCheckedOut == 2) // checked out
						{
							lbCheckedOutFiles.Items.Add(item.Name);
						}
						else // not checked out
						{
							lbFiles.Items.Add(item.Name);
						} 
					}
					else if (item.Type == 0) // Folder/Project
					{
						ddlProject.Items.Add(item.Name);
					}
			}
			
				Status.Text="";
			}
			catch(Exception exc)
			{
				Status.Text=exc.Message;
			}
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
			this.bChangeProject.Click += new System.EventHandler(this.bChangeProject_Click);
			this.bUp.Click += new System.EventHandler(this.bUp_Click);
			this.bCheckOut.Click += new System.EventHandler(this.bCheckOut_Click);
			this.bGetLatest.Click += new System.EventHandler(this.bGetLatest_Click);
			this.bCheckIn.Click += new System.EventHandler(this.bCheckIn_Click);
			this.bUndoCheckout.Click += new System.EventHandler(this.bUndoCheckout_Click);
			this.bChangeWorkingFolder.Click += new System.EventHandler(this.bChangeWorkingFolder_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void bUp_Click(object sender, System.EventArgs e) {
			try {
				lblCurrentProject.Text = (vssDB.get_VSSItem(lblCurrentProject.Text, false)).Parent.Spec;
				RefreshData();
				Status.Text="";
			}
			catch(Exception exc)
			{
				Status.Text=exc.Message;
			}
		}

		private void bChangeProject_Click(object sender, System.EventArgs e) {
			try {
				lblCurrentProject.Text = lblCurrentProject.Text + "/" + ddlProject.SelectedItem.Text;
				RefreshData();
				Status.Text="";
			}
			catch(Exception exc)
			{
				Status.Text=exc.Message;
			}
		}

		private void bGetLatest_Click(object sender, System.EventArgs e) {
			try 
			{
				foreach(ListItem li in lbFiles.Items)
				{
					if (li.Selected == true) 
					{
						string spec = lblCurrentProject.Text + "/" + li.Text;
						string localSpec = vssDB.get_VSSItem(spec, false).LocalSpec;
						vssDB.get_VSSItem(spec, false).Get(ref localSpec,0);
					}
				}
				RefreshData();
				Status.Text="";
			}
			catch(Exception exc) 
			{
				Status.Text=exc.Message;
			}
		}

		private void bCheckOut_Click(object sender, System.EventArgs e) {
			try 
			{
				foreach(ListItem li in lbFiles.Items)
				{
					if (li.Selected == true) 
					{
						string spec = lblCurrentProject.Text + "/" + li.Text;
						string localSpec = vssDB.get_VSSItem(spec, false).LocalSpec;
						vssDB.get_VSSItem(spec, false).Checkout("",localSpec,0);
					}
				}
				RefreshData();
				Status.Text="";
			}
			catch(Exception exc) 
			{
				Status.Text=exc.Message;
			}
		}

		private void bUndoCheckout_Click(object sender, System.EventArgs e) {
			try 
			{
				foreach(ListItem li in lbCheckedOutFiles.Items)
				{
					if (li.Selected == true) 
					{
						string spec = lblCurrentProject.Text + "/" + li.Text;
						string localSpec = vssDB.get_VSSItem(spec, false).LocalSpec;
						vssDB.get_VSSItem(spec, false).UndoCheckout(localSpec,0);
					}
				}
				RefreshData();
				Status.Text="";
			}
			catch(Exception exc) 
			{
				Status.Text=exc.Message;
			}		
		}

		private void bCheckIn_Click(object sender, System.EventArgs e) {
			try 
			{
				if (tbCheckInComments.Text.Length > 0) 
				{
					foreach(ListItem li in lbCheckedOutFiles.Items)
					{
						if (li.Selected == true) 
						{
							string spec = lblCurrentProject.Text + "/" + li.Text;
							string localSpec = vssDB.get_VSSItem(spec, false).LocalSpec;
							vssDB.get_VSSItem(spec, false).Checkin(tbCheckInComments.Text, localSpec, 0);
						}
					}
					RefreshData();
					Status.Text="";
					tbCheckInComments.Text="";
				}
				else 
				{
					Status.Text="You must provide comments in order to Checkin.";
				}
			}
			catch(Exception exc) 
			{
				Status.Text=exc.Message;
			}		
		}

		private void bChangeWorkingFolder_Click(object sender, System.EventArgs e) {
			try 
			{
				vssDB.get_VSSItem(lblCurrentProject.Text, false).LocalSpec = tbWorkingFolder.Text;
				RefreshData();
				Status.Text="";
			}
			catch(Exception exc)
			{
				Status.Text=exc.Message;
			}

		}
	}
}
