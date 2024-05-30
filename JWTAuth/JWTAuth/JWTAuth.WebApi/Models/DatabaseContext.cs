using Microsoft.EntityFrameworkCore;

namespace JWTAuth.WebApi.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee>? Employees { get; set; }
        public virtual DbSet<UserInfo>? UserInfos { get; set; }
        //public virtual DbSet<vendor>? vendor { get; set; }
        public virtual DbSet<PlaceMaster>? PlaceMaster { get; set; }
        public virtual DbSet<Request>? Request { get; set; }
        public virtual DbSet<Sales>? Sales { get; set; }
        public virtual DbSet<Feedback>? Feedback { get; set; }
        public virtual DbSet<FuelMaster>? FuelMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");         

                entity.Property(e => e.EmployeeName)
                      .IsUnicode(false);

                entity.Property(e => e.LoginID)
                      .IsUnicode(false);

                entity.Property(e => e.Designation)
                      .HasMaxLength(250)
                      .IsUnicode(false);

                entity.Property(e => e.BirthDate)
                      .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)  
                      .IsUnicode(false);

                entity.Property(e => e.Gender)     
                      .IsUnicode(false);

                entity.Property(e => e.HireDate)
                      .IsUnicode(false);

                entity.Property(e => e.Status)
                      .IsUnicode(false);

                entity.Property(e => e.AddedBy)
                      .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)                    
                      .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                      .IsUnicode(false);

                entity.Property(e => e.AddedDate)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {               
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackID).HasColumnName("FeedbackID");
               

                entity.Property(e => e.FeedbackDate)                     
                      .IsUnicode(false);

                entity.Property(e => e.RequestId)
                      .IsUnicode(false);

                entity.Property(e => e.UserId)
                     .IsUnicode(false);

                entity.Property(e => e.Status)
                      .IsUnicode(false);

                entity.Property(e => e.Comment)
                 .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.AdminComment)
                 .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                      .IsUnicode(false);

               
            });

            modelBuilder.Entity<PlaceMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PlaceMaster");

                entity.Property(e => e.PlaceId).HasColumnName("PlaceID");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.AddedDate)                   
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);           
            });
            modelBuilder.Entity<FuelMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FuelMaster");

                entity.Property(e => e.FuelId).HasColumnName("FuelId");

                entity.Property(e => e.FuelName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FuelType)
                    .IsUnicode(false);
                entity.Property(e => e.Status)
                    .IsUnicode(false);

                entity.Property(e => e.FuelBasePrice)                    
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.RequestId).HasColumnName("RequestId");

                entity.Property(e => e.UserId)
                      .IsUnicode(false);

                entity.Property(e => e.PlaceId)
                      .IsUnicode(false);
                entity.Property(e => e.FuelId)
                      .IsUnicode(false);
                
                entity.Property(e => e.Status)
                      .IsUnicode(false);

                entity.Property(e => e.Comment)
                   .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RequestDate)
                      .IsUnicode(false);


                entity.Property(e => e.AddedDate)
                    .IsUnicode(false);

                entity.Property(e => e.AddedBy)
                    .IsUnicode(false);
                entity.Property(e => e.UpdatedDate)
                  .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .IsUnicode(false);


            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.ToTable("UserInfo");

                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.Property(e => e.DisplayName)
                    .IsUnicode(false);
                entity.Property(e => e.UserType)
                   .IsUnicode(false);
                entity.Property(e => e.UserName)
                    .IsUnicode(false);              

                entity.Property(e => e.Email)
                    .IsUnicode(false);
                entity.Property(e => e.Phone)
                   .IsUnicode(false);
                entity.Property(e => e.IsLock)
                   .IsUnicode(false);
                entity.Property(e => e.Status)
                   .IsUnicode(false);
                entity.Property(e => e.Password)
                    .IsUnicode(false);
                entity.Property(e => e.AddedBy)
                   .IsUnicode(false);
                entity.Property(e => e.AddedDate)
                    .IsUnicode(false);               
                entity.Property(e => e.UpdatedDate)
                  .IsUnicode(false);
                entity.Property(e => e.UpdatedBy)
                    .IsUnicode(false);
                entity.Property(e => e.Remark)
                   .HasMaxLength(250)
                   .IsUnicode(false);
            });

            modelBuilder.Entity<Sales>(entity =>
            {               
                entity.ToTable("Sales");

                entity.Property(e => e.SalesId).HasColumnName("SalesId");

                entity.Property(e => e.EmployeeID)
                    .IsUnicode(false);
                entity.Property(e => e.RequestID)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceId)
                    .IsUnicode(false);

                entity.Property(e => e.RequestedDate)
                   .IsUnicode(false);

                entity.Property(e => e.AddedDate)
                  .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                 .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                  .HasMaxLength(60)
                  .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
