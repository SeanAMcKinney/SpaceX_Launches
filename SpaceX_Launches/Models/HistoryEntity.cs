
using System;

public class Rootobject3
{
    public HistoryInfo[] Property1 { get; set; }
}

public class HistoryInfo
{
    public Links links { get; set; }
    public string title { get; set; }
    public DateTime event_date_utc { get; set; }
    public int event_date_unix { get; set; }
    public string details { get; set; }
    public string id { get; set; }
}

public class HistoryLinks
{
    public string article { get; set; }
}
