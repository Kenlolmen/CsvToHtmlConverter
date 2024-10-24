using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab4a
{
    internal class Convert
    {

        void Header(StreamWriter writer)
        {
            writer.WriteLine("<html>");
            writer.WriteLine("<head><title>CSV TO HTML TABLE</title></head>");
            writer.WriteLine("<body>");
        }

        void Table(StreamWriter writer)
        {
            writer.WriteLine("<table border='1'>");
        }

        void HeaderRow(StreamWriter writer, string line)
        {
            var columns = line.Split(',');
            writer.WriteLine("<tr>");
            foreach (var column in columns)
            {
                writer.WriteLine($"<th>{column.Trim('"')}</th>");
            }
            writer.WriteLine("</tr>");
        }

         void DataRow(StreamWriter writer, string line)
        {
            var columns = line.Split(',');
            writer.WriteLine("<tr>");
            foreach (var column in columns)
            {
                writer.WriteLine($"<td>{column.Trim('"')}</td>");
            }
            writer.WriteLine("</tr>");
        }

         void Stop(StreamWriter writer)
        {
            writer.WriteLine("</table>");
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
        }


        public bool convert(string CsvPath, string HtmlPath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(CsvPath))
                using (StreamWriter writer = new StreamWriter(HtmlPath))

                {
                    Header(writer);
                    Table(writer);

                    string line;
                    bool FirstRow = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (FirstRow)
                        {
                            HeaderRow(writer, line);
                            FirstRow = false;
                        }
                        else
                        {
                            DataRow(writer, line);
                        }
                    }

                    Stop(writer);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }

        }
    }
}
