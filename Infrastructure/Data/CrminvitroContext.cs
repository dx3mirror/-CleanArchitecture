using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class CrminvitroContext : DbContext
{
    public CrminvitroContext()
    {
    }

    public CrminvitroContext(DbContextOptions<CrminvitroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<TestResult> TestResults { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=62.78.81.19;Initial Catalog=CRMINVITRO;User ID=stud;Password=123456789;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__C22324229873792F");

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.HasKey(e => e.DiagnosisId).HasName("PK__Diagnose__D49E32B42FE75CB6");

            entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__F3993564E4F15811");

            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .HasColumnName("contact_number");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Specialty)
                .HasMaxLength(50)
                .HasColumnName("specialty");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoices__F58DFD4953D8F7E5");

            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.VisitId).HasColumnName("visit_id");

            entity.HasOne(d => d.Visit).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.VisitId)
                .HasConstraintName("FK__Invoices__visit___4AB81AF0");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__4D5CE476748C4EE2");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__3EE444F8FF93EFFB");

            entity.Property(e => e.PrescriptionId).HasColumnName("prescription_id");
            entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");
            entity.Property(e => e.Dosage)
                .HasMaxLength(50)
                .HasColumnName("dosage");
            entity.Property(e => e.Instructions).HasColumnName("instructions");
            entity.Property(e => e.MedicationName)
                .HasMaxLength(100)
                .HasColumnName("medication_name");
            entity.Property(e => e.PrescriptionDate).HasColumnName("prescription_date");
            entity.Property(e => e.VisitId).HasColumnName("visit_id");

            entity.HasOne(d => d.Diagnosis).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.DiagnosisId)
                .HasConstraintName("FK__Prescript__diagn__44FF419A");

            entity.HasOne(d => d.Visit).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.VisitId)
                .HasConstraintName("FK__Prescript__visit__440B1D61");
        });

        modelBuilder.Entity<TestResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__TestResu__AFB3C31672FF2D79");

            entity.Property(e => e.ResultId).HasColumnName("result_id");
            entity.Property(e => e.Result).HasColumnName("result");
            entity.Property(e => e.TestDate).HasColumnName("test_date");
            entity.Property(e => e.TestType)
                .HasMaxLength(100)
                .HasColumnName("test_type");
            entity.Property(e => e.VisitId).HasColumnName("visit_id");

            entity.HasOne(d => d.Visit).WithMany(p => p.TestResults)
                .HasForeignKey(d => d.VisitId)
                .HasConstraintName("FK__TestResul__visit__47DBAE45");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.VisitId).HasName("PK__Visits__375A75E153C45325");

            entity.Property(e => e.VisitId).HasColumnName("visit_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.VisitDatetime)
                .HasColumnType("datetime")
                .HasColumnName("visit_datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.Visits)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Visits__departme__3F466844");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Visits)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Visits__doctor_i__3E52440B");

            entity.HasOne(d => d.Patient).WithMany(p => p.Visits)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Visits__patient___3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
