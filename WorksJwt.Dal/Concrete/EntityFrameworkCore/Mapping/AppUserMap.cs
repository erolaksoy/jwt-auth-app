﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorksJwt.Entities.Concrete;

namespace WorksJwt.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.UserName).HasMaxLength(20).IsRequired();
            builder.HasIndex(x => x.UserName).IsUnique();

            builder.Property(x => x.Password).HasMaxLength(100).IsRequired();
            builder.Property(x => x.FullName).HasMaxLength(60);

            builder.HasMany(x => x.AppUserRoles).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
