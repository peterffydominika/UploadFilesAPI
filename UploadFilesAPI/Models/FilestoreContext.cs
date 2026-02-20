using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UploadFilesAPI.Models;

public partial class FilestoreContext : DbContext
{
    public FilestoreContext()
    {
    }

    public FilestoreContext(DbContextOptions<FilestoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<File> Files { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySQL("server=localhost;database=filestore;user=root;password=password");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("files");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContentType)
                .HasMaxLength(255)
                .HasColumnName("contentType");
            entity.Property(e => e.FileData).HasColumnName("fileData");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("fileName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
