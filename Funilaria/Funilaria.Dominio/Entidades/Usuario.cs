using Flunt.Notifications;
using Flunt.Validations;
using Funilaria.Comum;
using Funilaria.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funilaria.Dominio
{
    public class Usuario : Base
    {
        public Usuario(string nome, string telefone, string email, string senha, EnTipoUsuario tipoUsuario)
        {

            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(nome, "Nome", "Nome não pode ser vazio")
                .IsNotEmpty(telefone, "Telefone", "O numero de telefone está incorreto")
                .IsEmail(email, "Email", "O formato de email esta incorreto")
                .IsGreaterThan(senha, 7, "Senha", "A senha deve ter pelo menos 8 caracteres")
                );

            if (IsValid)
            {
                Nome = nome;
                Telefone = telefone;
                Email = email;
                Senha = senha;
                TipoUsuario = tipoUsuario;
            }

        }

        public string Nome      { get; private set; }
        public string Telefone  { get; private set; }
        public string Email     { get; private set; }
        public string Senha     { get; private set; }
        public string Imagem    { get; private set; }
        public EnTipoUsuario TipoUsuario { get; private set; }

        // Composições
        private List<Carro> _Carros { get; set; }
        public IReadOnlyCollection<Carro> Carros { get { return _Carros; } }

        
        private List<Orcamento> _Orcamentos { get; set; }
        public IReadOnlyCollection<Orcamento> Orcamentos { get {return _Orcamentos;} } 

        
        private List<Servico> _Servicos { get; set; }
        public IReadOnlyCollection<Servico> Servicos { get {return _Servicos;} } 

        private List<Marca> _Marcas { get; set; }
        public IReadOnlyCollection<Marca> Marcas { get { return _Marcas; } }

        private List<Modelo> _Modelos { get; set; }
        public IReadOnlyCollection<Modelo> Modelos { get { return _Modelos; } }



        // Para alterar os carros, será necessário Lista de apoio 

        public void AtualizarSenha( string senha)
        {
            AddNotifications(
               new Contract<Notification>()
               .Requires()
               .IsGreaterThan(senha, 7, "Senha", "A senha deve ter pelo menos 8 caracteres")
               );
            if (IsValid)
               Senha = senha;
        }

        public void AtualizaUsuario(string nome, string telefone, string email)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(nome, "Nome", "Nome não pode ser vazio")
                .IsNotEmpty(telefone, "Telefone", "O numero de telefone está incorreto")
                .IsEmail(email, "Email", "O formato de email esta incorreto")
                );
            if(IsValid)
            {
                Nome = nome;
                Telefone = telefone;
                Email = email; 
            }
        }
    }
}
