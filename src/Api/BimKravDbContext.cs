using BimKrav.Api.Tables;
using Microsoft.EntityFrameworkCore;

namespace BimKrav.Api;

public class BimKravDbContext : DbContext
{
    public BimKravDbContext(DbContextOptions<BimKravDbContext> options) : base(options)
    {
    }

    public virtual DbSet<DisciplineRevitCategoryTbl> DisciplineRevitCategories { get; set; } = null!;
    public virtual DbSet<RevitCategoryIfcTypeTbl> RevitCategoryIfcTypes { get; set; } = null!;
    public virtual DbSet<RevitCategoryPropertiesTbl> RevitCategoryProperties { get; set; } = null!;
    public virtual DbSet<PhasePropertyTbl> PhaseProperties { get; set; } = null!;
    public virtual DbSet<IfcTypePSetTbl> IfcTypePSets { get; set; } = null!;
    public virtual DbSet<PropertyPhaseTbl> PropertyPhase { get; set; } = null!;
    public virtual DbSet<ProjectPropertyTbl> ProjectProperties { get; set; } = null!;
    public virtual DbSet<PsetPropertyTbl> PSetProperties { get; set; } = null!;
    public virtual DbSet<DisciplineTbl> Disciplines { get; set; } = null!;
    public virtual DbSet<PhaseTbl> Phases { get; set; } = null!;
    public virtual DbSet<IfcTypeTbl> IfcTypes { get; set; } = null!;
    public virtual DbSet<ProjectTbl> Projects { get; set; } = null!;
    public virtual DbSet<PropertyTbl> Properties { get; set; } = null!;
    public virtual DbSet<PSetTbl> PSets { get; set; } = null!;
    public virtual DbSet<RevitCategoryTbl> RevitCategories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasCharSet("latin1")
            .UseCollation("latin1_swedish_ci");

        modelBuilder.Entity<DisciplineRevitCategoryTbl>(entity =>
        {
            entity.HasKey(e => new { e.DisciplineId, ElementId = e.RevitCategoryId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.HasIndex(e => e.RevitCategoryId, "FK_element");

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
        });

        modelBuilder.Entity<RevitCategoryPropertiesTbl>(entity =>
        {
            entity.HasKey(e => new { IdElement = e.RevitCategoryId, IdProperty = e.PropertyId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.HasIndex(e => e.PropertyId, "FK_element_property_junction_copy_tblproperty_copy");

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

            entity.HasIndex(e => e.PropertyId, "FK_property");

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

            entity.HasIndex(e => e.PsetId, "FK_Pset");

            entity.HasOne(d => d.IfcType)
                .WithMany(p => p.IfcTypePset)
                .HasForeignKey(d => d.IfcTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entitet");

            entity.HasOne(d => d.Pset)
                .WithMany(p => p.IfcTypes)
                .HasForeignKey(d => d.PsetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pset");
        });


        modelBuilder.Entity<ProjectPropertyTbl>(entity =>
        {
            entity.HasKey(e => new { IDProject = e.ProjectId, IDProperty = e.PropertyId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.HasIndex(e => e.ProjectId, "ID_Project");

            entity.HasIndex(e => e.PropertyId, "ID_Property");

            entity.HasOne(d => d.Project)
                .WithMany(x => x.ProjectProperties)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("ID_Project5");

            entity.HasOne(d => d.Property)
                .WithMany(x => x.ProjectProperties)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("ID_Property5");
        });

        modelBuilder.Entity<PsetPropertyTbl>(entity =>
        {
            entity.HasKey(e => new { IdPset = e.PSetId, IdProperty = e.PropertyId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("pset_property_junction");

            entity.HasIndex(e => e.PropertyId, "FK_property");

            entity.HasOne(d => d.Property)
                .WithMany(p => p.PSetProperties)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_property3");

            entity.HasOne(d => d.PSet)
                .WithMany(p => p.Properties)
                .HasForeignKey(d => d.PSetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pset2");
        });

        modelBuilder.Entity<DisciplineTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");
        });

        modelBuilder.Entity<PhaseTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");
        });


        modelBuilder.Entity<IfcTypeTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");
        });

        modelBuilder.Entity<ProjectTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");
            

            entity.HasComment("This table list all ongoing and completed hospital porjects lead by Sykehusbygg HF");
        });

        modelBuilder.Entity<PropertyTbl>(entity =>      
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");
        });

        modelBuilder.Entity<PSetTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");
        });

        modelBuilder.Entity<RevitCategoryTbl>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PRIMARY");
        });
    }
}