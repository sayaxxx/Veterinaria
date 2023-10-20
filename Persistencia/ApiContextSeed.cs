using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using Dominio.Entities;
using Microsoft.Extensions.Logging;

namespace Persistencia;
public class ApiContextSeed
{
    public static async Task SeedAsync(ApiContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!context.Veterinarios.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/Veterinario.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Veterinario>();
                        context.Veterinarios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Especies.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/Especie.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Especie>();
                        context.Especies.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Razas.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Raza.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<Raza>();
                        List<Raza> entidad = new List<Raza>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Raza
                            {
                                Id = item.Id,
                                IdEspecieFk = item.IdEspecieFk,
                                Nombre = item.Nombre
                            });
                        }
                        context.Razas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Propietarios.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/Propietario.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Propietario>();
                        context.Propietarios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Proveedores.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/Proveedor.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Proveedor>();
                        context.Proveedores.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Usuarios.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/User.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Usuario>();
                        context.Usuarios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Laboratorios.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/Laboratorio.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Laboratorio>();
                        context.Laboratorios.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TipoMovimientos.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/TipoMovimiento.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<TipoMovimiento>();
                        context.TipoMovimientos.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            
            if (!context.Medicamentos.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Medicamento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<Medicamento>();
                        List<Medicamento> entidad = new List<Medicamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Medicamento
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                CantidadDisponible = item.CantidadDisponible,
                                Precio = item.Precio,
                                IdLaboratorioFk = item.IdLaboratorioFk
                            });
                        }
                        context.Medicamentos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Mascotas.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Mascota.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<Mascota>();
                        List<Mascota> entidad = new List<Mascota>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Mascota
                            {
                                Id = item.Id,
                                IdPropietarioFk = item.IdPropietarioFk,
                                IdRazaFk = item.IdRazaFk,
                                Nombre = item.Nombre,
                                FechaNacimiento = item.FechaNacimiento
                            });
                        }
                        context.Mascotas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            
            if (!context.Citas.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Cita.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<Cita>();
                        List<Cita> entidad = new List<Cita>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Cita
                            {
                                Id = item.Id,
                                IdMascotaFk = item.IdMascotaFk,
                                Fecha = item.Fecha,
                                Hora = item.Hora,
                                Motivo = item.Motivo,
                                IdVeterinarioFk = item.IdVeterinarioFk
                            });
                        }
                        context.Citas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.MedicamentoProveedores.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\MedicamentoProveedor.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<MedicamentoProveedor>();
                        List<MedicamentoProveedor> entidad = new List<MedicamentoProveedor>();
                        foreach (var item in list)
                        {
                            entidad.Add(new MedicamentoProveedor
                            {
                                IdMedicamentoFk = item.IdMedicamentoFk,
                                IdProveedorFk = item.IdProveedorFk 
                            });
                        }
                        context.MedicamentoProveedores.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.MovimientoMedicamentos.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\MovimientoMedicamento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<MovimientoMedicamento>();
                        List<MovimientoMedicamento> entidad = new List<MovimientoMedicamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new MovimientoMedicamento
                            {
                                Id = item.Id,
                                Fecha = item.Fecha,
                                IdTipoMovimientoFk = item.IdTipoMovimientoFk,
                            });
                        }
                        context.MovimientoMedicamentos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }            
            if (!context.DetalleMovimientos.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\DetalleMovimiento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<DetalleMovimiento>();
                        List<DetalleMovimiento> entidad = new List<DetalleMovimiento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new DetalleMovimiento
                            {
                                Id = item.Id,
                                IdMedicamentoFk = item.IdMedicamentoFk,
                                Cantidad = item.Cantidad,
                                IdMovimientoMedicamentoFk = item.IdMovimientoMedicamentoFk,
                                Precio = item.Precio
                            });
                        }
                        context.DetalleMovimientos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TratamientoMedicos.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\TratamientoMedico.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<TratamientoMedico>();
                        List<TratamientoMedico> entidad = new List<TratamientoMedico>();
                        foreach (var item in list)
                        {
                            entidad.Add(new TratamientoMedico
                            {
                                Id = item.Id,
                                IdCitaFk = item.IdCitaFk,
                                IdMedicamentoFk = item.IdMedicamentoFk,
                                Dosis = item.Dosis,
                                FechaAdministracion = item.FechaAdministracion,
                                Observacion = item.Observacion,
                            });
                        }
                        context.TratamientoMedicos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.RolUsuarios.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\RoleUser.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<RolUsuario>();
                        List<RolUsuario> entidad = new List<RolUsuario>();
                        foreach (var item in list)
                        {
                            entidad.Add(new RolUsuario
                            {
                                IdUsuarioFk = item.IdUsuarioFk,
                                IdRolFk = item.IdRolFk
                            });
                        }
                        context.RolUsuarios.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiContext>();
            logger.LogError(ex.Message);
        }
    }
    public static async Task SeedRolesAsync(ApiContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Rol>()
                        {
                            new Rol{Id=1, Nombre="Administrador"},
                            new Rol{Id=2, Nombre="Empleado"},
                        };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiContext>();
            logger.LogError(ex.Message);
        }
    }
}
