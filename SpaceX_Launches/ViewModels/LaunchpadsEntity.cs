
public class Rootobject6
{
    public LaunchpadsData[] Property1 { get; set; }
}

public class LaunchpadsData
{
    public Images images { get; set; }
    public string name { get; set; }
    public string full_name { get; set; }
    public string locality { get; set; }
    public string region { get; set; }
    public float latitude { get; set; }
    public float longitude { get; set; }
    public int launch_attempts { get; set; }
    public int launch_successes { get; set; }
    public string[] rockets { get; set; }
    public string timezone { get; set; }
    public string[] launches { get; set; }
    public string status { get; set; }
    public string details { get; set; }
    public string id { get; set; }
}

public class Images
{
    public string[] large { get; set; }
}
