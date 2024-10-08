﻿using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repository.Interface
{
    public interface ITarefaRepository
    {
        Task<List<TarefaModel>> BuscarTodasTarefas();
        Task<TarefaModel>BuscarPorId(int id);

        Task<TarefaModel> Adicionar(TarefaModel tarefa);

        Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);

        Task<bool> Apagar(int ind);                 
    }
}
