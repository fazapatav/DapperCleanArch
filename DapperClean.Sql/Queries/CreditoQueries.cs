using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperClean.Sql.Queries
{
    public static class CreditoQueries
    {
        public static string AllCreditos => "SELECT * FROM [Credito] (NOLOCK)";

        public static string CreditoById => "SELECT * FROM [Credito] (NOLOCK) WHERE [Id] = @CreditoId";

        public static string AddCredito =>
            @"INSERT INTO [Credito] ([Valor], [Interes], [Cuotas]) 
            VALUES (@Valor, @Interes, @Cuotas)";

        public static string UpdateCredito =>
            @"UPDATE [Credito] 
        SET [Valor] = @Valor, 
            [Interes] = @Interes, 
            [Cuotas] = @Cuotas, 
        WHERE [Id] = @CreditoId";

        public static string DeleteCredito => "DELETE FROM [Credito] WHERE [Id] = @CreditoId";
    }
}
