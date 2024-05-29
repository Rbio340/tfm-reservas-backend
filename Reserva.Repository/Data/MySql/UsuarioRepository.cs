﻿using Microsoft.EntityFrameworkCore;
using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;
using Reserva.Repository.Context;

namespace Reserva.Repository.Data.MySql
{
    public class UsuarioRepository:IUsuarioRepository
    {
        private readonly ReservaContext _context;
        public UsuarioRepository(ReservaContext context) 
        {
            _context = context;
        }

        public void CreateUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public void DeleteUsuario(Usuario usuario)
        {
            _context.Remove(usuario);
            _context.SaveChanges();
        }

        public Usuario GetUsuarioById(int? id)
        {
            return _context.Usuarios.Include(u => u.Est).FirstOrDefault(m => m.UsuId == id);
        }

        public List<Usuario> GetUsuarios()
        {
            return _context.Usuarios.Include(u => u.Est).ToList();
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
    }
}