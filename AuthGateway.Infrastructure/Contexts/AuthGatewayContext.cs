using System;
using System.Collections.Generic;
using AuthGateway.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthGateway.Infrastructure.Contexts;

public partial class AuthGatewayContext : DbContext
{
    public AuthGatewayContext()
    {
    }

    public AuthGatewayContext(DbContextOptions<AuthGatewayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<AuthorizationCode> AuthorizationCodes { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<OauthClient> OauthClients { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SigningKey> SigningKeys { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserConsent> UserConsents { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("audit_logs");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IpAddress)
                .HasDefaultValueSql("'0.0.0.0'::inet")
                .HasColumnName("ip_address");
            entity.Property(e => e.Metadata)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("metadata");
            entity.Property(e => e.UserAgent)
                .HasDefaultValueSql("''::text")
                .HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<AuthorizationCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("authorization_codes_pk");

            entity.ToTable("authorization_codes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CodeChallenge)
                .HasDefaultValueSql("''::text")
                .HasColumnName("code_challenge");
            entity.Property(e => e.CodeHash)
                .HasDefaultValueSql("''::text")
                .HasColumnName("code_hash");
            entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");
            entity.Property(e => e.Nonce)
                .HasDefaultValueSql("''::text")
                .HasColumnName("nonce");
            entity.Property(e => e.RedirectUri)
                .HasDefaultValueSql("''::text")
                .HasColumnName("redirect_uri");
            entity.Property(e => e.Scopes)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("scopes");
            entity.Property(e => e.UsedAt).HasColumnName("used_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_types_pk");

            entity.ToTable("event_types");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(64)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("description");
        });

        modelBuilder.Entity<OauthClient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("oauth_clients_pk");

            entity.ToTable("oauth_clients");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccessTokenLifetimeInSec)
                .HasDefaultValue(900)
                .HasColumnName("access_token_lifetime_in_sec");
            entity.Property(e => e.AllowedGrantTypes)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("allowed_grant_types");
            entity.Property(e => e.AllowedScopes)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("allowed_scopes");
            entity.Property(e => e.ClientId)
                .HasMaxLength(64)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("client_id");
            entity.Property(e => e.ClientSecretHash)
                .HasDefaultValueSql("''::text")
                .HasColumnName("client_secret_hash");
            entity.Property(e => e.ClientType)
                .HasMaxLength(16)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("client_type");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("name");
            entity.Property(e => e.PostLogoutRedirectUris)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("post_logout_redirect_uris");
            entity.Property(e => e.RedirectUris)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("redirect_uris");
            entity.Property(e => e.RefreshTokenLifetimeInSec)
                .HasDefaultValue(604800)
                .HasColumnName("refresh_token_lifetime_in_sec");
            entity.Property(e => e.RequiredConsent)
                .HasDefaultValue(false)
                .HasColumnName("required_consent");
            entity.Property(e => e.RequiredPkce)
                .HasDefaultValue(false)
                .HasColumnName("required_pkce");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("refresh_tokens_pk");

            entity.ToTable("refresh_tokens");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");
            entity.Property(e => e.FamilyId).HasColumnName("family_id");
            entity.Property(e => e.IpAddress)
                .HasDefaultValueSql("'0.0.0.0'::inet")
                .HasColumnName("ip_address");
            entity.Property(e => e.ReplacedById).HasColumnName("replaced_by_id");
            entity.Property(e => e.RevokedAt).HasColumnName("revoked_at");
            entity.Property(e => e.Scopes)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("scopes");
            entity.Property(e => e.TokenHash)
                .HasDefaultValueSql("''::text")
                .HasColumnName("token_hash");
            entity.Property(e => e.UserAgent)
                .HasDefaultValueSql("''::text")
                .HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pk");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("''::text")
                .HasColumnName("description");
            entity.Property(e => e.IsSystem)
                .HasDefaultValue(false)
                .HasColumnName("is_system");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<SigningKey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("signing_keys_pk");

            entity.ToTable("signing_keys");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Algorithm)
                .HasMaxLength(16)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("algorithm");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("is_active");
            entity.Property(e => e.Kid)
                .HasMaxLength(64)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("kid");
            entity.Property(e => e.PrivateKeyPem)
                .HasDefaultValueSql("''::text")
                .HasColumnName("private_key_pem");
            entity.Property(e => e.PublicKeyPem)
                .HasDefaultValueSql("''::text")
                .HasColumnName("public_key_pem");
            entity.Property(e => e.RetiredAt).HasColumnName("retired_at");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_unique_email").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("email");
            entity.Property(e => e.FailedLoginCount)
                .HasDefaultValue(0)
                .HasColumnName("failed_login_count");
            entity.Property(e => e.Fullname)
                .HasMaxLength(128)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("fullname");
            entity.Property(e => e.LockedUntil).HasColumnName("locked_until");
            entity.Property(e => e.PasswordHash)
                .HasDefaultValueSql("''::text")
                .HasColumnName("password_hash");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(128)
                .HasDefaultValueSql("''::character varying")
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserConsent>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.ClientId }).HasName("user_consents_pk");

            entity.ToTable("user_consents");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.GrantedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("granted_at");
            entity.Property(e => e.GrantedScopes)
                .HasDefaultValueSql("'{}'::text[]")
                .HasColumnName("granted_scopes");
            entity.Property(e => e.RevokedAt).HasColumnName("revoked_at");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.ClientId, e.RoleId }).HasName("user_roles_pk");

            entity.ToTable("user_roles");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.AssignedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("assigned_at");
            entity.Property(e => e.AssignedBy).HasColumnName("assigned_by");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
