using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    public class Cliente
    {
        //subclasse para unidade do cliente
        public class Unit
        {
            #region Atributos e especificações
            [Required(ErrorMessage = "Código do Cliente é obrigatório.")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Código do Cliente somente aceita valores numéricos.")]
            [StringLength(6, MinimumLength = 6, ErrorMessage = "Código do Cliente deve ter 6 dígitos.")]
            public string Id { get; set; }

            [Required(ErrorMessage = "Nome do Cliente é obrigatório.")]
            [StringLength(50, ErrorMessage = "Nome do Cliente deve ter no máximo 50 caracteres.")]
            public string Nome { get; set; }

            [StringLength(50, ErrorMessage = "Nome do Pai deve ter no máximo 50 caracteres.")]
            public string NomePai { get; set; }

            [Required(ErrorMessage = "Nome da Mãe é obrigatório.")]
            [StringLength(50, ErrorMessage = "Nome da Mãe deve ter no máximo 50 caracteres.")]
            public string NomeMae { get; set; }
            public int NaoTemPai { get; set; }

            [Required(ErrorMessage = "CPF obrigatório.")]
            [RegularExpression("([0-9]+)", ErrorMessage = "CPF somente aceita valores numéricos.")]
            [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 dígitos.")]
            public string Cpf { get; set; }

            [Required(ErrorMessage = "Genero obrigatório.")]
            public int Genero { get; set; }

            [Required(ErrorMessage = "CEP obrigatório.")]
            [RegularExpression("([0-9]+)", ErrorMessage = "CPF somente aceita valores numéricos.")]
            [StringLength(8, MinimumLength = 8, ErrorMessage = "CPF deve ter 8 dígitos.")]
            public string Cep { get; set; }

            [Required(ErrorMessage = "Logradouro é obrigatório.")]
            [StringLength(100, ErrorMessage = "Logradouro deve ter no máximo 100 caracteres.")]
            public string Logradouro { get; set; }

            [Required(ErrorMessage = "Complemento é obrigatório.")]
            [StringLength(100, ErrorMessage = "Complemento deve ter no máximo 100 caracteres.")]
            public string Complemento { get; set; }

            [Required(ErrorMessage = "Bairro é obrigatório.")]
            [StringLength(50, ErrorMessage = "Bairro deve ter no máximo 50 caracteres.")]
            public string Bairro { get; set; }

            [Required(ErrorMessage = "Cidade é obrigatória.")]
            [StringLength(50, ErrorMessage = "Cidade deve ter no máximo 50 caracteres.")]
            public string Cidade { get; set; }

            [Required(ErrorMessage = "Estado é obrigatório.")]
            [StringLength(50, ErrorMessage = "Estado deve ter no máximo 50 caracteres.")]
            public string Estado { get; set; }

            [Required(ErrorMessage = "Número do telefone é obrigatório.")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Número do telefone somente aceita valores numéricos.")]
            public string Telefone { get; set; }

            public string Profissao { get; set; }

            [Required(ErrorMessage = "Renda familiar é obrigatória.")]
            [Range(0, double.MaxValue, ErrorMessage = "Renda familiar deve ser um valor positivo.")]
            public Double RendaFamiliar { get; set; }
            #endregion

            #region CRUD 
            #region "Funções auxiliares"

            public string ToInsert()
            {
                string SQL;
                SQL = @"INSERT INTO TB_Cliente
                    (Id, 
                    Nome, 
                    NomePai, 
                    NomeMae, 
                    NaoTemPai,
                    Cpf,
                    Genero,
                    Cep, 
                    Logradouro, 
                    Complemento, 
                    Bairro, 
                    Cidade, 
                    Estado, 
                    Telefone, 
                    Profissao, 
                    RendaFamiliar)
                    VALUES";
                SQL += "('" + this.Id + "'";
                SQL += ", '" + this.Nome + "'";
                SQL += ", '" + this.NomePai + "'";
                SQL += ", '" + this.NomeMae + "'";
                SQL += ", " + Convert.ToString(this.NaoTemPai);
                SQL += ", '" + this.Cpf + "'";
                SQL += ", " + Convert.ToString(this.Genero);
                SQL += ", '" + this.Cep + "'";
                SQL += ", '" + this.Logradouro + "'";
                SQL += ", '" + this.Complemento + "'";
                SQL += ", '" + this.Bairro + "'";
                SQL += ", '" + this.Cidade + "'";
                SQL += ", '" + this.Estado + "'";
                SQL += ", '" + this.Telefone + "'";
                SQL += ", '" + this.Profissao + "'";
                SQL += ", " + Convert.ToString(this.RendaFamiliar) + ")";
                return SQL;
            }

            public string ToUpdate(string IdAltera)
            {
                string SQL;
                SQL = @"UPDATE TB_Cliente SET ";
                SQL += "Id = '" + this.Id + "'";
                SQL += " , Nome = '" + this.Nome + "'";
                SQL += " , NomePai = '" + this.NomePai + "'";
                SQL += " , NomeMae = '" + this.NomeMae + "'";
                SQL += " , NaoTemPai = " + Convert.ToString(this.NaoTemPai) + "";
                SQL += " , Cpf = '" + this.Cpf + "'";
                SQL += " , Genero = " + Convert.ToString(this.Genero) + "";
                SQL += " , Cep = '" + this.Cep + "'";
                SQL += " , Logradouro = '" + this.Logradouro + "'";
                SQL += " , Complemento = '" + this.Complemento + "'";
                SQL += " , Bairro = '" + this.Bairro + "'";
                SQL += " , Cidade = '" + this.Cidade + "'";
                SQL += " , Estado = '" + this.Estado + "'";
                SQL += " , Telefone = '" + this.Telefone + "'";
                SQL += " , Profissao = '" + this.Profissao + "'";
                SQL += " , RendaFamiliar = " + Convert.ToString(this.RendaFamiliar) + "";
                SQL += " WHERE Id = '" + Id + "';";
                return SQL;
            }

            // select * from - where id = - ==>> retorna um DataRow 
            // essa função recebe o DataRow e retorna uma classe
            public Unit DataRowToUnit(DataRow dr)
            {
                Unit u = new Unit(); //Unit tem tds as caracteristicas da classe - As colunas da tabela sao iguais datarow
                u.Id = dr["Id"].ToString();
                u.Nome = dr["Nome"].ToString();
                u.NomePai = dr["NomePai"].ToString();
                u.NomeMae = dr["NomeMae"].ToString();
                u.NaoTemPai = Convert.ToInt32(dr["NaoTemPai"]);
                u.Cpf = dr["Cpf"].ToString();
                u.Genero = Convert.ToInt32(dr["Genero"]);
                u.Cep = dr["Cep"].ToString();
                u.Logradouro = dr["Logradouro"].ToString();
                u.Complemento = dr["Complemento"].ToString();
                u.Bairro = dr["Bairro"].ToString();
                u.Cidade = dr["Cidade"].ToString();
                u.Estado = dr["Estado"].ToString();
                u.Telefone = dr["Telefone"].ToString();
                u.Profissao = dr["Profissao"].ToString();
                u.RendaFamiliar = Convert.ToDouble(dr["RendaFamiliar"]);
                return u;
            }

            #endregion

            public void IncluirSQLREL()
            {
                try
                {
                    string SQL;
                    SQL = this.ToInsert(); // retorna o comando sql do ToInsert em Funções auxiliares
                    var db = new SQLServerClass();
                    db.SQLCommand(SQL);
                    db.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Incluisão não permitida. Identificador: " + this.Id + ", erro: " + ex.Message);
                }
            }

            public Unit BuscarSQLREL(string Id)
            {
                try
                {
                    //verificar se existe 
                    string SQL = "SELECT * FROM [TB_Cliente] WHERE Id = '" + Id + "'";
                    //como comando retorna valor entao usa SQLQuery
                    var db = new SQLServerClass();
                    var dt = db.SQLQuery(SQL);

                    if (dt.Rows.Count == 0)
                    {
                        db.Close();
                        throw new Exception("Identificador não existente");
                    }
                    else
                    {
                        Unit u = this.DataRowToUnit(dt.Rows[0]); // DataRow => Unit
                        return u;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar conteúdo do identificador: " + ex.Message);
                }
            }

            public void AlterarSQLREL()
            {
                try
                {
                    //verificar se existe 
                    string SQL = "SELECT * FROM [TB_Cliente] WHERE Id = '" + Id + "'";
                    //como comando retorna valor entao usa SQLQuery
                    var db = new SQLServerClass();
                    var dt = db.SQLQuery(SQL);

                    if (dt.Rows.Count == 0)
                    {
                        db.Close();
                        throw new Exception("Identificador não existente");
                    }
                    else
                    {
                        SQL = this.ToUpdate(this.Id);
                        //executar o comando sql
                        db.SQLCommand(SQL);
                        db.Close();
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao alterar conteúdo do identificador: " + ex.Message);
                }
            }

            public void ExcluirSQLREL()
            {
                try
                {
                    //verificar se existe 
                    string SQL = "SELECT * FROM [TB_Cliente] WHERE Id = '" + this.Id + "'";
                    //como comando retorna valor entao usa SQLQuery
                    var db = new SQLServerClass();
                    var dt = db.SQLQuery(SQL);

                    if (dt.Rows.Count == 0)
                    {
                        db.Close();
                        throw new Exception("Identificador não existente");
                    }
                    else
                    {
                        SQL = "DELETE FROM [TB_Cliente] WHERE Id = '" + this.Id + "'";
                        //executar o comando sql
                        db.SQLCommand(SQL);
                        db.Close();
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao excluir conteúdo do identificador: " + ex.Message);
                }
            }

            public List<List<string>> BuscarDBTodosSQLREL()
            {
                List<List<string>> ListaBusca = new List<List<string>>();
                try
                {
                    var SQL = "SELECT * FROM [TB_Cliente]";
                    var db = new SQLServerClass();
                    var dt = db.SQLQuery(SQL);

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        ListaBusca.Add(new List<string> { dt.Rows[i]["Id"].ToString(), dt.Rows[i]["Nome"].ToString() }); // vetor bidimencional com id e nome do cliente
                    }
                    return ListaBusca;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro de conexão: " + ex.Message);
                }
            }

            #endregion
        }
    }
}
