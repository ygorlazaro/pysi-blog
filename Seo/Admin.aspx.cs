using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class seo_Admin : System.Web.UI.Page
{
    static protected ExtensionSettings _settings = null;
    public ExtensionSettings settings;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            loadsettings();
            setForm();
        }
    }

    protected void loadsettings()
    {
        // create settings object. You need to pass exactly your
        // extension class name (case sencitive)
        settings = new ExtensionSettings("seopack");

        settings.AddParameter("ParamName", "ParamName", 70, true);
        settings.AddParameter("Value", "Value", 250, true);
        settings.AddParameter("Desc", "Value", 250, true);

        settings.Help = "SEO Pack: Optimizes your BlogEngine blog for Search Engines (SEO). Ver: 0.0.2";

        settings.AddValues(new string[] { "HomeTitle", "", "HomeTitle" });
        settings.AddValues(new string[] { "HomeDescription", "", "HomeDescription" });
        settings.AddValues(new string[] { "HomeKeywords", "", "HomeKeywords" });
        settings.AddValues(new string[] { "PostTitleFormat", "[BlogTitle] - [PostTitle]", "[BlogTitle] = Blog Title [PostTitle] = Post Title" });
        settings.AddValues(new string[] { "PageTitleFormat", "[BlogTitle] - [PageTitle]", "[PageTitle] = Blog Title [PostTitle] = Page Title" });
        settings.AddValues(new string[] { "GenerateTextForDescPost", "YES", "Yes/No" });
        settings.AddValues(new string[] { "CharsForDescPost", "200", "Integer" });
        settings.AddValues(new string[] { "UseCategoriesForMetaKeywords", "YES", "Values: Yes/No" });
        settings.AddValues(new string[] { "UseTagsForMetaKeywords", "NO", "Values: Yes/No" });

        settings.IsScalar = true;
        ExtensionManager.ImportSettings(settings);
        _settings = ExtensionManager.GetSettings("seopack");
    }


    private void setForm(){
        btnSave.Text = Resources.labels.saveSettings;
    
        //load values
        seo_hometitle.Text = GetValue("HomeTitle");
        seo_home_description.Text = GetValue("HomeDescription");
        seo_home_keywords.Text = GetValue("HomeKeywords");
        seo_post_title_format.Text = GetValue("PostTitleFormat");
        seo_page_title_format.Text = GetValue("PageTitleFormat");

        if (GetValue("GenerateTextForDescPost").ToUpper() == "YES")
        {
            check_autogenerate_descriptions.Checked = true;
        }
        else {
            check_autogenerate_descriptions.Checked = false;        
        }

        seo_char_lemgth.Text = GetValue("CharsForDescPost");

        if (GetValue("UseCategoriesForMetaKeywords").ToUpper() == "YES")
        {
            check_use_categories_for_meta_keywords.Checked = true;
        }
        else
        {
            check_use_categories_for_meta_keywords.Checked = false;
        }

        if (GetValue("UseTagsForMetaKeywords").ToUpper() == "YES")
        {
            check_use_tags_for_meta_keywords.Checked = true;
        }
        else
        {
            check_use_tags_for_meta_keywords.Checked = false;
        }       
    }

    private string GetValue(string param_name)
    {
        DataTable table = _settings.GetDataTable();
        foreach (DataRow row in table.Rows)
        {
            if (!string.IsNullOrEmpty((string)row["ParamName"]))
            {
                string strParam = (string)row["ParamName"];
                if (strParam == param_name)
                {
                    return (string)row["Value"];
                }
            }
        }
        return null;
    }


    protected void SaveSettings()
    {

        _settings.Parameters[1].Values[0] = seo_hometitle.Text;
        _settings.Parameters[1].Values[1] = seo_home_description.Text;
        _settings.Parameters[1].Values[2] = seo_home_keywords.Text;
        _settings.Parameters[1].Values[3] = seo_post_title_format.Text;
        _settings.Parameters[1].Values[4] = seo_page_title_format.Text;

        if (check_autogenerate_descriptions.Checked)
        {
            _settings.Parameters[1].Values[5] = "YES";
        }
        else
        {
            _settings.Parameters[1].Values[5] = "NO";
        }

        _settings.Parameters[1].Values[6] = seo_char_lemgth.Text;


        if (check_use_categories_for_meta_keywords.Checked)
        {
            _settings.Parameters[1].Values[7] = "YES";
        }
        else
        {
            _settings.Parameters[1].Values[7] = "NO";
        }

        if (check_use_tags_for_meta_keywords.Checked)
        {
            _settings.Parameters[1].Values[8] = "YES";
        }
        else
        {
            _settings.Parameters[1].Values[8] = "NO";
        }
        ExtensionManager.SaveSettings("seopack", _settings);
        Response.Redirect(Request.RawUrl);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveSettings();
    }
}
