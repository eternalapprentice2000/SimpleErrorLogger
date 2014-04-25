using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Text;

namespace ErrorLogger.Storage.SQL
{

    /// <summary>
    /// Base class for Storage classes, which handle persistent storage of data
    /// </summary>
    public class StorageBase
    {
        private static volatile StorageBase _instance;
        private static object syncRoot = new Object();

        public static StorageBase Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new StorageBase();
                    }
                }
                return _instance;
            }
        }



        /// <summary>
        /// Connection string for Contest database on OLTP server
        /// </summary>
        private string _ErrorLog;

      


        /// <summary>
        /// Gets the default connection string for the Contest database.
        /// The default connection string is read from the connection strings in the application configuration file.
        /// </summary>
        internal string ErrorLog
        {
            get
            {
                if (string.IsNullOrEmpty(_ErrorLog) == false)
                    return _ErrorLog;

                _ErrorLog = GetConnectionString("ErrorLog");
                return _ErrorLog;
            }
        }

      

        private string GetConnectionString(string configKey)
        {
            string returnString;
            try
            {
                returnString = ConfigurationManager.ConnectionStrings[configKey].ConnectionString;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Unable to find the \"" + configKey + "\" connection string.");
            }

            if (string.IsNullOrWhiteSpace(configKey))
                throw new InvalidOperationException("Unable to find the \"" + configKey + "\" connection string.");

            return returnString;
        }


        public void ResetConnectionStrings()
        {
            _ErrorLog = string.Empty;
        }



        /// <summary>
        /// Combines an array of ids to multiple strings containing comma separated values.
        /// </summary>
        /// <param name="ids">The list of ids to combine</param>
        /// <param name="limit">The max size for each combined string</param>
        /// <returns>A list of combined strings, each within the specified limit.</returns>
        protected Collection<string> CombineIntArrays(Collection<int> ids, int limit)
        {
            Collection<string> combinedStrings = new Collection<string>();
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < ids.Count; i++)
            {
                // If size of current buffer + next time +1 (the comma) is bigger than the limit, dump the current buffer into strings collection and reset
                if (builder.Length + ids[0].ToString(System.Globalization.CultureInfo.InvariantCulture).Length + 1 > limit)
                {
                    combinedStrings.Add(builder.ToString());
                    builder.Length = 0;
                }

                if (builder.Length > 0)
                {
                    builder.Append(",");
                }

                builder.Append(ids[i]);

                if (i == ids.Count - 1)
                {
                    combinedStrings.Add(builder.ToString());
                    builder.Length = 0;
                }
            }

            return combinedStrings;
        }

        /// <summary>
        /// Combines an array of ids to multiple strings containing comma separated values.
        /// </summary>
        /// <param name="ids">The list of ids to combine</param>
        /// <param name="limit">The max size for each combined string</param>
        /// <returns>A list of combined strings, each within the specified limit.</returns>
        protected Collection<string> CombineLongArrays(Collection<long> ids, int limit)
        {
            Collection<string> combinedStrings = new Collection<string>();
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < ids.Count; i++)
            {
                // If size of current buffer + next time +1 (the comma) is bigger than the limit, dump the current buffer into strings collection and reset
                if (builder.Length + ids[0].ToString(System.Globalization.CultureInfo.InvariantCulture).Length + 1 > limit)
                {
                    combinedStrings.Add(builder.ToString());
                    builder.Length = 0;
                }

                if (builder.Length > 0)
                {
                    builder.Append(",");
                }

                builder.Append(ids[i]);

                if (i == ids.Count - 1)
                {
                    combinedStrings.Add(builder.ToString());
                    builder.Length = 0;
                }
            }

            return combinedStrings;
        }

        /// <summary>
        /// Combines an array of strings to multiple strings containing comma separated values.
        /// </summary>
        /// <param name="strings">The list of strings to combine</param>
        /// <param name="limit">The max size for each combined string</param>
        /// <returns>A list of combined strings, each within the specified limit.</returns>
        protected Collection<string> CombineStringArrays(Collection<string> strings, int limit)
        {
            Collection<string> combinedStrings = new Collection<string>();
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < strings.Count; i++)
            {
                // If size of current buffer + next time +1 (the comma) is bigger than the limit, dump the current buffer into strings collection and reset
                if (builder.Length + strings[0].Length + 1 > limit)
                {
                    combinedStrings.Add(builder.ToString());
                    builder.Length = 0;
                }

                if (builder.Length > 0)
                {
                    builder.Append(",");
                }

                builder.Append(strings[i]);

                if (i == strings.Count - 1)
                {
                    combinedStrings.Add(builder.ToString());
                    builder.Length = 0;
                }
            }

            return combinedStrings;
        }

        /// <summary>
        /// Combines an array of ids to a string containing comma separated values.
        /// </summary>
        /// <param name="ids">The list of ids to combine</param>
        /// <returns>String of comma separated values</returns>
        protected string CombineInts(Collection<int> ids)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < ids.Count; i++)
            {
                if (builder.Length > 0)
                {
                    builder.Append(",");
                }

                builder.Append(ids[i]);
            }

            return builder.ToString();
        }
    }


}
