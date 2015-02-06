
/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class pref_info
{

    private pref_infoPref[] prefField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("pref")]
    public pref_infoPref[] pref
    {
        get
        {
            return this.prefField;
        }
        set
        {
            this.prefField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class pref_infoPref
{

    private byte pref_idField;

    private string pref_nameField;

    private pref_infoPrefArea[] areaField;

    /// <remarks/>
    public byte pref_id
    {
        get
        {
            return this.pref_idField;
        }
        set
        {
            this.pref_idField = value;
        }
    }

    /// <remarks/>
    public string pref_name
    {
        get
        {
            return this.pref_nameField;
        }
        set
        {
            this.pref_nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("area")]
    public pref_infoPrefArea[] area
    {
        get
        {
            return this.areaField;
        }
        set
        {
            this.areaField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class pref_infoPrefArea
{

    private ushort area_idField;

    private pref_infoPrefAreaArea_name area_nameField;

    private string longField;

    private string latField;

    /// <remarks/>
    public ushort area_id
    {
        get
        {
            return this.area_idField;
        }
        set
        {
            this.area_idField = value;
        }
    }

    /// <remarks/>
    public pref_infoPrefAreaArea_name area_name
    {
        get
        {
            return this.area_nameField;
        }
        set
        {
            this.area_nameField = value;
        }
    }

    /// <remarks/>
    public string @long
    {
        get
        {
            return this.longField;
        }
        set
        {
            this.longField = value;
        }
    }

    /// <remarks/>
    public string lat
    {
        get
        {
            return this.latField;
        }
        set
        {
            this.latField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class pref_infoPrefAreaArea_name
{

    private decimal longField;

    private decimal latField;

    private string[] textField;

    /// <remarks/>
    public decimal @long
    {
        get
        {
            return this.longField;
        }
        set
        {
            this.longField = value;
        }
    }

    /// <remarks/>
    public decimal lat
    {
        get
        {
            return this.latField;
        }
        set
        {
            this.latField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
        }
    }
}

