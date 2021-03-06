﻿using Fusi.Tools.Config;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cadmus.Index.Sql
{
    /// <summary>
    /// Item index writer for SQL Server.
    /// Tag: <c>item-index-writer.mssql</c>.
    /// </summary>
    /// <seealso cref="IItemIndexWriter" />
    [Tag("item-index-writer.mssql")]
    public sealed class MsSqlItemIndexWriter : SqlItemIndexWriterBase,
        IItemIndexWriter,
        IConfigurable<SqlOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MsSqlItemIndexWriter"/>
        /// class.
        /// </summary>
        public MsSqlItemIndexWriter() : base("MsSql", new MsSqlTokenHelper())
        {
        }

        /// <summary>
        /// Configures the object with the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <exception cref="ArgumentNullException">options</exception>
        public void Configure(SqlOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            ConnectionString = options.ConnectionString;
        }

        /// <summary>
        /// Clears the whole index.
        /// </summary>
        public Task Clear()
        {
            string sysCS = Regex.Replace(
                ConnectionString, "Database=([^;]+)", "Database=master");
            IDbManager manager = new MySqlDbManager(sysCS);

            string db = GetDbName();
            if (manager.Exists(db)) manager.ClearDatabase(db);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets the name of the database from the connection string.
        /// </summary>
        /// <returns>
        /// Database name or null.
        /// </returns>
        protected override string GetDbName()
        {
            Match m = Regex.Match(ConnectionString, "Database=([^;]+)",
                RegexOptions.IgnoreCase);
            return m.Success ? m.Groups[1].Value : null;
        }

        /// <summary>
        /// Gets the database manager.
        /// </summary>
        /// <returns>
        /// Database manager.
        /// </returns>
        protected override IDbManager GetDbManager() =>
            new MsSqlDbManager(ConnectionString);

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns>
        /// Connection.
        /// </returns>
        protected override DbConnection GetConnection() =>
            new SqlConnection(ConnectionString);

        /// <summary>
        /// Gets a new command object.
        /// </summary>
        /// <returns>Command.</returns>
        protected override DbCommand GetCommand() =>
            new SqlCommand();

        #region IDisposable Support
        private bool _disposedValue; // to detect redundant calls

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Connection?.Close();
                }
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
