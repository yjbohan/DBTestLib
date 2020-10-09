using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBTestLib
{
    public partial class PRSContext : DbContext
    {
        public PRSContext()
        {
        }

        public PRSContext(DbContextOptions<PRSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lineitem> Lineitem { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DELL-YVONNE\\sqlexpress;database=PRS;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lineitem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.RequestId).HasColumnName("requestID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Lineitem)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lineitem__produc__34C8D9D1");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Lineitem)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lineitem__reques__33D4B598");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.Partnumber)
                    .HasName("UQ__product__4D9CAFD83583CA2A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Partnumber)
                    .IsRequired()
                    .HasColumnName("partnumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photopath)
                    .HasColumnName("photopath")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VendorId).HasColumnName("vendorID");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product__vendorI__2C3393D0");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UQ__Request__CB9A1CDE76AC25DC")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateNeeded)
                    .HasColumnName("dateNeeded")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeliveryMode)
                    .HasColumnName("deliveryMode")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Justification)
                    .HasColumnName("justification")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReasonForRejection)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('New')");

                entity.Property(e => e.SubmittedDate)
                    .HasColumnName("submittedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Request)
                    .HasForeignKey<Request>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Request__userID__300424B4");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Users__F3DBC5720A9FE853")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Isadmin).HasColumnName("isadmin");

                entity.Property(e => e.Isreviewer).HasColumnName("isreviewer");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendor");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasColumnName("zip")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
