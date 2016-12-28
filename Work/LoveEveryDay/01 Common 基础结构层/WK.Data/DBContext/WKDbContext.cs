using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Reflection;

namespace WK.Data
{
    public class WKDbContext 
    {
        //public WKDbContext()
        //    : base("NFineDbContext")
        //{
        //    this.Configuration.AutoDetectChangesEnabled = false;
        //    this.Configuration.ValidateOnSaveEnabled = false;
        //    this.Configuration.LazyLoadingEnabled = false;
        //    this.Configuration.ProxyCreationEnabled = false;
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("NFine.Data.DLL", "NFine.Mapping.DLL").Replace("file:///", "");
        //    Assembly asm = Assembly.LoadFile(assembleFileName);
        //    var typesToRegister = asm.GetTypes()
        //    .Where(type => !String.IsNullOrEmpty(type.Namespace))
        //    .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
        //    foreach (var type in typesToRegister)
        //    {
        //        dynamic configurationInstance = Activator.CreateInstance(type);
        //        modelBuilder.Configurations.Add(configurationInstance);
        //    }
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
