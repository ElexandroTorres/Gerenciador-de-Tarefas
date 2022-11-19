﻿using GerenciadorDeTarefas.Data;
using GerenciadorDeTarefas.Models;

namespace GerenciadorDeTarefas.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Todo AddTodo(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return todo;
        }

        public bool DeleteTodo(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Todo EditTodo(Todo todo)
        {
            Todo todoFromDB = FindTodoById(todo.Id);

            todoFromDB.Title = todo.Title;
            todoFromDB.DateOfConclusion = todo.DateOfConclusion;

            _context.Todos.Update(todoFromDB);
            _context.SaveChanges();

            return todoFromDB;
        }

        public Todo FindTodoById(int id)
        {
            return _context.Todos.First(todo => todo.Id == id);
        }
    }
}