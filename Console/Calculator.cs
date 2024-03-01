using System.Data.SqlClient;
using MySqlConnector;

namespace Cons;

public class Calculator : ICalculator
{
    public double Add(double n1, double n2)
    {
        double result = n1 + n2;
        LogOperation(n1, n2, "plus", result);
        return result;
    }

    public double Subtract(double n1, double n2)
    {
        double result = n1 - n2;
        LogOperation(n1, n2, "minus", result);
        return result;
    }

    public double Multiply(double n1, double n2)
    {
        double result = n1 * n2;
        LogOperation(n1, n2, "multiply", result);
        return result;
    }

    public double Divide(double n1, double n2)
    {
        double result = n1 / n2;
        LogOperation(n1, n2, "divide", result);
        return result;
    }

    private void LogOperation(double n1, double n2, string operation, double result)
    {
        string connectionString = "Server=calc-db-service;Database=calcdb;Uid=root;Pwd=example;";
        
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            // Check and create table if not exists
            var checkTableCmd = @"
        CREATE TABLE IF NOT EXISTS CalculationLog (
            Id INT AUTO_INCREMENT PRIMARY KEY,
            Number1 DOUBLE NOT NULL,
            Number2 DOUBLE NOT NULL,
            Operation VARCHAR(10) NOT NULL,
            Result DOUBLE NOT NULL
        )";
            using (var command = new MySqlCommand(checkTableCmd, connection))
            {
                command.ExecuteNonQuery();
            }

            // Insert log entry
            var insertCmd = @"
        INSERT INTO CalculationLog (Number1, Number2, Operation, Result)
        VALUES (@Number1, @Number2, @Operation, @Result)";
            using (var command = new MySqlCommand(insertCmd, connection))
            {
                command.Parameters.AddWithValue("@Number1", n1);
                command.Parameters.AddWithValue("@Number2", n2);
                command.Parameters.AddWithValue("@Operation", operation);
                command.Parameters.AddWithValue("@Result", result);

                command.ExecuteNonQuery();
            }
        }
    }
}