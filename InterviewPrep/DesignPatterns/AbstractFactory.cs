using System;

namespace InterviewPrep.DesignPatterns
{
    class AbstractFactory
    {
    }

    interface IConnection
    {
        void CreateConnection();
    }

    class SQLConnection : IConnection
    {
        public void CreateConnection()
        {
            Console.WriteLine("SQL Connection Created!");
        }
    }

    class OracleConnection : IConnection
    {
        public void CreateConnection()
        {
            Console.WriteLine("Oracle Connection Created!");
        }
    }

    interface ICommand
    {
        void CreateCommand();
    }

    class SQLCommand : ICommand
    {
        public void CreateCommand()
        {
            Console.WriteLine("SQL Command Created!");
        }
    }

    class OracleCommand : ICommand
    {
        public void CreateCommand()
        {
            Console.WriteLine("Oracle Command Created!");
        }
    }

    interface IDatabase
    {
        IConnection connection { get; set; }
        ICommand command { get; set; }
        void CreateDatabase();
    }

    class SQLDatabase : IDatabase
    {
        public ICommand command
        {
            get
            {
                return command;
            }
            set
            {
                command = value;
            }
        }

        public IConnection connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;
            }
        }

        public SQLDatabase()
        {
            connection = new SQLConnection();
            command = new SQLCommand();
        }

        public void CreateDatabase()
        {
            connection.CreateConnection();
            command.CreateCommand();
        }
    }

    class OracleDatabase : IDatabase
    {
        public ICommand command
        {
            get
            {
                return command;
            }

            set
            {
                command = value;
            }
        }

        public IConnection connection
        {
            get
            {
                return connection;
            }

            set
            {
                connection = value;
            }
        }

        public OracleDatabase()
        {
            connection = new OracleConnection();
            command = new OracleCommand();
        }

        public void CreateDatabase()
        {
            connection.CreateConnection();
            command.CreateCommand();
        }
    }

}
