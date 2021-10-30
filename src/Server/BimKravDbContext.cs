using System;
using BimKrav.Server.Tables.Undecided;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BimKrav.Server;

public class BimKravDbContext : DbContext
{
    public BimKravDbContext(DbContextOptions<BimKravDbContext> options) : base(options)
    {
    }
        
    public virtual DbSet<DisciplineRevitCategoryTbl> DisciplineRevitCategories { get; set; }
    public virtual DbSet<RevitCategoryIfcTypeTbl> RevitCategoryIfcTypes { get; set; }
    public virtual DbSet<RevitCategoryPropertiesTbl> RevitCategoryProperties { get; set; }
    public virtual DbSet<PhasePropertyTbl> PhaseProperties { get; set; }
    public virtual DbSet<IfcTypePSetTbl> IfcTypePSets { get; set; }
    public virtual DbSet<PropertyPhaseTbl> PropertyPhase { get; set; }
    public virtual DbSet<ProjectPropertyTbl> ProjectProperties { get; set; }
    public virtual DbSet<PropertyRegexTbl> PropertyRegexes { get; set; }
    public virtual DbSet<PsetPropertyTbl> PSetProperties { get; set; }
    public virtual DbSet<DisciplineTbl> Discplines { get; set; }
    public virtual DbSet<PhaseTbl> Phases { get; set; }
    public virtual DbSet<IfcTypeTbl> IfcTypes { get; set; }
    public virtual DbSet<MasterKravTbl> MasterKrav { get; set; }
    public virtual DbSet<ProjectTbl> Projects { get; set; }
    public virtual DbSet<PropertyTbl> Properties { get; set; }
    public virtual DbSet<PSetTbl> PSets { get; set; }
    public virtual DbSet<RegexTbl> Regexes { get; set; }
    public virtual DbSet<RevitCategoryTbl> RevitCategories { get; set; }
    public virtual DbSet<ViewMasterkrav> ViewMasterkravs { get; set; }
    public virtual DbSet<ViewMasterkravProject> ViewMasterkravProjects { get; set; }
    public virtual DbSet<ViewMasterkravwithifcclass> ViewMasterkravwithifcclasses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasCharSet("latin1")
            .UseCollation("latin1_swedish_ci");

        modelBuilder.Entity<DisciplineRevitCategoryTbl>(entity =>
        {
            entity.HasKey(e => new { e.DisciplineId, ElementId = e.RevitCategoryId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("dicipline_element_junction");

            entity.HasIndex(e => e.RevitCategoryId, "FK_element");

            entity.Property(e => e.DisciplineId)
                .HasColumnType("int(11)")
                .HasColumnName("disciplineID");

            entity.Property(e => e.RevitCategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("elementID");

            entity.HasOne(d => d.Discipline)
                .WithMany(p => p.DisciplineRevitCategories)
                .HasForeignKey(d => d.DisciplineId)
                .HasConstraintName("FK_discipline");

            entity.HasOne(d => d.RevitCategory)
                .WithMany(p => p.DisciplineRevitCategories)
                .HasForeignKey(d => d.RevitCategoryId)
                .HasConstraintName("FK_element");
        });

        modelBuilder.Entity<RevitCategoryIfcTypeTbl>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("element_ifcentitet_junction");

            entity.Property(e => e.IfcTypeName)
                .HasColumnType("tinytext")
                .HasColumnName("IFCEntityName")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.RevitCategoryName)
                .HasColumnType("tinytext")
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<RevitCategoryPropertiesTbl>(entity =>
        {
            entity.HasKey(e => new { IdElement = e.RevitCategoryId, IdProperty = e.PropertyId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("element_property_junction");

            entity.HasIndex(e => e.PropertyId, "FK_element_property_junction_copy_tblproperty_copy");

            entity.Property(e => e.RevitCategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Element");

            entity.Property(e => e.PropertyId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Property");

            entity.Property(e => e.PSetId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_PSet")
                .HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.RevitCategory)
                .WithMany(p => p.ElementProperties)
                .HasForeignKey(d => d.RevitCategoryId)
                .HasConstraintName("element_property_junction_ibfk_1");

            entity.HasOne(d => d.Property)
                .WithMany(p => p.RevitCategoryProperties)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_element_property_junction_copy_tblproperty_copy");
        });

        modelBuilder.Entity<PhasePropertyTbl>(entity =>
        {
            entity.HasKey(e => new { FaseId = e.PhaseId, e.PropertyId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("fase_property_junction");

            entity.HasIndex(e => e.PropertyId, "FK_property");

            entity.Property(e => e.PhaseId)
                .HasColumnType("int(11)")
                .HasColumnName("faseID");

            entity.Property(e => e.PropertyId)
                .HasColumnType("int(11)")
                .HasColumnName("propertyID");

            entity.HasOne(d => d.Phase)
                .WithMany(p => p.PhaseProperties)
                .HasForeignKey(d => d.PhaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fase");

            entity.HasOne(d => d.Property)
                .WithMany(p => p.PhaseProperties)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_property2");
        });

        modelBuilder.Entity<IfcTypePSetTbl>(entity =>
        {
            entity.HasKey(e => new { IdEntitet = e.IfcTypeId, IdPset = e.PsetId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("ifcentitet_pset_junction");

            entity.HasIndex(e => e.PsetId, "FK_Pset");

            entity.Property(e => e.IfcTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Entitet");

            entity.Property(e => e.PsetId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Pset");

            entity.HasOne(d => d.IfcType)
                .WithMany(p => p.IfcTypePset)
                .HasForeignKey(d => d.IfcTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entitet");

            entity.HasOne(d => d.Pset)
                .WithMany(p => p.IfcentitetPsetJunctions)
                .HasForeignKey(d => d.PsetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pset");
        });
        
        modelBuilder.Entity<PropertyPhaseTbl>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("property_fase_flagg_junction");

            entity.Property(e => e.Arbeidstegning).HasColumnType("tinyint(4)");

            entity.Property(e => e.Detaljprosjekt).HasColumnType("tinyint(4)");

            entity.Property(e => e.Forprosjekt).HasColumnType("tinyint(4)");

            entity.Property(e => e.PropertyId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Property");

            entity.Property(e => e.PSetId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Pset");

            entity.Property(e => e.Overlevering).HasColumnType("tinyint(4)");

            entity.Property(e => e.Skisseprosjekt).HasColumnType("tinyint(4)");
        });

        modelBuilder.Entity<ProjectPropertyTbl>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("property_project_junction");

            entity.HasIndex(e => e.ProjectId, "ID_Project");

            entity.HasIndex(e => e.PropertyId, "ID_Property");

            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Project")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.PropertyId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Property")
                .HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.Project)
                .WithMany()
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("ID_Project5");

            entity.HasOne(d => d.Property)
                .WithMany()
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("ID_Property5");
        });

        modelBuilder.Entity<PropertyRegexTbl>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("property_regex_junction");

            entity.HasComment("Relation table between Properties and Regex strings");

            entity.HasIndex(e => e.RegexId, "FK_property_regex_junction_tblregex");

            entity.HasIndex(e => e.PropertyId, "ID");

            entity.Property(e => e.PropertyId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Property")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.RegexId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Regex")
                .HasDefaultValueSql("'NULL'");

            entity.HasOne(d => d.Property)
                .WithMany()
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("ID");

            entity.HasOne(d => d.Regex)
                .WithMany()
                .HasForeignKey(d => d.RegexId)
                .HasConstraintName("FK_property_regex_junction_tblregex");
        });

        modelBuilder.Entity<PsetPropertyTbl>(entity =>
        {
            entity.HasKey(e => new { IdPset = e.PSetId, IdProperty = e.PropertyId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("pset_property_junction");

            entity.HasIndex(e => e.PropertyId, "FK_property");

            entity.Property(e => e.PSetId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Pset");

            entity.Property(e => e.PropertyId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Property");

            entity.HasOne(d => d.Property)
                .WithMany(p => p.PSetProperties)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_property3");

            entity.HasOne(d => d.PSet)
                .WithMany(p => p.PsetProperties)
                .HasForeignKey(d => d.PSetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pset2");
        });

        modelBuilder.Entity<DisciplineTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");

            entity.ToTable("tbldiscipline");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Discipline");

            entity.Property(e => e.Code)
                .HasColumnType("text")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<PhaseTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");

            entity.ToTable("tblfase");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Fase");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("text");
        });
        

        modelBuilder.Entity<IfcTypeTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");

            entity.ToTable("tblifcentitet");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID_entitet");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("text");
        });

        modelBuilder.Entity<MasterKravTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");

            entity.ToTable("tblmasterkrav");

            entity.HasIndex(e => e.ElementId, "FK_Element2121");

            entity.HasIndex(e => e.PropertyId, "FK_Property2121");

            entity.HasIndex(e => e.PSetId, "FK_Pset2121");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Main");

            entity.Property(e => e.Arbeidstegning).HasColumnType("tinyint(4)");

            entity.Property(e => e.Detaljprosjekt).HasColumnType("tinyint(4)");

            entity.Property(e => e.Forprosjekt).HasColumnType("tinyint(4)");

            entity.Property(e => e.ElementId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Element");

            entity.Property(e => e.PropertyId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Property");

            entity.Property(e => e.PSetId)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Pset");

            entity.Property(e => e.IfcPropertyType)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.Overlevering).HasColumnType("tinyint(4)");

            entity.Property(e => e.PropertyGroup)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.PropertyName)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.PsetName)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.RevitCategory)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.RevitPropertyType)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.Skisseprosjekt).HasColumnType("tinyint(4)");

            entity.HasOne(d => d.Properties)
                .WithMany(p => p.MasterKrav)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Property2121");

            entity.HasOne(d => d.PSets)
                .WithMany(p => p.Tblmasterkravs)
                .HasForeignKey(d => d.PSetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pset2121");
        });

        modelBuilder.Entity<ProjectTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");

            entity.ToTable("tblproject");

            entity.HasComment("This table list all ongoing and completed hospital porjects lead by Sykehusbygg HF");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Project");

            entity.Property(e => e.Code)
                .HasColumnType("text")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<PropertyTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");

            entity.ToTable("tblproperty");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Property");

            entity.Property(e => e.IfcPropertyType)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.Initiator)
                .HasColumnType("text")
                .HasColumnName("Initiert av")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.HasB2Origin)
                .HasColumnType("tinyint(4)")
                .HasColumnName("Kommer fra 2B")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.PropertyComment)
                .IsRequired()
                .HasColumnType("text")
                .HasDefaultValueSql("'''--'''");

            entity.Property(e => e.PropertyDescription)
                .HasColumnType("text")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.PropertyGroup)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.PropertyGuid)
                .HasMaxLength(36)
                .HasColumnName("PropertyGUID")
                .HasDefaultValueSql("'uuid()'")
                .IsFixedLength();

            entity.Property(e => e.PropertyName)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.RevitPropertyType)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.TypeInstance)
                .IsRequired()
                .HasColumnType("text")
                .HasDefaultValueSql("'''Instans'''");
        });

        modelBuilder.Entity<PSetTbl>(entity =>
        {
            entity.HasKey(e => e.IdPset)
                .HasName("PRIMARY");

            entity.ToTable("tblpset");

            entity.Property(e => e.IdPset)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Pset");

            entity.Property(e => e.PsetDescription)
                .HasColumnType("text")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.PsetName)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.PsetOrigin)
                .HasColumnType("text")
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<RegexTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");

            entity.ToTable("tblregex");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Regex");

            entity.Property(e => e.RegexString)
                .HasColumnType("text")
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<RevitCategoryTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");

            entity.ToTable("tblrevitelements");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Element");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("text");
        });

        modelBuilder.Entity<ViewMasterkrav>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("view_masterkrav");

            entity.Property(e => e.Arbeidstegning).HasColumnType("tinyint(4)");

            entity.Property(e => e.Detaljprosjekt).HasColumnType("tinyint(4)");

            entity.Property(e => e.DisciplineCode)
                .HasColumnType("text")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.Forprosjekt).HasColumnType("tinyint(4)");

            entity.Property(e => e.IdElement)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Element");

            entity.Property(e => e.IdProperty)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Property");

            entity.Property(e => e.IdPset)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Pset");

            entity.Property(e => e.IfcPropertyType)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.Overlevering).HasColumnType("tinyint(4)");

            entity.Property(e => e.PropertyGroup)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.PropertyName)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.PsetName)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.RevitElement)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.RevitPropertyType)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.Skisseprosjekt).HasColumnType("tinyint(4)");

            entity.Property(e => e.TypeInstans)
                .IsRequired()
                .HasColumnType("text")
                .HasDefaultValueSql("'''Instans'''");
        });

        modelBuilder.Entity<ViewMasterkravProject>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("view_masterkrav_project");

            entity.Property(e => e.Arbeidstegning).HasColumnType("tinyint(4)");

            entity.Property(e => e.Detaljprosjekt).HasColumnType("tinyint(4)");

            entity.Property(e => e.DisciplineCode)
                .HasColumnType("text")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.Forprosjekt).HasColumnType("tinyint(4)");

            entity.Property(e => e.IdElement)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Element");

            entity.Property(e => e.IdProperty)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Property");

            entity.Property(e => e.IdPset)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Pset");

            entity.Property(e => e.IfcPropertyType)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.Overlevering).HasColumnType("tinyint(4)");

            entity.Property(e => e.ProjectCode)
                .HasColumnType("text")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.PropertyGroup)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.PropertyGuid)
                .HasMaxLength(36)
                .HasColumnName("PropertyGUID")
                .HasDefaultValueSql("'uuid()'")
                .IsFixedLength();

            entity.Property(e => e.PropertyName)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.PsetName)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.RevitElement)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.RevitPropertyType)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.Skisseprosjekt).HasColumnType("tinyint(4)");

            entity.Property(e => e.TypeInstans)
                .IsRequired()
                .HasColumnType("text")
                .HasDefaultValueSql("'''Instans'''");
        });

        modelBuilder.Entity<ViewMasterkravwithifcclass>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("view_masterkravwithifcclasses");

            entity.Property(e => e.Arbeidstegning).HasColumnType("tinyint(4)");

            entity.Property(e => e.Detaljprosjekt).HasColumnType("tinyint(4)");

            entity.Property(e => e.DisiplinKode)
                .HasColumnType("text")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.Forprosjekt).HasColumnType("tinyint(4)");

            entity.Property(e => e.IdElement)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Element");

            entity.Property(e => e.IdProperty)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Property");

            entity.Property(e => e.IdPset)
                .HasColumnType("int(11)")
                .HasColumnName("ID_Pset");

            entity.Property(e => e.IfcPropertyType)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.Ifcclass)
                .HasColumnType("tinytext")
                .HasColumnName("IFCClass")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.Overlevering).HasColumnType("tinyint(4)");

            entity.Property(e => e.PropertyGroup)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.PropertyName)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.PsetDescription)
                .HasColumnType("text")
                .HasDefaultValueSql("'NULL'");

            entity.Property(e => e.PsetName)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.RevitPropertyType)
                .IsRequired()
                .HasColumnType("text");

            entity.Property(e => e.Skisseprosjekt).HasColumnType("tinyint(4)");
        });
    }
}