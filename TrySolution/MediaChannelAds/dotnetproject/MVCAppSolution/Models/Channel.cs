using System;
using System.Collections.Generic;

namespace BookStoreApp.Models;
public class Channel
{
    public int ChannelID { get; set; }

    public string? ChannelName { get; set; }

    public string? POCName { get; set; }

    public decimal? CommercialPerAd { get; set; }

    public string? MailID { get; set; }
    public string? ContactNumber { get; set; }

}