﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoBD.ModeloBD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConcesionarioBDEntities : DbContext
    {
        public ConcesionarioBDEntities()
            : base("name=ConcesionarioBDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_categoria> tb_categoria { get; set; }
        public virtual DbSet<tb_cliente> tb_cliente { get; set; }
        public virtual DbSet<tb_fotos> tb_fotos { get; set; }
        public virtual DbSet<tb_marca> tb_marca { get; set; }
        public virtual DbSet<tb_proveedor> tb_proveedor { get; set; }
        public virtual DbSet<tb_usuario_vendedor> tb_usuario_vendedor { get; set; }
        public virtual DbSet<tb_vehiculo> tb_vehiculo { get; set; }
        public virtual DbSet<tb_vendedor> tb_vendedor { get; set; }
    }
}
