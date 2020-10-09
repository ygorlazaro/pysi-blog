#region Using

using System;
using System.Text;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Globalization;
using BlogEngine.Core;

#endregion

public partial class page : BlogEngine.Core.Web.Controls.BlogBasePage
{
	/// <summary>
	/// Handles the Load event of the Page control.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString["deletepage"] != null && Request.QueryString["deletepage"].Length == 36)
		{
			DeletePage(new Guid(Request.QueryString["deletepage"]));
		}

		if (Request.QueryString["id"] != null && Request.QueryString["id"].Length == 36)
		{
			ServePage(new Guid(Request.QueryString["id"]));
			AddMetaTags();
		}
		else
		{
			Response.Redirect(Utils.RelativeWebRoot);
		}
	}

	/// <summary>
	/// Serves the page to the containing DIV tag on the page.
	/// </summary>
	/// <param name="id">The id of the page to serve.</param>
	private void ServePage(Guid id)
	{
		Page = BlogEngine.Core.Page.GetPage(id);

		if (Page == null || (!Page.IsVisible && !User.Identity.IsAuthenticated))
			Response.Redirect(Utils.RelativeWebRoot + "error404.aspx", true);

		h1Title.InnerHtml = this.Page.Title;

		ServingEventArgs arg = new ServingEventArgs(Page.Content, ServingLocation.SinglePage);
		BlogEngine.Core.Page.OnServing(Page, arg);

		if (arg.Cancel)
			Response.Redirect("error404.aspx", true);

		if (arg.Body.ToLowerInvariant().Contains("[usercontrol"))
		{
			InjectUserControls(arg.Body);
		}
		else
		{
			divText.InnerHtml = arg.Body;
		}
	}

	/// <summary>
	/// Adds the meta tags and title to the HTML header.
	/// </summary>
	private void AddMetaTags()
	{
	    if (Page == null) return;
	    Title = Server.HtmlEncode(Page.Title);
	    base.AddMetaTag("keywords", Server.HtmlEncode(Page.Keywords));
	    base.AddMetaTag("description", Server.HtmlEncode(Page.Description));
	}

	/// <summary>
	/// Deletes the page.
	/// </summary>
	private void DeletePage(Guid id)
	{
	    if (!System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated) return;
	    BlogEngine.Core.Page page = BlogEngine.Core.Page.GetPage(id);
	    page.Delete();
	    page.Save();
	    Response.Redirect("~/", true);
	}

	private static readonly Regex _BodyRegex = new Regex(@"\[UserControl:(.*?)\]", RegexOptions.Compiled | RegexOptions.IgnoreCase);

	/// <summary>
	/// Injects any user controls if one is referenced in the text.
	/// </summary>
	private void InjectUserControls(string content)
	{
		int currentPosition = 0;
		MatchCollection myMatches = _BodyRegex.Matches(content);

		foreach (Match myMatch in myMatches)
		{
			if (myMatch.Index > currentPosition)
			{
				divText.Controls.Add(new LiteralControl(content.Substring(currentPosition, myMatch.Index - currentPosition)));
			}

			try
			{
				string all = myMatch.Groups[1].Value.Trim();
				UserControl usercontrol;
				
				if (!all.EndsWith(".ascx", StringComparison.OrdinalIgnoreCase))
				{
					int index = all.IndexOf(".ascx", StringComparison.OrdinalIgnoreCase) +5;
					usercontrol = (UserControl)LoadControl(all.Substring(0, index));
				
					string parameters = Server.HtmlDecode(all.Substring(index));
					Type type = usercontrol.GetType();
					string[] paramCollection = parameters.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
					
					foreach (string param in paramCollection)
					{
						string name = param.Split('=')[0].Trim();
						string value = param.Split('=')[1].Trim();
						System.Reflection.PropertyInfo property = type.GetProperty(name);
						property.SetValue(usercontrol, Convert.ChangeType(value, property.PropertyType, CultureInfo.InvariantCulture), null);
					}
				}
				else
				{
					usercontrol = (UserControl)LoadControl(all);
				}

				divText.Controls.Add(usercontrol);
			}
			catch (Exception)
			{
				divText.Controls.Add(new LiteralControl("ERROR - UNABLE TO LOAD CONTROL : " + myMatch.Groups[1].Value));
			}

			currentPosition = myMatch.Index + myMatch.Groups[0].Length;
		}

		// Finally we add any trailing static text.
		divText.Controls.Add(new LiteralControl(content.Substring(currentPosition, content.Length - currentPosition)));
	}


	/// <summary>
	/// The Page instance to render on the page.
	/// </summary>
	public new BlogEngine.Core.Page Page;

	/// <summary>
	/// Gets the admin links to edit and delete a page.
	/// </summary>
	/// <value>The admin links.</value>
	public string AdminLinks
	{
		get
		{
			if (System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendLine("<div id=\"admin\">");
				sb.AppendFormat("<a href=\"{0}admin/Pages/Pages.aspx?id={1}\">{2}</a> | ", Utils.RelativeWebRoot, Page.Id, Resources.labels.edit);
				sb.AppendFormat("<a href=\"javascript:void(0);\" onclick=\"if (confirm('Are you sure you want to delete the page?')) location.href='?deletepage={0}'\">{1}</a>", Page.Id, Resources.labels.delete);
				sb.AppendLine("</div>");
				return sb.ToString();
			}

			return string.Empty;
		}
	}
}ge={0}'\">{1}</a>", this.Page.Id.ToString(), Resources.labels.delete);
				sb.AppendLine("</div>");
				return sb.ToString();
			}

			return string.Empty;
		}
	}
}