using Javsdt.Shared;
using Javsdt.Shared.Model;
using Javsdt.Shared.Model.Middle;
using Javsdt.Shared.Model.Property;
using Microsoft.EntityFrameworkCore;

namespace Javsdt.API
{
    public class JavsdtContext : DbContext
    {
        // 单数据库用下面
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(@$"Data Source={EnvSettings.ProjectDirectory}\Javsdt.db");
        //}

        // Asp用下面
        public JavsdtContext(DbContextOptions<JavsdtContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 设置联合组键
            modelBuilder.Entity<MovieCast>().HasKey(mc => new { mc.MovieId, mc.CastId });
            modelBuilder.Entity<MovieCompany>().HasKey(mc => new { mc.MovieId, mc.CompanyId });
            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.MovieId, mg.GenreId });
            modelBuilder.Entity<MovieTag>().HasKey(mt => new { mt.MovieId, mt.TagId });

            modelBuilder.Entity<Movie>()
                .HasOne(movie => movie.Series)
                .WithMany(series => series.Movies)
                .HasForeignKey(movie => movie.SeriesId);

            modelBuilder.Entity<MovieCast>()
                .HasOne(movieCast => movieCast.Movie)
                .WithMany(movie => movie.MovieCasts)
                .HasForeignKey(moviecast => moviecast.MovieId);
            modelBuilder.Entity<MovieCast>()
                .HasOne(movieCast => movieCast.Cast)
                .WithMany(cast => cast.MovieCasts)
                .HasForeignKey(moviecast => moviecast.CastId);

            modelBuilder.Entity<MovieCompany>()
                .HasOne(movieCompany => movieCompany.Movie)
                .WithMany(movie => movie.MovieCompanys)
                .HasForeignKey(movieCompany => movieCompany.MovieId);
            modelBuilder.Entity<MovieCompany>()
                .HasOne(movieCompany => movieCompany.Company)
                .WithMany(company => company.MovieCompanys)
                .HasForeignKey(movieCompany => movieCompany.CompanyId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId);
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);

            modelBuilder.Entity<MovieTag>()
                .HasOne(mt => mt.Movie)
                .WithMany(m => m.MovieTags)
                .HasForeignKey(mt => mt.MovieId);
            modelBuilder.Entity<MovieTag>()
                .HasOne(mt => mt.Tag)
                .WithMany(t => t.MovieTags)
                .HasForeignKey(mt => mt.TagId);
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }

        public DbSet<Company> Companys { get; set; }
        public DbSet<MovieCompany> MovieCompanys { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<MovieTag> MovieTags { get; set; }

        public DbSet<Series> Serieses { get; set; }

        public DbSet<CarPref> CarPrefs { get; set; }

        public DbSet<PopularCast> PopularCasts { get; set; }
    }
}
