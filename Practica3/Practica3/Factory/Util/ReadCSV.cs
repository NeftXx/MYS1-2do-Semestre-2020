

using LumenWorks.Framework.IO.Csv;
using System.Collections.Generic;
using System.Data;
using System.IO;


namespace Practica3.Factory.Util
{
    class ReadCSV
    {
        public static List<Coordinate> GetCoordanates()
        {
            List<Coordinate> lista = new List<Coordinate>();
            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StringReader(FileStore.Resource.Coordinates), true))
            {
                csvTable.Load(csvReader);
            }
            string h = "";
            for (int i = 0; i < csvTable.Rows.Count; i++)
            {

                lista.Add(new Coordinate {
                    X = int.Parse(csvTable.Rows[i][0].ToString()),
                    Y = int.Parse(csvTable.Rows[i][1].ToString())
                });
            }
            return lista;
        }
    }
}
