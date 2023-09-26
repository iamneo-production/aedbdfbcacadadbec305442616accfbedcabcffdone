using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStoreDBFirst.Models;

public class ChannelAdDbContext : DbContext
{

    public ChannelAdDbContext(DbContextOptions<ChannelAdDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Channel> Channels { get; set; }
    public virtual DbSet<Ad> Ads { get; set; }
}
