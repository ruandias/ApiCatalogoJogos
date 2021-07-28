using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            { Guid.Parse("9442d845-1c82-4072-9548-1faf1bdc0484"), new Jogo{ Id = Guid.Parse("9442d845-1c82-4072-9548-1faf1bdc0484"), Nome = "Fifa 21", Produtora = "EA", Preco = 200} },
            { Guid.Parse("000ee520-843b-459c-9c2e-50b47b72f2b6"), new Jogo{ Id = Guid.Parse("000ee520-843b-459c-9c2e-50b47b72f2b6"), Nome = "Fifa 20", Produtora = "EA", Preco = 190} },
            { Guid.Parse("a3bb8ebd-4c8a-45c3-9bad-18ce28a3df80"), new Jogo{ Id = Guid.Parse("a3bb8ebd-4c8a-45c3-9bad-18ce28a3df80"), Nome = "Fifa 19", Produtora = "EA", Preco = 180} },
            { Guid.Parse("26ccfd59-ab40-4596-bd59-b7b077ad8523"), new Jogo{ Id = Guid.Parse("26ccfd59-ab40-4596-bd59-b7b077ad8523"), Nome = "Fifa 18", Produtora = "EA", Preco = 170} },
            { Guid.Parse("162bc53f-1d75-429e-b991-7481ce869d73"), new Jogo{ Id = Guid.Parse("162bc53f-1d75-429e-b991-7481ce869d73"), Nome = "Street Fighter V", Produtora = "Capcom", Preco = 80} },
            { Guid.Parse("7e96fef9-9406-41fe-8dc2-943ebb686ccf"), new Jogo{ Id = Guid.Parse("7e96fef9-9406-41fe-8dc2-943ebb686ccf"), Nome = "Grand Theft Auto V", Produtora = "Rockstar", Preco = 190} },


        };

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexação com o banco
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach(var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }
    }
}
