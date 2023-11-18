using Microsoft.EntityFrameworkCore;
using GeekLifeAPI.Models;
using GeekLifeAPI.Data.EfCore;
using Dapper;
using System.Data;

namespace GeekLifeAPI.Data.CategoriaRepository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly CategoriaContext _context;

        public CategoriaRepository(CategoriaContext context)
        {
            _context = context;
        }

        #region

        //    public Categoria Post([FromBody] CreateCategoriaDto categoriaDto)
        //    {

        //        bool nomeRepetido = _context.Categorias.Any(c => c.NomeDaCategoria == categoriaDto.NomeDaCategoria) ||
        //        _context.Subs.Any(s => s.NomeDaSub == categoriaDto.NomeDaCategoria);

        //        if (nomeRepetido)
        //        {
        //            throw new ArgumentException("O nome utilizado ja existe na lista, tente um diferente dos existentes!");
        //        }
        //        Categoria categoria = _mapper.Map<Categoria>(categoriaDto); //Mapeando Categoria em categoriaDto

        //        _context.Categorias.Add(categoria);
        //        _context.SaveChanges();

        //        return categoria;          
        //    }

        //    public IEnumerable<ReadCategoriaDto> Get ([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? status = null, [FromQuery] string? ordenacao = null, [FromQuery] string? nome = null)
        //    {
        //        IQueryable<Categoria> filtrosCategorias = _context.Categorias;



        //        if (!string.IsNullOrEmpty(nome) && (nome.Length >= 3))
        //        {
        //            filtrosCategorias = filtrosCategorias.Where(c => c.NomeDaCategoria.ToLower().Contains(nome.ToLower()));
        //        }
        //        else if (!string.IsNullOrEmpty(nome) && (nome.Length < 3))
        //        {
        //            throw new ArgumentException("O filtro 'nome' deve conter pelo menos 3 caracteres");
        //        }

        //        if (!string.IsNullOrEmpty(status))
        //        {
        //            if ((status.ToLower() == "ativa") || (status.ToLower() == "ativo"))
        //            {
        //                filtrosCategorias = filtrosCategorias.Where(c => c.Atividade == true);
        //            }
        //            else if ((status.ToLower() == "inativa") || (status.ToLower() == "inativo"))
        //            {
        //                filtrosCategorias = filtrosCategorias.Where(c => c.Atividade == false);
        //            }
        //            else if ((status.ToLower() != "todos") || (status.ToLower() != "todos"))
        //            {
        //                throw new ArgumentException("Valor inválido para o parâmetro 'status'.");
        //            }
        //        }


        //        if (!string.IsNullOrEmpty(ordenacao))
        //        {
        //            if (ordenacao.ToLower() == "decrescente")
        //            {
        //                filtrosCategorias = filtrosCategorias.OrderByDescending(c => c.NomeDaCategoria);
        //            }
        //            else if (ordenacao.ToLower() == "crescente")
        //            {
        //                filtrosCategorias = filtrosCategorias.OrderBy(c => c.NomeDaCategoria);

        //            }
        //            else
        //            {
        //                throw new ArgumentException("Valor inválido para o parâmetro 'ordenacao'.");
        //            }

        //        }



        //        filtrosCategorias = filtrosCategorias.Skip(skip).Take(take);

        //        var categorias = filtrosCategorias.ToList();

        //        var categoriasDto = _mapper.Map<List<ReadCategoriaDto>>(categorias);

        //        return categoriasDto;       
        //    }
        //    public  ReadCategoriaDto GetId(int id)
        //    {
        //        var categoria = /*GetFirstId(id);*/   _context.Categorias.FirstOrDefault(c => c.Id == id);


        //        if (categoria == null )
        //        {
        //            throw new Exception("Id não encontrado");
        //        }


        //        var categoriaDto = _mapper.Map<ReadCategoriaDto>(categoria);

        //        return categoriaDto;

        //    }

        //    public UpdateCategoriaDto Put (int id, [FromBody] UpdateCategoriaDto categoriaDto) //<<<<<<<<<<<<<<<<<<<< Testar
        //    {


        //        Categoria categoria = GetFirstId(id);

        //        bool atividadeAnterior = categoria.Atividade;
        //        categoria.Atividade = categoriaDto.Atividade;

        //        if (categoriaDto.Atividade != atividadeAnterior)
        //        {
        //            if (categoriaDto.Atividade == false)
        //            {
        //                // Atualiza o status da categoria e das subcategorias relacionadas para inativo
        //                List<Sub> subs = _context.Subs.Where(s => s.CategoriaId == categoria.Id).ToList();
        //                foreach (Sub subcategoria in subs)
        //                {
        //                    subcategoria.Atividade = false;
        //                }
        //            }
        //            else
        //            {
        //                // Atualiza o status da categoria e das subcategorias relacionadas para ativo
        //                List<Sub> subs = _context.Subs.Where(s => s.CategoriaId == categoria.Id).ToList();
        //                foreach (Sub subcategoria in subs)
        //                {
        //                    subcategoria.Atividade = true;
        //                }
        //            }
        //        }
        //        bool nomeRepetido = _context.Categorias.Any(c => c.NomeDaCategoria == categoriaDto.NomeDaCategoria) ||
        //        _context.Subs.Any(s => s.NomeDaSub == categoriaDto.NomeDaCategoria);

        //        if (nomeRepetido)
        //        {
        //            throw new ArgumentException ("O nome utilizado já existe na lista, tente um diferente dos existentes!");
        //        }


        //        categoria.HoraDaModificacao = categoriaDto.HoraDaModificacao;
        //        categoria.NomeDaCategoria = categoriaDto.NomeDaCategoria;

        //        _context.SaveChanges();
        //        return categoriaDto;
        //    }

        //    public UpdateCategoriaDtoName PatchNome(int id, [FromBody] UpdateCategoriaDtoName categoriaDto)
        //    {
        //        Categoria categoria = GetFirstId(id);

        //        if (categoria == null)
        //        {
        //            throw new Exception("Categoria não encontrada");
        //        }

        //        if (categoria.NomeDaCategoria != null)
        //        {
        //            bool nomeRepetido = _context.Categorias.Any(c => c.NomeDaCategoria == categoriaDto.NomeDaCategoria) ||
        //            _context.Subs.Any(s => s.NomeDaSub == categoriaDto.NomeDaCategoria);

        //            if (nomeRepetido)
        //            {
        //                throw new ArgumentException("O nome utilizado já existe na lista, tente um diferente dos existentes!");
        //            }

        //            categoria.NomeDaCategoria = categoriaDto.NomeDaCategoria;
        //        }
        //        categoria.HoraDaModificacao = categoriaDto.HoraDaModificacao;

        //        _context.SaveChanges();
        //        return categoriaDto; 
        //    }

        //    public UpdateCategoriaDtoStatus PatchStatus(int id,[FromBody] UpdateCategoriaDtoStatus categoriaDto)
        //    {
        //        Categoria categoria = GetFirstId(id);

        //        if (categoria == null)
        //        {
        //            throw new Exception("Categoria não encontrada");
        //        }

        //        bool idExist = _context.Categorias.Any(c => c.Id == id);
        //        if (idExist != true)
        //        {
        //            throw new Exception("Id não encontrado");
        //        }

        //        if (categoria.Atividade == categoriaDto.Atividade)
        //        {
        //           throw new ArgumentException("valor inserido é o mesmo que o original, insira um valor diferente!");
        //        }

        //        bool atividadeAnterior = categoria.Atividade;
        //        categoria.Atividade = categoriaDto.Atividade;
        //        categoria.HoraDaModificacao = categoriaDto.HoraDaModificacao;


        //        if (!categoriaDto.Atividade)
        //        {
        //            var subs = _context.Subs.Where(s => s.CategoriaId == id);
        //            foreach (var sub in subs)
        //            {
        //                sub.Atividade = false;

        //            }

        //            var produtos = _context.Produtos.Where(p => p.SubId == id);
        //            foreach (var produto in produtos)
        //            {
        //                produto.Atividade = false;

        //            }
        //        }
        //        _context.SaveChanges();

        //        return categoriaDto; 

        //    }

        //    public void Delete(int id)
        //    {
        //        var categoria = _context.Categorias.Find(id);

        //        bool idExist = _context.Categorias.Any(c => c.Id == id);
        //        if (! idExist)
        //        {
        //           throw new Exception("Id não encontrado");
        //        }
        //         _context.Remove(categoria);
        //        _context.SaveChanges();


        //        //bool nomeRepetido = _context.Categorias.Any(c => c.NomeDaCategoria == categoriaDto.NomeDaCategoria) ||
        //        //_context.Subs.Any(s => s.NomeDaSub == categoriaDto.NomeDaCategoria);

        //        //if (nomeRepetido)
        //        //{
        //        //    throw new NameIsUseExceptions("O nome utilizado ja existe na lista, tente um diferente dos existentes!");
        //        //}
        //        //Categoria categoria = _mapper.Map<Categoria>(categoriaDto); //Mapeando Categoria em categoriaDto

        //        //AddCategoria(categoria);
        //        //return categoria;

        //    }

        //    public Categoria GetFirstId(int id)
        //    {
        //        //bool idExist = _context.Categorias.Any(c => c.Id == id);
        //        //if (idExist != true)
        //        //{
        //        //    throw new NotFoundExceptions("Id não encontrado");
        //        //}

        //        return _context.Categorias.FirstOrDefault(c => c.Id == id);


        //    }

        #endregion

        public void Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync(int skip, int take, string? status, string? ordenacao, string? nome)
        {
            using var connection = _context.Database.GetDbConnection();

            string sql =
             @"
                SELECT * FROM CATEGORIAS
                WHERE 1=1
             ";

            if (!string.IsNullOrEmpty(status))
            {
                if (status == "ativo".ToLower())
                {
                    sql += " AND Atividade = 1";
                }
                else if (status == "inativo".ToLower())
                {
                    sql += " AND Atividade = 0";
                }
            }

            if (!string.IsNullOrWhiteSpace(ordenacao))
            {
                sql += $" ORDER BY NomeDaCategoria  {(ordenacao.ToLower() == "crescente" ? "ASC" : "DESC")}";
            }

            sql += " LIMIT @Skip , @Take";


            var parameters = new
            {
                Status = status,
                Nome = nome,
                Skip = skip,
                Take = take
            };

            connection.Open();
            return await connection.QueryAsync<Categoria>(sql, parameters);
        }



        public void Update(Categoria categoria)
        {          
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await _context.Set<Categoria>().FindAsync(id);
            if (categoria != null)
            {
                _context.Set<Categoria>().Remove(categoria);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("ID não encontrado");
            }
        }

        public async Task<Categoria> GetFirstIdAsync(int id)
        {
            var idExist = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);

            if (idExist == null)
            {
                throw new ArgumentException("Não encontrado!");
            }

            return idExist;
        }

        public bool NameExist(Categoria categoria)
        {
            bool nameExist = _context.Categorias.Any(c => c.NomeDaCategoria == categoria.NomeDaCategoria && c.Id != categoria.Id) ||
                        _context.Subs.Any(s => s.NomeDaSub == categoria.NomeDaCategoria && s.CategoriaId != categoria.Id);

            if (nameExist)
            {
                throw new ArgumentException("O nome utilizado já existe na lista, tente um diferente dos existentes!");
            }
            return true;
        }
    }
}



