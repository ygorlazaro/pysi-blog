using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BlogEngine.Core;
using System.Text.RegularExpressions;
using BlogEngine.Core.Web.Controls;

public partial class audio_Admin : System.Web.UI.Page
{
    #region Private members
    private const string _audioroot = "audio/";
    private const string _jsfile = "player.js";
    private const string _ext = "mp3player";

    private const string _width = "width";
    private const string _height = "height";
    private const string _bgColor = "bgColor";

    private const string _bg = "bg";
    private const string _leftbg = "leftbg";
    private const string _lefticon = "lefticon";
    private const string _rightbg = "rightbg";
    private const string _rightbghover = "rightbghover";
    private const string _righticon = "righticon";
    private const string _righticonhover = "righticonhover";
    private const string _text = "text";
    private const string _slider = "slider";
    private const string _track = "track";
    private const string _border = "border";
    private const string _loader = "loader";

    static protected ExtensionSettings _settings = null;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorMsg.InnerHtml = string.Empty;
        ErrorMsg.Visible = false;

        if (!Page.IsPostBack)
        {
            SetDefaultSettings();
            BindForm();
        }

        SetPlayer();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (IsValidForm())
        {
            SaveSettings();
        }
    }

    protected void BindForm()
    {
        btnSave.Text = Resources.labels.saveSettings;

        Control_width.Text = _settings.GetSingleValue(_width);
        Control_height.Text = _settings.GetSingleValue(_height);
        Contrlo_background.Text = _settings.GetSingleValue(_bgColor);
        Player_background.Text = _settings.GetSingleValue(_bg);
        Left_background.Text = _settings.GetSingleValue(_leftbg);
        Left_icon.Text = _settings.GetSingleValue(_lefticon);
        Right_background.Text = _settings.GetSingleValue(_rightbg);
        Right_background_hover.Text = _settings.GetSingleValue(_rightbghover);
        Right_icon.Text = _settings.GetSingleValue(_righticon);
        Right_icon_hover.Text = _settings.GetSingleValue(_righticonhover);
        Text_color.Text = _settings.GetSingleValue(_text);
        Slider.Text = _settings.GetSingleValue(_slider);
        Track.Text = _settings.GetSingleValue(_track);
        Border.Text = _settings.GetSingleValue(_border);
        Loader.Text = _settings.GetSingleValue(_loader);

        lblBgColor.Style["background-color"] = "#" + _settings.GetSingleValue(_bgColor);
        lblBg.Style["background-color"] = "#" + _settings.GetSingleValue(_bg);
        lblLeftBg.Style["background-color"] = "#" + _settings.GetSingleValue(_leftbg);
        lblLeftIcon.Style["background-color"] = "#" + _settings.GetSingleValue(_lefticon);
        lblRightBg.Style["background-color"] = "#" + _settings.GetSingleValue(_rightbg);
        lblRightBgHvr.Style["background-color"] = "#" + _settings.GetSingleValue(_rightbghover);
        lblRightIcon.Style["background-color"] = "#" + _settings.GetSingleValue(_righticon);
        lblRightIconHvr.Style["background-color"] = "#" + _settings.GetSingleValue(_righticonhover);
        lblText.Style["background-color"] = "#" + _settings.GetSingleValue(_text);
        lblSlider.Style["background-color"] = "#" + _settings.GetSingleValue(_slider);
        lblTrack.Style["background-color"] = "#" + _settings.GetSingleValue(_track);
        lblBoarder.Style["background-color"] = "#" + _settings.GetSingleValue(_border);
        lblLoader.Style["background-color"] = "#" + _settings.GetSingleValue(_loader);
    }

    protected bool IsValidForm()
    {
        foreach (Control ctl in formContainer.Controls)
        {
            if (ctl.GetType().Name == "TextBox")
            {
                TextBox box = (TextBox)ctl;

                if (box.Text.Trim().Length == 0)
                {
                    ErrorMsg.InnerHtml = "\"" + box.ID.Replace("_", " ") + "\" is a required field";
                    ErrorMsg.Visible = true;
                    break;
                }
                else
                {
                    if (box.ID == "Control_height" || box.ID == "Control_width")
                    {
                        if (!IsInteger(box.Text))
                        {
                            ErrorMsg.InnerHtml = "\"" + box.ID.Replace("_", " ") + "\" must be a number";
                            ErrorMsg.Visible = true;
                            break;
                        }
                    }
                }
            }
        }

        if (ErrorMsg.InnerHtml.Length > 0)
            return false;
        else
            return true;
    }

    protected void SaveSettings()
    {
        _settings.UpdateScalarValue(_width, Control_width.Text);
        _settings.UpdateScalarValue(_height, Control_height.Text);
        _settings.UpdateScalarValue(_bgColor, Contrlo_background.Text);
        _settings.UpdateScalarValue(_bg, Player_background.Text);
        _settings.UpdateScalarValue(_leftbg, Left_background.Text);
        _settings.UpdateScalarValue(_lefticon, Left_icon.Text);
        _settings.UpdateScalarValue(_rightbg, Right_background.Text);
        _settings.UpdateScalarValue(_rightbghover, Right_background_hover.Text);
        _settings.UpdateScalarValue(_righticon, Right_icon.Text);
        _settings.UpdateScalarValue(_righticonhover, Right_icon_hover.Text);
        _settings.UpdateScalarValue(_text, Text_color.Text);
        _settings.UpdateScalarValue(_slider, Slider.Text);
        _settings.UpdateScalarValue(_track, Track.Text);
        _settings.UpdateScalarValue(_border, Border.Text);
        _settings.UpdateScalarValue(_loader, Loader.Text);

        ExtensionManager.SaveSettings(_ext, _settings);
        Response.Redirect(Request.RawUrl);
    }

    protected void SetLabelColor(Label label, string color)
    {
        label.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + color);
    }

    protected void SetDefaultSettings()
    {
        ExtensionSettings settings = new ExtensionSettings(_ext);

        settings.AddParameter(_width);
        settings.AddParameter(_height);
        settings.AddParameter(_bgColor);
        settings.AddParameter(_bg);
        settings.AddParameter(_leftbg);
        settings.AddParameter(_lefticon);
        settings.AddParameter(_rightbg);
        settings.AddParameter(_rightbghover);
        settings.AddParameter(_righticon);
        settings.AddParameter(_righticonhover);
        settings.AddParameter(_text);
        settings.AddParameter(_slider);
        settings.AddParameter(_track);
        settings.AddParameter(_border);
        settings.AddParameter(_loader);

        settings.AddValue(_width, "290");
        settings.AddValue(_height, "24");
        settings.AddValue(_bgColor, "ffffff");
        settings.AddValue(_bg, "f8f8f8");
        settings.AddValue(_leftbg, "eeeeee");
        settings.AddValue(_lefticon, "666666");
        settings.AddValue(_rightbg, "cccccc");
        settings.AddValue(_rightbghover, "999999");
        settings.AddValue(_righticon, "666666");
        settings.AddValue(_righticonhover, "ffffff");
        settings.AddValue(_text, "666666");
        settings.AddValue(_slider, "666666");
        settings.AddValue(_track, "ffffff");
        settings.AddValue(_border, "666666");
        settings.AddValue(_loader, "9FFFB8");

        settings.IsScalar = true;
        ExtensionManager.ImportSettings(settings);
        _settings = ExtensionManager.GetSettings(_ext);
    }

    public static bool IsInteger(string theValue)
    {
        Regex _isNumber = new Regex(@"^\d+$");
        Match m = _isNumber.Match(theValue);
        return m.Success;
    }

    #region Player functions
    
    protected void SetPlayer()
    {
        AddJsToTheHeader();

        string player = PlayerObject();
        player = "<script type=\"text/javascript\">InsertPlayer(\"" + player + "\");</script>";
        litPlayer.Text = player;
    }
    private string PlayerObject()
    {
        string sFile = HttpUtility.UrlEncode(AudioRoot() + "test.mp3");

        string s = "<p>"
        + "<object type='application/x-shockwave-flash' data='{0}player.swf' id='audioplayer{1}' height='{18}' width='{17}'>"
        + "<param name='movie' value='{0}player.swf'>"
        + "<param name='FlashVars' value='playerID={1}&bg=0x{5}&leftbg=0x{6}&lefticon=0x{7}&rightbg=0x{8}&rightbghover=0x{9}&righticon=0x{10}&righticonhover=0x{11}&text=0x{12}&slider=0x{13}&track=0x{14}&border=0x{15}&loader=0x{16}&soundFile={2}'>"
        + "<param name='quality' value='high'>"
        + "<param name='menu' value='{3}'>"
        + "<param name='bgcolor' value='{4}'>"
        + "</object>"
        + "</p>";

        return String.Format(s, AudioRoot(), 1, sFile, "No",
            _settings.GetSingleValue(_bgColor),
            _settings.GetSingleValue(_bg),
            _settings.GetSingleValue(_leftbg),
            _settings.GetSingleValue(_lefticon),
            _settings.GetSingleValue(_rightbg),
            _settings.GetSingleValue(_rightbghover),
            _settings.GetSingleValue(_righticon),
            _settings.GetSingleValue(_righticonhover),
            _settings.GetSingleValue(_text),
            _settings.GetSingleValue(_slider),
            _settings.GetSingleValue(_track),
            _settings.GetSingleValue(_border),
            _settings.GetSingleValue(_loader),
            _settings.GetSingleValue(_width),
            _settings.GetSingleValue(_height));
    }
    private void AddJsToTheHeader()
    {
        // get a page handler
        System.Web.UI.Page pg = (System.Web.UI.Page)HttpContext.Current.CurrentHandler;
        bool added = false;

        // check if script already added to the page header
        foreach (Control ctl in pg.Header.Controls)
        {
            if (ctl.GetType() == typeof(HtmlGenericControl))
            {
                HtmlGenericControl gc = (HtmlGenericControl)ctl;
                if (gc.Attributes["src"] != null)
                {
                    if (gc.Attributes["src"].Contains(_jsfile))
                    {
                        added = true;
                    }
                }
            }
        }

        if (!added)
        {
            HtmlGenericControl js = new HtmlGenericControl("script");
            js.Attributes.Add("type", "text/javascript");
            js.Attributes.Add("src", AudioRoot() + _jsfile);

            pg.Header.Controls.Add(js);
        }
    }
    private string AudioRoot()
    {
        string VirtualPath = HttpContext.Current.Request.Path;
        string audioRoot = VirtualPath.Substring(0, VirtualPath.LastIndexOf("/") + 1);
        return audioRoot;
    }

    #endregion
}
