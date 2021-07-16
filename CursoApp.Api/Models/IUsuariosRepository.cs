using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoApp.Shared.DataBaseModels;

namespace CursoApp.Api.Models
{
    public interface IUsuariosRepository
    {
        IEnumerable<Usuarios> GetAllUsuarios();
        Usuarios GetUsuarioById(int usuarioId);
        Usuarios AddUsuario(Usuarios usuario);
        void UpdateUsuario(Usuarios usuario);
        int GetCountUsuario();
        void DeleteUsuarioById(int usuarioId);
    }
}
