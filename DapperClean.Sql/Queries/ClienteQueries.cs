using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperClean.Sql.Queries
{
    public  class ClienteQueries
    {
        public static string AllClientes => "SELECT * FROM [Cliente] (NOLOCK)";

        public static string ClienteById => "SELECT * FROM [Cliente] (NOLOCK) WHERE [Id] = @ClienteId";

        public static string AddCliente =>
            @"INSERT INTO [Cliente] ([Nombre], [Edad]) 
            VALUES (@Nombre, @Edad)";

        public static string UpdateCliente =>
            @"UPDATE [Cliente] 
        SET [Nombre] = @Nombre, 
            [Edad] = @Edad,
        WHERE [Id] = @ClienteId";

        public static string DeleteCliente => "DELETE FROM [Cliente] WHERE [Id] = @ClienteId";
    }
}
