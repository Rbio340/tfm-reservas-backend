﻿using Microsoft.EntityFrameworkCore;
using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;
using Reserva.Repository.Context;

namespace Reserva.Repository.Data.MySql
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ReservaContext _context;
        public UsuarioRepository(ReservaContext context) 
        {
            _context = context;
        }

        public void CreateUsuario(Usuario usuario)
        {
            usuario.EstId = 1;
            usuario.IdRol = 2;
            usuario.UsuPassword = usuario.Cedula;
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public void DeleteUsuario(Usuario usuario)
        {
            _context.Update(usuario);
            _context.SaveChanges();
        }

        public Usuario GetUsuarioById(int? id)
        {
            return _context.Usuarios.Include(u => u.Est).Include(u => u.IdRolNavigation).FirstOrDefault(m => m.UsuId == id);
        }

        public List<Usuario> GetUsuarios()
        {
            return _context.Usuarios.Include(u => u.Est).Include(u=> u.IdRolNavigation).Where(u=> u.IdRol == 2).ToList();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _context.Update(usuario);
            _context.SaveChanges();
        }

        public bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(m => m.UsuId == id);
        }

        public bool UsuarioExistsByCedula(string cedula)
        {
            return _context.Usuarios.Any(u => u.Cedula == cedula);
        }

        public bool UsuarioExistsByNombreUsuario(string nombreUsuario)
        {
            return _context.Usuarios.Any(u => u.UsuNombre == nombreUsuario);
        }

        public Usuario ValidateUser(string username, string password)
        {
            return _context.Usuarios.Include(u => u.IdRolNavigation).SingleOrDefault(u => u.UsuNombre == username && u.UsuPassword == password);
        }
    }
}