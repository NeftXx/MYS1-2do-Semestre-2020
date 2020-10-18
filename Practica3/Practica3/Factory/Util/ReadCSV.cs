

using LumenWorks.Framework.IO.Csv;
using System.Collections.Generic;
using System.Data;
using System.IO;


namespace Practica3.Factory.Util
{
    class ReadCSV
    {
        public static List<BasicNode> GetCoordanates(SimioAPI.IIntelligentObjects intelligentObjects)
        {
            List<BasicNode> list = new List<BasicNode>();
            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StringReader(FileStore.Resource.Coordinates), true))
            {
                csvTable.Load(csvReader);
            }
            BasicNode basicNode;
            for (int i = 0; i < csvTable.Rows.Count; i++)
            {

                basicNode = new BasicNode(
                    intelligentObjects,
                    int.Parse(csvTable.Rows[i][0].ToString()),
                    int.Parse(csvTable.Rows[i][1].ToString()),
                    csvTable.Rows[i][2].ToString()
                    );
                basicNode.UpdateOutboundLinkRule("By Link Weight");
                list.Add(basicNode);
            }
            return list;
        }
    }
}
