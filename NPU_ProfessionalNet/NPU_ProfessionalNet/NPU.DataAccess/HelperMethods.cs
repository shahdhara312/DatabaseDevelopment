using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace NPU.DataAccess
{
    public class HelperMethods
    {
        #region Helper Methods

        public static int GetOrdinal(IDataReader reader, string fieldName)
        {
            try
            {
                return reader.GetOrdinal(fieldName);
            }
            catch (IndexOutOfRangeException)
            {
                return -1;
            }
        }

        public static Int32 GetInt32(IDataReader reader, string fieldName)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return reader.GetInt32(fieldIndex);
            else
                return 0;
        }

        public static Int16 GetInt16(IDataReader reader, string fieldName)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return reader.GetInt16(fieldIndex);
            else
                return 0;
        }

        public static Int64 GetInt64(IDataReader reader, string fieldName)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return reader.GetInt64(fieldIndex);
            else
                return 0;
        }

        public static String GetString(IDataReader reader, string fieldName)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return reader.GetString(fieldIndex);
            else
                return String.Empty;
        }

        public static Boolean GetBoolean(IDataReader reader, string fieldName)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return reader.GetBoolean(fieldIndex);
            else
                return false;
        }

        public static DateTime GetDateTime(IDataReader reader, string fieldName)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return Convert.ToDateTime(reader[fieldIndex]); //reader.GetDateTime(fieldIndex);
            else
                return DateTime.MinValue;
        }

        public static Decimal GetDecimal(IDataReader reader, string fieldName)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return reader.GetDecimal(fieldIndex);
            else
                return 0;
        }

        public static Double GetDouble(IDataReader reader, string fieldName)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return reader.GetDouble(fieldIndex);
            else
                return 0;
        }

        public static float GetFloat(IDataReader reader, string fieldName)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return reader.GetFloat(fieldIndex);
            else
                return 0;
        }

        public static Guid GetGuid(IDataReader reader, string fieldName)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return reader.GetGuid(fieldIndex);
            else
                return Guid.Empty;
        }

        public static Byte GetByte(IDataReader reader, string fieldName)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return reader.GetByte(fieldIndex);
            else
                return byte.MinValue;
        }

        public static long GetBytes(IDataReader reader, string fieldName, long fieldOffset, byte[] buffer, int bufferOffset, int length)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return reader.GetBytes(fieldIndex, fieldOffset, buffer, bufferOffset, length);
            else
                return 0;
        }

        public static char GetChar(IDataReader reader, string fieldName)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return reader.GetChar(fieldIndex);
            else
                return char.MinValue;
        }

        public static long GetChars(IDataReader reader, string fieldName, long fieldOffset, char[] buffer, int bufferOffset, int length)
        {
            int fieldIndex = GetOrdinal(reader, fieldName);
            if (fieldIndex != -1 && !reader.IsDBNull(fieldIndex))
                return reader.GetChars(fieldIndex, fieldOffset, buffer, bufferOffset, length);
            else
                return 0;
        }

        #endregion
    }
}
