using Geradoc.Shared;
using System.Data;
using System.Data.SqlClient;


namespace Geradoc.Infra {
    public class GeradocData : IDisposable {
        public SqlConnection Conexao { get; set; }

        public GeradocData(){
            try {
                Conexao = new SqlConnection(ConfiguracaoBancoDeDados.StringDeConexao);
                Conexao.Open();
                Console.WriteLine("Connected!");

            } catch (Exception ex) {
                Console.WriteLine($"Failed to connect to the database: {ex.Message}");
            }
            
        }

        public void Dispose() {
            if (Conexao.State != ConnectionState.Closed)
                Conexao.Close();
        }

    }
}
