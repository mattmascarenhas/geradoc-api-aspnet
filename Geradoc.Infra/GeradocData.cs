using Geradoc.Shared;
using System.Data;
using System.Data.SqlClient;


namespace Geradoc.Infra {
    public class GeradocData : IDisposable {
        public SqlConnection Conexao { get; set; }

        public GeradocData(){
            Conexao = new SqlConnection(ConfiguracaoBancoDeDados.StringDeConexao);
            Conexao.Open();
        }

        public void Dispose() {
            if (Conexao.State != ConnectionState.Closed)
                Conexao.Close();
        }

    }
}
