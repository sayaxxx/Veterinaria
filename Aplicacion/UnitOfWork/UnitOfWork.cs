using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork  : IUnitOfWork, IDisposable
{
    private readonly ApiContext _context;
    private CitaRepository _citas;
    private DetalleMovimientoRepository _detalleMovimientos;
    private EspecieRepository _especies;
    private LaboratorioRepository _laboratorios;
    private MascotaRepository _mascotas;
    private MedicamentoRepository _medicamentos;
    private MovimientoMedicamentoRepository _movimientoMedicamentos;
    private PropietarioRepository _propietarios;
    private ProveedorRepository _proveedores;
    private RazaRepository _razas;
    private RolRepository _Rol;
    private TipoMovimientoRepository _tipoMovimientos;
    private TratamientoMedicoRepository _tratamientoMedicos;
    private UsuarioRepository _usuarios;
    private VeterinarioRepository _veterionarios;

    public UnitOfWork(ApiContext context){
        _context = context;
    }

    public ICita Citas{
        get{
            if(_citas== null)
            {
                _citas= new CitaRepository(_context);
            }
            return _citas;
        }
    }

    public IDetalleMovimiento DetalleMovimientos{
        get{
            if(_detalleMovimientos== null)
            {
                _detalleMovimientos= new DetalleMovimientoRepository(_context);
            }
            return _detalleMovimientos;
        }
    }

    public IEspecie Especies{
        get{
            if(_especies== null)
            {
                _especies= new EspecieRepository(_context);
            }
            return _especies;
        }
    }

    public ILaboratorio Laboratorios{
        get{
            if(_laboratorios== null)
            {
                _laboratorios= new LaboratorioRepository(_context);
            }
            return _laboratorios;
        }
    }

    public IMascota Mascotas{
        get{
            if(_mascotas== null)
            {
                _mascotas= new MascotaRepository(_context);
            }
            return _mascotas;
        }
    }

    public IMedicamento Medicamentos{
        get{
            if(_medicamentos== null)
            {
                _medicamentos= new MedicamentoRepository(_context);
            }
            return _medicamentos;
        }
    }

    public IMovimientoMedicamento MovimientoMedicamentos{
        get{
            if(_movimientoMedicamentos== null)
            {
                _movimientoMedicamentos= new MovimientoMedicamentoRepository(_context);
            }
            return _movimientoMedicamentos;
        }
    }

    public IPropietario Propietarios{
        get{
            if(_propietarios== null)
            {
                _propietarios= new PropietarioRepository(_context);
            }
            return _propietarios;
        }
    }

    public IProveedor Proveedores{
        get{
            if(_proveedores== null)
            {
                _proveedores= new ProveedorRepository(_context);
            }
            return _proveedores;
        }
    }

    public IRaza Razas{
        get{
            if(_razas== null)
            {
                _razas= new RazaRepository(_context);
            }
            return _razas;
        }
    }

    public IRol Roles{
        get{
            if(_Rol== null)
            {
                _Rol= new RolRepository(_context);
            }
            return _Rol;
        }
    }

    public ITipoMovimiento TipoMovimientos{
        get{
            if(_tipoMovimientos== null)
            {
                _tipoMovimientos= new TipoMovimientoRepository(_context);
            }
            return _tipoMovimientos;
        }
    }

    public ITratamientoMedico TratamientoMedicos{
        get{
            if(_tratamientoMedicos== null)
            {
                _tratamientoMedicos= new TratamientoMedicoRepository(_context);
            }
            return _tratamientoMedicos;
        }
    }

    public IUsuario Usuarios{
        get{
            if(_usuarios== null)
            {
                _usuarios= new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }

    public IVeterinario Veterinarios{
        get{
            if(_veterionarios== null)
            {
                _veterionarios= new VeterinarioRepository(_context);
            }
            return _veterionarios;
        }
    }

    public void Dispose(){
        _context.Dispose();
    }

    public async Task<int> SaveAsync(){
        return await _context.SaveChangesAsync();
    }
    
}
