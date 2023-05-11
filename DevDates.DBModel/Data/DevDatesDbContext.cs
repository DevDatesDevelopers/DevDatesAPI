using System;
using System.Collections.Generic;
using DevDates.DBModel.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DevDates.DBModel.Data;

public partial class DevDatesDbContext : DbContext
{
    public DevDatesDbContext()
    {
    }

    public DevDatesDbContext(DbContextOptions<DevDatesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Interest> Interests { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<ResourcesType> ResourcesTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersPreference> UsersPreferences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { 
        optionsBuilder.UseSqlServer("Server=tcp:devdates.database.windows.net,1433;Initial Catalog=DevDatesDB;Persist Security Info=False;User ID=master;Password=DevKristian1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genders__3214EC07DA6BD736");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Modified).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasMany(d => d.Resources).WithMany(p => p.Genders)
                .UsingEntity<Dictionary<string, object>>(
                    "GendersResource",
                    r => r.HasOne<Resource>().WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__GendersRe__Resou__2DE6D218"),
                    l => l.HasOne<Gender>().WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__GendersRe__Gende__2CF2ADDF"),
                    j =>
                    {
                        j.HasKey("GenderId", "ResourceId").HasName("PK__GendersR__AAC9F1E186608F56");
                        j.ToTable("GendersResources");
                    });
        });

        modelBuilder.Entity<Interest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Interest__3214EC07357635C6");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Modified).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasMany(d => d.Resources).WithMany(p => p.Interests)
                .UsingEntity<Dictionary<string, object>>(
                    "InterestsResource",
                    r => r.HasOne<Resource>().WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Interests__Resou__2645B050"),
                    l => l.HasOne<Interest>().WithMany()
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Interests__Inter__25518C17"),
                    j =>
                    {
                        j.HasKey("InterestId", "ResourceId").HasName("PK__Interest__C46E34712581E9BE");
                        j.ToTable("InterestsResources");
                    });
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => new { e.LikerId, e.LikedId }).HasName("PK__Likes__50BBFF3E916FCE5A");

            entity.Property(e => e.Created).HasColumnType("datetime");

            entity.HasOne(d => d.Liked).WithMany(p => p.LikeLikeds)
                .HasForeignKey(d => d.LikedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__LikedId__395884C4");

            entity.HasOne(d => d.Liker).WithMany(p => p.LikeLikers)
                .HasForeignKey(d => d.LikerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__LikerId__3864608B");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resource__3214EC071098848C");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ResourceUri)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ResourceURI");

            entity.HasOne(d => d.ResourceType).WithMany(p => p.Resources)
                .HasForeignKey(d => d.ResourceTypeId)
                .HasConstraintName("FK__Resources__Resou__208CD6FA");
        });

        modelBuilder.Entity<ResourcesType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resource__3214EC07FF85144A");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Modified).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC076D009CCD");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Bio)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Modified).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__Users__GenderId__1BC821DD");

            entity.HasMany(d => d.Interests).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersInterest",
                    r => r.HasOne<Interest>().WithMany()
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsersInte__Inter__3587F3E0"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsersInte__UserI__3493CFA7"),
                    j =>
                    {
                        j.HasKey("UserId", "InterestId").HasName("PK__UsersInt__7580FE8A3A3E6E5B");
                        j.ToTable("UsersInterests");
                    });

            entity.HasMany(d => d.Resources).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersResource",
                    r => r.HasOne<Resource>().WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsersReso__Resou__2A164134"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsersReso__UserI__29221CFB"),
                    j =>
                    {
                        j.HasKey("UserId", "ResourceId").HasName("PK__UsersRes__F365D45A2520B708");
                        j.ToTable("UsersResources");
                    });
        });

        modelBuilder.Entity<UsersPreference>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.GenderId }).HasName("PK__UsersPre__736A82D3B322C613");

            entity.Property(e => e.Created).HasColumnType("datetime");

            entity.HasOne(d => d.Gender).WithMany(p => p.UsersPreferences)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsersPref__Gende__31B762FC");

            entity.HasOne(d => d.User).WithMany(p => p.UsersPreferences)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsersPref__UserI__30C33EC3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

