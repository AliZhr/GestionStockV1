using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GestionStockV1.Models
{
    public partial class StockMagasinContext : DbContext
    {
        public StockMagasinContext()
        {
        }

        public StockMagasinContext(DbContextOptions<StockMagasinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Mouvement> Mouvements { get; set; }
        public virtual DbSet<ServicePersonne> ServicePersonnes { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=A-343S004;Database=StockMagasin;User Id=sa;Password=Rosny_2012;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.Property(e => e.ArticleId).HasColumnName("article_id");

                entity.Property(e => e.ArticleDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("article_description");

                entity.Property(e => e.ArticleName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("article_name");

                entity.Property(e => e.ArticleSeuilSecurite).HasColumnName("article_seuil_securite");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ClientEmail)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("client_email");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("client_name");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");
            });

            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.ToTable("fournisseur");

                entity.Property(e => e.FournisseurId)
                    .ValueGeneratedNever()
                    .HasColumnName("fournisseur_id");

                entity.Property(e => e.Actif).HasColumnName("actif");

                entity.Property(e => e.FournisseurName)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("fournisseur_name");

                entity.Property(e => e.NumeroFournisseur).HasColumnName("numero_fournisseur");
            });

            modelBuilder.Entity<Mouvement>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("mouvement_id");

                entity.ToTable("mouvement");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.Property(e => e.DestinataireId).HasColumnName("destinataire_id");

                entity.Property(e => e.ExpediteurId).HasColumnName("expediteur_id");

                entity.Property(e => e.MouvementArticleId).HasColumnName("mouvement_article_id");

                entity.Property(e => e.NumCommande).HasColumnName("num_commande");

                entity.Property(e => e.Qte).HasColumnName("qte");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("transaction_date");

                entity.Property(e => e.TransactionHeure).HasColumnName("transaction_heure");

                entity.Property(e => e.TransactipnType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("transactipn_type");
            });

            modelBuilder.Entity<ServicePersonne>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("service_id");

                entity.ToTable("servicePersonne");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.ServiceNom)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("service_nom");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("stock");

                entity.Property(e => e.StockId).HasColumnName("stock_id");

                entity.Property(e => e.ArticleQte).HasColumnName("article_qte");

                entity.Property(e => e.StockArticleId).HasColumnName("stock_article_id");

                entity.HasOne(d => d.StockArticle)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.StockArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Article_stock_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
