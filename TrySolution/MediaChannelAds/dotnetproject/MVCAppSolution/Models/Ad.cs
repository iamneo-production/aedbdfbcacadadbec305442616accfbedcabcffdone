using System;
using System.Collections.Generic;

namespace BookStoreApp.Models;
public class Ad
{
    public int AdID { get; set; }
    public string BrandName { get; set; }
    public int NumberOfTimes { get; set; }
    public DateTime BroadcastDate { get; set; }
    public int Duration { get; set; }
    public string Description { get; set; }
    public string ChannelName { get; set; }
}
