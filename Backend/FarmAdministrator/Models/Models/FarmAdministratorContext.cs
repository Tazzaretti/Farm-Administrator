﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models.Models
{
    public partial class FarmAdministratorContext : DbContext
    {
        public FarmAdministratorContext()
        {
        }

        public FarmAdministratorContext(DbContextOptions<FarmAdministratorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminTypes> AdminTypes { get; set; }
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Applications> Applications { get; set; }
        public virtual DbSet<CropTypes> CropTypes { get; set; }
        public virtual DbSet<GroundTypes> GroundTypes { get; set; }
        public virtual DbSet<Harvests> Harvests { get; set; }
        public virtual DbSet<HistoryFuelConsumption> HistoryFuelConsumption { get; set; }
        public virtual DbSet<MachineUserRelationship> MachineUserRelationship { get; set; }
        public virtual DbSet<Machinery> Machinery { get; set; }
        public virtual DbSet<MachineryStateTypes> MachineryStateTypes { get; set; }
        public virtual DbSet<MaintenanceRepairs> MaintenanceRepairs { get; set; }
        public virtual DbSet<Plantings> Plantings { get; set; }
        public virtual DbSet<PlotStateTypes> PlotStateTypes { get; set; }
        public virtual DbSet<Plots> Plots { get; set; }
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        public virtual DbSet<RoleTypes> RoleTypes { get; set; }
        public virtual DbSet<Tokens> Tokens { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Weather> Weather { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminTypes>(entity =>
            {
                entity.HasKey(e => e.IdAdminType);

                entity.Property(e => e.IdAdminType).HasColumnName("Id_AdminType");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Admins>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.Property(e => e.IdAdmin).HasColumnName("Id_Admin");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.HasOne(d => d.AdminTypeNavigation)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.AdminType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admins_RoleTypes");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admins_Users");
            });

            modelBuilder.Entity<Applications>(entity =>
            {
                entity.HasKey(e => e.IdApplication);

                entity.Property(e => e.IdApplication).HasColumnName("id_application");

                entity.Property(e => e.Brand)
                    .HasMaxLength(255)
                    .HasColumnName("brand");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cost");

                entity.Property(e => e.CropType)
                    .HasMaxLength(255)
                    .HasColumnName("crop_type");

                entity.Property(e => e.Dose).HasColumnName("dose");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.IdPlot).HasColumnName("id_plot");

                entity.Property(e => e.Method)
                    .HasMaxLength(255)
                    .HasColumnName("method");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(255)
                    .HasColumnName("product_type");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.IdPlotNavigation)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.IdPlot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applications_Plots");
            });

            modelBuilder.Entity<CropTypes>(entity =>
            {
                entity.HasKey(e => e.IdCrop)
                    .HasName("PK_Crops");

                entity.Property(e => e.IdCrop).HasColumnName("id_crop");

                entity.Property(e => e.CropType)
                    .HasMaxLength(255)
                    .HasColumnName("crop_type");
            });

            modelBuilder.Entity<GroundTypes>(entity =>
            {
                entity.HasKey(e => e.IdGroundType)
                    .HasName("PK_Grounds");

                entity.Property(e => e.IdGroundType).HasColumnName("id_ground_type");

                entity.Property(e => e.GroundType)
                    .HasMaxLength(255)
                    .HasColumnName("ground_type");
            });

            modelBuilder.Entity<Harvests>(entity =>
            {
                entity.HasKey(e => e.IdHarvest)
                    .HasName("PK_Harvest");

                entity.Property(e => e.IdHarvest).HasColumnName("id_harvest");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cost");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.IdCrop).HasColumnName("id_crop");

                entity.Property(e => e.IdPlanting).HasColumnName("id_planting");

                entity.Property(e => e.IdPlot).HasColumnName("id_plot");

                entity.Property(e => e.Method)
                    .HasMaxLength(255)
                    .HasColumnName("method");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Ripeness)
                    .HasMaxLength(255)
                    .HasColumnName("ripeness");

                entity.Property(e => e.Season)
                    .HasMaxLength(255)
                    .HasColumnName("season");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.Yield).HasColumnName("yield");

                entity.HasOne(d => d.IdCropNavigation)
                    .WithMany(p => p.Harvests)
                    .HasForeignKey(d => d.IdCrop)
                    .HasConstraintName("FK_Harvests_CropTypes");

                entity.HasOne(d => d.IdPlotNavigation)
                    .WithMany(p => p.Harvests)
                    .HasForeignKey(d => d.IdPlot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Harvests_Plots");
            });

            modelBuilder.Entity<HistoryFuelConsumption>(entity =>
            {
                entity.HasKey(e => e.IdRecord);

                entity.ToTable("history_fuel_consumption");

                entity.Property(e => e.IdRecord).HasColumnName("id_record");

                entity.Property(e => e.IdMachine).HasColumnName("id_machine");

                entity.Property(e => e.LitersQuantity)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("liters_quantity");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("date")
                    .HasColumnName("record_date");

                entity.HasOne(d => d.IdMachineNavigation)
                    .WithMany(p => p.HistoryFuelConsumption)
                    .HasForeignKey(d => d.IdMachine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_history_fuel_consumption_Machinery");
            });

            modelBuilder.Entity<MachineUserRelationship>(entity =>
            {
                entity.HasKey(e => e.IdRelationship);

                entity.ToTable("Machine_user_relationship");

                entity.Property(e => e.IdRelationship).HasColumnName("id_relationship");

                entity.Property(e => e.IdMachine).HasColumnName("id_machine");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.RelationshipType).HasColumnName("relationship_type");

                entity.HasOne(d => d.IdMachineNavigation)
                    .WithMany(p => p.MachineUserRelationship)
                    .HasForeignKey(d => d.IdMachine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Machine_user_relationship_Machinery");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.MachineUserRelationship)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Machine_user_relationship_Users");
            });

            modelBuilder.Entity<Machinery>(entity =>
            {
                entity.HasKey(e => e.IdMachine);

                entity.Property(e => e.IdMachine).HasColumnName("id_machine");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brand");

                entity.Property(e => e.IdState).HasColumnName("id_state");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.MachineType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("machine_type");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.WorkingHours).HasColumnName("working_hours");

                entity.Property(e => e.YearManufactured)
                    .HasColumnType("date")
                    .HasColumnName("year_manufactured");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Machinery)
                    .HasForeignKey(d => d.IdState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Machinery_Machinery_state_types");
            });

            modelBuilder.Entity<MachineryStateTypes>(entity =>
            {
                entity.HasKey(e => e.IdState);

                entity.ToTable("Machinery_state_types");

                entity.Property(e => e.IdState).HasColumnName("id_state");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<MaintenanceRepairs>(entity =>
            {
                entity.HasKey(e => e.IdMaintenance);

                entity.ToTable("maintenance_repairs");

                entity.Property(e => e.IdMaintenance).HasColumnName("id_maintenance");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("cost");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdMachine).HasColumnName("id_machine");

                entity.Property(e => e.SparePartsUsed)
                    .HasColumnType("text")
                    .HasColumnName("spare_parts_used");

                entity.Property(e => e.WorkedHours).HasColumnName("worked_hours");

                entity.HasOne(d => d.IdMachineNavigation)
                    .WithMany(p => p.MaintenanceRepairs)
                    .HasForeignKey(d => d.IdMachine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_maintenance_repairs_Machinery");
            });

            modelBuilder.Entity<Plantings>(entity =>
            {
                entity.HasKey(e => e.IdPlanting)
                    .HasName("PK_Planting");

                entity.Property(e => e.IdPlanting).HasColumnName("id_planting");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cost");

                entity.Property(e => e.Crop).HasColumnName("crop");

                entity.Property(e => e.Deep).HasColumnName("deep");

                entity.Property(e => e.Distance)
                    .HasMaxLength(10)
                    .HasColumnName("distance")
                    .IsFixedLength();

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.IdPlot).HasColumnName("id_plot");

                entity.Property(e => e.Season)
                    .HasMaxLength(255)
                    .HasColumnName("season");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.HasOne(d => d.CropNavigation)
                    .WithMany(p => p.Plantings)
                    .HasForeignKey(d => d.Crop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plantings_Crops");

                entity.HasOne(d => d.IdPlotNavigation)
                    .WithMany(p => p.Plantings)
                    .HasForeignKey(d => d.IdPlot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plantings_Plots");
            });

            modelBuilder.Entity<PlotStateTypes>(entity =>
            {
                entity.HasKey(e => e.IdState)
                    .HasName("PK_Ground_Types");

                entity.ToTable("Plot_StateTypes");

                entity.Property(e => e.IdState).HasColumnName("id_state");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<Plots>(entity =>
            {
                entity.HasKey(e => e.IdPlot)
                    .HasName("PK_Plot");

                entity.Property(e => e.IdPlot).HasColumnName("id_plot");

                entity.Property(e => e.GroundType).HasColumnName("ground_type");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Latitude)
                    .HasColumnType("decimal(9, 6)")
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasColumnType("decimal(9, 6)")
                    .HasColumnName("longitude");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Owner)
                    .HasMaxLength(255)
                    .HasColumnName("owner");

                entity.Property(e => e.PlotName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("plot_name");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.State).HasColumnName("state");

                entity.HasOne(d => d.GroundTypeNavigation)
                    .WithMany(p => p.Plots)
                    .HasForeignKey(d => d.GroundType)
                    .HasConstraintName("FK_Plots_Grounds");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Plots)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plots_Users");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Plots)
                    .HasForeignKey(d => d.State)
                    .HasConstraintName("FK_Plots_States");
            });

            modelBuilder.Entity<ProductTypes>(entity =>
            {
                entity.HasKey(e => e.IdProductType)
                    .HasName("PK_ProductType");

                entity.Property(e => e.IdProductType).HasColumnName("id_product_type");

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("product_type");
            });

            modelBuilder.Entity<RoleTypes>(entity =>
            {
                entity.HasKey(e => e.IdRoleType);

                entity.Property(e => e.IdRoleType).HasColumnName("id_role_type");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(50)
                    .HasColumnName("role_type");
            });

            modelBuilder.Entity<Tokens>(entity =>
            {
                entity.HasKey(e => e.Token);

                entity.Property(e => e.Token).HasMaxLength(255);

                entity.Property(e => e.ExpirationDate)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Expiration_Date");

                entity.Property(e => e.GenerationDate)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Generation_Date");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Tokens)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tokens_Users");
            });

            modelBuilder.Entity<UserTypes>(entity =>
            {
                entity.HasKey(e => e.IdUserType);

                entity.Property(e => e.IdUserType).HasColumnName("id_user_type");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .HasColumnName("user_type");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Adress)
                    .HasMaxLength(255)
                    .HasColumnName("adress");

                entity.Property(e => e.Education).HasColumnName("education");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("register_date");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.UserRole).HasColumnName("user_role");

                entity.Property(e => e.UserType).HasColumnName("user_type");

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_RoleTypes");

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UserTypes");
            });

            modelBuilder.Entity<Weather>(entity =>
            {
                entity.HasKey(e => e.IdWeather)
                    .HasName("PK_Weathers");

                entity.Property(e => e.IdWeather).HasColumnName("id_weather");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Hail).HasColumnName("hail");

                entity.Property(e => e.Humidity).HasColumnName("humidity");

                entity.Property(e => e.IdPlot).HasColumnName("id_plot");

                entity.Property(e => e.LastFrost)
                    .HasColumnType("date")
                    .HasColumnName("last_frost");

                entity.Property(e => e.MaxTemperature).HasColumnName("max_temperature");

                entity.Property(e => e.MinTemperature).HasColumnName("min_temperature");

                entity.Property(e => e.Precipitation).HasColumnName("precipitation");

                entity.Property(e => e.SoilMoisture).HasColumnName("soil_moisture");

                entity.Property(e => e.SunlightHours).HasColumnName("sunlight_hours");

                entity.Property(e => e.Wind).HasColumnName("wind");

                entity.HasOne(d => d.IdPlotNavigation)
                    .WithMany(p => p.Weather)
                    .HasForeignKey(d => d.IdPlot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Weather_Plots");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}