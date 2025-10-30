using Application.Interfaces;
using LibraryApi.Data;
using LibraryApi.Infrastructure.Repositories;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LibraryApi.Application.Service
{
    public class BookService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly LibraryDbContext _dbContext;

        public BookService(IUserRepository userRepository, IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public void AlugarLivro(User usuario, Book livro)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            if (livro == null) throw new ArgumentNullException(nameof(livro));

            if (usuario.BookId != 0)
                throw new InvalidOperationException("Usuário já possui um livro alugado.");

            if (livro.Quantity <= 0)
                throw new InvalidOperationException("Livro indisponível para aluguel.");

            livro.Quantity -= 1;
            usuario.BookId = livro.Id;

            if (_bookRepository != null && _userRepository != null)
            {
                if (_dbContext != null)
                {
                    var trx = _dbContext.Database.BeginTransactionAsync().GetAwaiter().GetResult();
                    try
                    {
                        _bookRepository.UpdateAsync(livro).GetAwaiter().GetResult();
                        _userRepository.UpdateAsync(usuario).GetAwaiter().GetResult();
                        trx.CommitAsync().GetAwaiter().GetResult();
                    }
                    catch
                    {
                        trx.RollbackAsync().GetAwaiter().GetResult();
                        throw;
                    }
                }
                else
                {
                    _bookRepository.UpdateAsync(livro).GetAwaiter().GetResult();
                    _userRepository.UpdateAsync(usuario).GetAwaiter().GetResult();
                }
            }
        }
    }
}